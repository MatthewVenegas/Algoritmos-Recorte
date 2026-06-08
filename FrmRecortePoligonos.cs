using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmosDeDiscretizacion.Algoritmos.Recorte;
using AlgoritmosDeDiscretizacion.Modelos;
using AlgoritmosDeDiscretizacion.Utilidades;

namespace AlgoritmosDeDiscretizacion
{
    public partial class FrmRecortePoligonos : Form
    {
        private readonly AlgoritmoSutherlandHodgman _sutherland = new AlgoritmoSutherlandHodgman();
        private readonly AlgoritmoWeilerAtherton _weiler = new AlgoritmoWeilerAtherton();
        private readonly AlgoritmoCyrusBeckPoligono _cyrus = new AlgoritmoCyrusBeckPoligono();

        private List<PasoRecorte> pasosCalculados = new List<PasoRecorte>();
        private int _pasoActual = -1;
        private int tamanoPixel = 20;
        private List<PointF> _poligonoOriginal = new List<PointF>();
        private bool _animando = false;
        private bool _cancelar = false;

        public FrmRecortePoligonos()
        {
            InitializeComponent();
            GraficadorBase.EstilizarTabla(tabla);

            this.Load += FrmRecortePoligonos_Load;
            btnGraficar.Click += btnGraficar_Click;
            btnPasoPaso.Click += btnPasoPaso_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            cmbAlgoritmo.SelectedIndexChanged += cmbAlgoritmo_SelectedIndexChanged;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.Paint += picCanvas_Paint;
            trkVelocidad.Scroll += trkVelocidad_Scroll;

            cmbAlgoritmo.SelectedIndex = 0;
            lblVelValor.Text = trkVelocidad.Value + "ms";
        }

        private void FrmRecortePoligonos_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void cmbAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarExplicacion();
            LimpiarLienzoYPasos();
        }

        private void ActualizarExplicacion()
        {
            switch (cmbAlgoritmo.SelectedIndex)
            {
                case 0: txtExplicacion.Text = _sutherland.ObtenerExplicacion(); break;
                case 1: txtExplicacion.Text = _weiler.ObtenerExplicacion(); break;
                case 2: txtExplicacion.Text = _cyrus.ObtenerExplicacion(); break;
            }
        }

        private void LimpiarLienzoYPasos()
        {
            _cancelar = true;
            _pasoActual = -1;
            pasosCalculados.Clear();
            _poligonoOriginal.Clear();
            tabla.DataSource = null;
            lblError.Text = "";
            lblEcuacion.Text = "Modo Polígono: Clic izquierdo en lienzo para añadir vértices. Clic derecho para limpiar.";
            picCanvas.Invalidate();
        }

        private void Limpiar()
        {
            _cancelar = true;
            _animando = false;

            txtXMin.Text = "-10"; txtXMax.Text = "10";
            txtYMin.Text = "-10"; txtYMax.Text = "10";
            lblError.Text = "";

            pasosCalculados.Clear();
            _poligonoOriginal.Clear();
            _pasoActual = -1;
            tabla.DataSource = null;
            lblEcuacion.Text = "Modo Polígono: Clic izquierdo en lienzo para añadir vértices. Clic derecho para limpiar.";

            ActualizarExplicacion();
            picCanvas.Invalidate();
        }

        private bool ObtenerParametros(out double xMin, out double xMax, out double yMin, out double yMax)
        {
            xMin = yMin = -10;
            xMax = yMax = 10;

            if (!double.TryParse(txtXMin.Text, out xMin) || !double.TryParse(txtXMax.Text, out xMax) ||
                !double.TryParse(txtYMin.Text, out yMin) || !double.TryParse(txtYMax.Text, out yMax))
            {
                lblError.Text = "⚠ Coordenadas de ventana de recorte inválidas.";
                return false;
            }

            if (xMin >= xMax || yMin >= yMax)
            {
                lblError.Text = "⚠ Ventana inválida (Mín >= Máx).";
                return false;
            }

            lblError.Text = "";
            return true;
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!ObtenerParametros(out double xMin, out double xMax, out double yMin, out double yMax)) return;

            if (_poligonoOriginal.Count < 3)
            {
                lblError.Text = "⚠ Ingrese al menos 3 vértices en el lienzo para recortar.";
                return;
            }

            _cancelar = true;
            System.Threading.Thread.Sleep(50);
            _cancelar = false;

            if (cmbAlgoritmo.SelectedIndex == 2)
            {
                pasosCalculados = _cyrus.CalcularRecorte(_poligonoOriginal, xMin, xMax, yMin, yMax);
            }
            else if (cmbAlgoritmo.SelectedIndex == 1)
            {
                pasosCalculados = _weiler.CalcularRecorte(_poligonoOriginal, xMin, xMax, yMin, yMax);
            }
            else
            {
                pasosCalculados = _sutherland.CalcularRecorte(_poligonoOriginal, xMin, xMax, yMin, yMax);
            }

            _pasoActual = pasosCalculados.Count - 1;
            ActualizarTabla();
            picCanvas.Invalidate();
        }

        private async void btnPasoPaso_Click(object sender, EventArgs e)
        {
            if (_animando) { _cancelar = true; return; }
            if (!ObtenerParametros(out double xMin, out double xMax, out double yMin, out double yMax)) return;

            if (_poligonoOriginal.Count < 3)
            {
                lblError.Text = "⚠ Ingrese al menos 3 vértices en el lienzo.";
                return;
            }

            if (cmbAlgoritmo.SelectedIndex == 2)
            {
                pasosCalculados = _cyrus.CalcularRecorte(_poligonoOriginal, xMin, xMax, yMin, yMax);
            }
            else if (cmbAlgoritmo.SelectedIndex == 1)
            {
                pasosCalculados = _weiler.CalcularRecorte(_poligonoOriginal, xMin, xMax, yMin, yMax);
            }
            else
            {
                pasosCalculados = _sutherland.CalcularRecorte(_poligonoOriginal, xMin, xMax, yMin, yMax);
            }

            _pasoActual = 0;
            tabla.DataSource = null;
            lblError.Text = "";

            _animando = true;
            _cancelar = false;
            btnPasoPaso.Text = "⏹  Detener";
            btnPasoPaso.BackColor = Color.FromArgb(180, 60, 60);

            int delay = trkVelocidad.Value;

            for (int i = 0; i < pasosCalculados.Count && !_cancelar; i++)
            {
                _pasoActual = i;
                ActualizarFilaTabla(i);
                picCanvas.Invalidate();
                await Task.Delay(Math.Max(100, delay * 5));
            }

            if (!_cancelar)
            {
                _pasoActual = pasosCalculados.Count - 1;
                ActualizarTabla();
                picCanvas.Invalidate();
            }

            _animando = false;
            _cancelar = false;
            btnPasoPaso.Text = "⏭  Paso a Paso";
            btnPasoPaso.BackColor = Color.FromArgb(0, 172, 172);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void trkVelocidad_Scroll(object sender, EventArgs e)
        {
            lblVelValor.Text = trkVelocidad.Value + "ms";
        }

        private void ActualizarTabla()
        {
            tabla.DataSource = null;
            if (pasosCalculados == null || pasosCalculados.Count == 0) return;

            var list = new List<object>();
            foreach (var p in pasosCalculados)
            {
                list.Add(new
                {
                    Paso = p.NumeroPaso,
                    Borde = p.BordeClip,
                    Vértices = p.Vertices?.Count ?? 0,
                    Explicación = p.Explicacion.Replace("\r\n", " | ")
                });
            }
            tabla.DataSource = list;

            if (tabla.Columns.Count > 0)
            {
                tabla.Columns[tabla.Columns.Count - 1].Width = 350;
            }
        }

        private void ActualizarFilaTabla(int index)
        {
            tabla.DataSource = null;
            if (pasosCalculados == null || pasosCalculados.Count == 0 || index < 0) return;

            var list = new List<object>();
            for (int i = 0; i <= index; i++)
            {
                var p = pasosCalculados[i];
                list.Add(new
                {
                    Paso = p.NumeroPaso,
                    Borde = p.BordeClip,
                    Vértices = p.Vertices?.Count ?? 0,
                    Explicación = p.Explicacion.Replace("\r\n", " | ")
                });
            }
            tabla.DataSource = list;

            if (tabla.Columns.Count > 0)
            {
                tabla.Columns[tabla.Columns.Count - 1].Width = 350;
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            GraficadorBase.DibujarCuadricula(g, picCanvas.Width, picCanvas.Height, tamanoPixel);
            GraficadorBase.DibujarEjes(g, picCanvas.Width, picCanvas.Height, tamanoPixel);

            if (double.TryParse(txtXMin.Text, out double xMin) && double.TryParse(txtXMax.Text, out double xMax) &&
                double.TryParse(txtYMin.Text, out double yMin) && double.TryParse(txtYMax.Text, out double yMax))
            {
                GraficadorBase.DibujarRegionesRecorte(g, (int)xMin, (int)xMax, (int)yMin, (int)yMax, tamanoPixel, picCanvas.Width, picCanvas.Height);
            }

            // Dibujar el polígono original en tono gris
            if (_poligonoOriginal.Count >= 2)
            {
                using (Pen penOrig = new Pen(Color.FromArgb(120, 120, 120, 120), 2f))
                {
                    for (int i = 0; i < _poligonoOriginal.Count - 1; i++)
                    {
                        Point p0 = GraficadorBase.CartesianoAPantalla((int)_poligonoOriginal[i].X, (int)_poligonoOriginal[i].Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
                        Point p1 = GraficadorBase.CartesianoAPantalla((int)_poligonoOriginal[i + 1].X, (int)_poligonoOriginal[i + 1].Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
                        p0 = new Point(p0.X + tamanoPixel / 2, p0.Y + tamanoPixel / 2);
                        p1 = new Point(p1.X + tamanoPixel / 2, p1.Y + tamanoPixel / 2);
                        g.DrawLine(penOrig, p0, p1);
                    }

                    // Línea de cierre proyectada
                    Point pLast = GraficadorBase.CartesianoAPantalla((int)_poligonoOriginal[_poligonoOriginal.Count - 1].X, (int)_poligonoOriginal[_poligonoOriginal.Count - 1].Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
                    Point pFirst = GraficadorBase.CartesianoAPantalla((int)_poligonoOriginal[0].X, (int)_poligonoOriginal[0].Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
                    pLast = new Point(pLast.X + tamanoPixel / 2, pLast.Y + tamanoPixel / 2);
                    pFirst = new Point(pFirst.X + tamanoPixel / 2, pFirst.Y + tamanoPixel / 2);

                    using (Pen penClose = new Pen(Color.FromArgb(120, 0, 80, 80), 1.5f))
                    {
                        penClose.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        g.DrawLine(penClose, pLast, pFirst);
                    }
                }
            }

            foreach (var pt in _poligonoOriginal)
            {
                GraficadorBase.DibujarPixel(g, Brushes.Gray, (int)pt.X, (int)pt.Y, tamanoPixel, picCanvas.Width, picCanvas.Height);
            }

            if (pasosCalculados != null && pasosCalculados.Count > 0 && _pasoActual >= 0 && _pasoActual < pasosCalculados.Count)
            {
                var paso = pasosCalculados[_pasoActual];
                txtExplicacion.Text = $"Paso {paso.NumeroPaso} - Arista: {paso.BordeClip}\r\n━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n{paso.Explicacion}";

                if (paso.Vertices != null && paso.Vertices.Count >= 2)
                {
                    var ptsPantalla = new List<Point>();
                    foreach (var pt in paso.Vertices)
                    {
                        Point p = GraficadorBase.CartesianoAPantalla((int)Math.Round(pt.X), (int)Math.Round(pt.Y), picCanvas.Width, picCanvas.Height, tamanoPixel);
                        ptsPantalla.Add(new Point(p.X + tamanoPixel / 2, p.Y + tamanoPixel / 2));
                    }

                    using (SolidBrush brushFill = new SolidBrush(Color.FromArgb(40, 0, 128, 128)))
                    {
                        g.FillPolygon(brushFill, ptsPantalla.ToArray());
                    }

                    using (Pen penPoly = new Pen(paso.Terminado && paso.Aceptada ? Color.Green : Color.Orange, 3f))
                    {
                        g.DrawPolygon(penPoly, ptsPantalla.ToArray());
                    }

                    foreach (var pt in paso.Vertices)
                    {
                        GraficadorBase.DibujarPixelResaltado(g, Brushes.Teal, (int)Math.Round(pt.X), (int)Math.Round(pt.Y), tamanoPixel, picCanvas.Width, picCanvas.Height);
                    }
                }
            }
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_animando) return;

            Point cart = GraficadorBase.PantallaACartesiano(e.X, e.Y, picCanvas.Width, picCanvas.Height, tamanoPixel);

            if (e.Button == MouseButtons.Left)
            {
                _poligonoOriginal.Add(new PointF(cart.X, cart.Y));
            }
            else if (e.Button == MouseButtons.Right)
            {
                _poligonoOriginal.Clear();
                pasosCalculados.Clear();
                _pasoActual = -1;
                tabla.DataSource = null;
            }
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point cart = GraficadorBase.PantallaACartesiano(e.X, e.Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
            lblCoordenadas.Text = $"Cursor: ({cart.X}, {cart.Y})  |  Vértices Polígono: {_poligonoOriginal.Count} (Clic Izq: agregar, Clic Der: limpiar)";
        }
    }
}
