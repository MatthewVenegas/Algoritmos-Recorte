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
    public partial class FrmRecorteLineas : Form
    {
        private readonly AlgoritmoCohenSutherland _cohen = new AlgoritmoCohenSutherland();
        private readonly AlgoritmoLiangBarsky _liang = new AlgoritmoLiangBarsky();
        private readonly AlgoritmoSubdivisionPuntoMedio _subdivision = new AlgoritmoSubdivisionPuntoMedio();

        private List<PasoRecorte> pasosCalculados = new List<PasoRecorte>();
        private int _pasoActual = -1;
        private int tamanoPixel = 20;
        private Point? _lineStartPoint = null;
        private Point _currentMouseCartesian = Point.Empty;
        private bool _animando = false;
        private bool _cancelar = false;

        public FrmRecorteLineas()
        {
            InitializeComponent();
            GraficadorBase.EstilizarTabla(tabla);

            this.Load += FrmRecorteLineas_Load;
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

            txtX0.TextChanged += (s, e) => picCanvas.Invalidate();
            txtY0.TextChanged += (s, e) => picCanvas.Invalidate();
            txtX1.TextChanged += (s, e) => picCanvas.Invalidate();
            txtY1.TextChanged += (s, e) => picCanvas.Invalidate();
            txtXMin.TextChanged += (s, e) => picCanvas.Invalidate();
            txtXMax.TextChanged += (s, e) => picCanvas.Invalidate();
            txtYMin.TextChanged += (s, e) => picCanvas.Invalidate();
            txtYMax.TextChanged += (s, e) => picCanvas.Invalidate();
        }

        private void FrmRecorteLineas_Load(object sender, EventArgs e)
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
                case 0: txtExplicacion.Text = _cohen.ObtenerExplicacion(); break;
                case 1: txtExplicacion.Text = _liang.ObtenerExplicacion(); break;
                case 2: txtExplicacion.Text = _subdivision.ObtenerExplicacion(); break;
            }
        }

        private void LimpiarLienzoYPasos()
        {
            _cancelar = true;
            _pasoActual = -1;
            pasosCalculados.Clear();
            _lineStartPoint = null;
            tabla.DataSource = null;
            lblError.Text = "";
            lblEcuacion.Text = "Modo Línea: Clic izquierdo coloca inicio, 2do clic coloca fin. Clic derecho limpia.";
            picCanvas.Invalidate();
        }

        private void Limpiar()
        {
            _cancelar = true;
            _animando = false;

            txtX0.Text = "-12"; txtY0.Text = "-8";
            txtX1.Text = "15"; txtY1.Text = "12";
            txtXMin.Text = "-10"; txtXMax.Text = "10";
            txtYMin.Text = "-10"; txtYMax.Text = "10";
            lblError.Text = "";

            pasosCalculados.Clear();
            _lineStartPoint = null;
            _pasoActual = -1;
            tabla.DataSource = null;
            lblEcuacion.Text = "Modo Línea: Clic izquierdo coloca inicio, 2do clic coloca fin. Clic derecho limpia.";

            ActualizarExplicacion();
            picCanvas.Invalidate();
        }

        private bool ObtenerParametros(out double x0, out double y0, out double x1, out double y1, out double xMin, out double xMax, out double yMin, out double yMax)
        {
            x0 = y0 = x1 = y1 = 0;
            xMin = yMin = -10;
            xMax = yMax = 10;

            if (!double.TryParse(txtX0.Text, out x0) || !double.TryParse(txtY0.Text, out y0) ||
                !double.TryParse(txtX1.Text, out x1) || !double.TryParse(txtY1.Text, out y1))
            {
                lblError.Text = "⚠ Ingrese o dibuje coordenadas de línea.";
                return false;
            }

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
            if (!ObtenerParametros(out double x0, out double y0, out double x1, out double y1, out double xMin, out double xMax, out double yMin, out double yMax)) return;

            _cancelar = true;
            System.Threading.Thread.Sleep(50);
            _cancelar = false;

            if (cmbAlgoritmo.SelectedIndex == 2)
            {
                pasosCalculados = _subdivision.CalcularRecorte(x0, y0, x1, y1, xMin, xMax, yMin, yMax);
            }
            else if (cmbAlgoritmo.SelectedIndex == 1)
            {
                pasosCalculados = _liang.CalcularRecorte(x0, y0, x1, y1, xMin, xMax, yMin, yMax);
            }
            else
            {
                pasosCalculados = _cohen.CalcularRecorte(x0, y0, x1, y1, xMin, xMax, yMin, yMax);
            }

            ActualizarEcuacion(x0, y0, x1, y1);
            _pasoActual = pasosCalculados.Count - 1;
            ActualizarTabla();
            picCanvas.Invalidate();
        }

        private async void btnPasoPaso_Click(object sender, EventArgs e)
        {
            if (_animando) { _cancelar = true; return; }
            if (!ObtenerParametros(out double x0, out double y0, out double x1, out double y1, out double xMin, out double xMax, out double yMin, out double yMax)) return;

            if (cmbAlgoritmo.SelectedIndex == 2)
            {
                pasosCalculados = _subdivision.CalcularRecorte(x0, y0, x1, y1, xMin, xMax, yMin, yMax);
            }
            else if (cmbAlgoritmo.SelectedIndex == 1)
            {
                pasosCalculados = _liang.CalcularRecorte(x0, y0, x1, y1, xMin, xMax, yMin, yMax);
            }
            else
            {
                pasosCalculados = _cohen.CalcularRecorte(x0, y0, x1, y1, xMin, xMax, yMin, yMax);
            }

            ActualizarEcuacion(x0, y0, x1, y1);
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

        private void ActualizarEcuacion(double x0, double y0, double x1, double y1)
        {
            double dx = x1 - x0;
            if (dx == 0)
            {
                lblEcuacion.Text = $"Recta vertical: x = {x0}";
                return;
            }
            double m = (y1 - y0) / dx;
            double b = y0 - m * x0;
            string signo = b < 0 ? "-" : "+";
            lblEcuacion.Text = $"y = {m:F2}x {signo} {Math.Abs(b):F2}  |  Δx={dx:F1}, Δy={y1-y0:F1}";
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
                    X0 = p.X0,
                    Y0 = p.Y0,
                    X1 = p.X1,
                    Y1 = p.Y1,
                    Cod0 = Convert.ToString(p.Codigo0, 2).PadLeft(4, '0'),
                    Cod1 = Convert.ToString(p.Codigo1, 2).PadLeft(4, '0'),
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
                    X0 = p.X0,
                    Y0 = p.Y0,
                    X1 = p.X1,
                    Y1 = p.Y1,
                    Cod0 = Convert.ToString(p.Codigo0, 2).PadLeft(4, '0'),
                    Cod1 = Convert.ToString(p.Codigo1, 2).PadLeft(4, '0'),
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

            double lx0 = 0, ly0 = 0, lx1 = 0, ly1 = 0;
            bool hasP0 = double.TryParse(txtX0.Text, out lx0) && double.TryParse(txtY0.Text, out ly0);
            bool hasP1 = double.TryParse(txtX1.Text, out lx1) && double.TryParse(txtY1.Text, out ly1);

            bool mostrandoPaso = pasosCalculados != null && pasosCalculados.Count > 0 && _pasoActual >= 0 && _pasoActual < pasosCalculados.Count;

            // 1. Dibujar línea original si ambos puntos están definidos (solo si NO estamos mostrando un paso de recorte)
            if (hasP0 && hasP1 && !mostrandoPaso)
            {
                GraficadorBase.DibujarLineaReal(g, (int)lx0, (int)ly0, (int)lx1, (int)ly1, tamanoPixel, picCanvas.Width, picCanvas.Height);
            }

            // 2. Dibujar línea elástica de previsualización (rubber-band)
            if (_lineStartPoint != null)
            {
                Point ptStart = GraficadorBase.CartesianoAPantalla(_lineStartPoint.Value.X, _lineStartPoint.Value.Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
                Point ptEnd = GraficadorBase.CartesianoAPantalla(_currentMouseCartesian.X, _currentMouseCartesian.Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
                ptStart = new Point(ptStart.X + tamanoPixel / 2, ptStart.Y + tamanoPixel / 2);
                ptEnd = new Point(ptEnd.X + tamanoPixel / 2, ptEnd.Y + tamanoPixel / 2);
                using (Pen penPreview = new Pen(Color.FromArgb(120, 120, 120), 2f))
                {
                    penPreview.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(penPreview, ptStart, ptEnd);
                }
            }

            // 3. Dibujar y etiquetar P0 original (solo si NO estamos mostrando un paso de recorte)
            if (hasP0 && !mostrandoPaso)
            {
                GraficadorBase.DibujarPixelResaltado(g, Brushes.Blue, (int)lx0, (int)ly0, tamanoPixel, picCanvas.Width, picCanvas.Height);
                Point pScreen = GraficadorBase.CartesianoAPantalla((int)lx0, (int)ly0, picCanvas.Width, picCanvas.Height, tamanoPixel);
                using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Blue))
                {
                    g.DrawString($"P0 ({lx0}, {ly0})", font, brush, pScreen.X + tamanoPixel + 2, pScreen.Y - 2);
                }
            }

            // 4. Dibujar y etiquetar P1 original (solo si NO estamos mostrando un paso de recorte)
            if (hasP1 && !mostrandoPaso)
            {
                GraficadorBase.DibujarPixelResaltado(g, Brushes.Red, (int)lx1, (int)ly1, tamanoPixel, picCanvas.Width, picCanvas.Height);
                Point pScreen = GraficadorBase.CartesianoAPantalla((int)lx1, (int)ly1, picCanvas.Width, picCanvas.Height, tamanoPixel);
                using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.Red))
                {
                    g.DrawString($"P1 ({lx1}, {ly1})", font, brush, pScreen.X + tamanoPixel + 2, pScreen.Y - 2);
                }
            }

            // 5. Dibujar paso a paso del recorte
            if (mostrandoPaso)
            {
                var paso = pasosCalculados[_pasoActual];
                txtExplicacion.Text = $"Paso {paso.NumeroPaso}:\r\n{paso.Explicacion}";

                if (paso.Terminado && !paso.Aceptada)
                {
                    Point p0 = GraficadorBase.CartesianoAPantalla((int)Math.Round(paso.X0), (int)Math.Round(paso.Y0), picCanvas.Width, picCanvas.Height, tamanoPixel);
                    Point p1 = GraficadorBase.CartesianoAPantalla((int)Math.Round(paso.X1), (int)Math.Round(paso.Y1), picCanvas.Width, picCanvas.Height, tamanoPixel);
                    p0 = new Point(p0.X + tamanoPixel / 2, p0.Y + tamanoPixel / 2);
                    p1 = new Point(p1.X + tamanoPixel / 2, p1.Y + tamanoPixel / 2);
                    using (Pen penRechazado = new Pen(Color.Red, 3f))
                    {
                        penRechazado.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                        g.DrawLine(penRechazado, p0, p1);
                    }
                }
                else
                {
                    Point p0 = GraficadorBase.CartesianoAPantalla((int)Math.Round(paso.X0), (int)Math.Round(paso.Y0), picCanvas.Width, picCanvas.Height, tamanoPixel);
                    Point p1 = GraficadorBase.CartesianoAPantalla((int)Math.Round(paso.X1), (int)Math.Round(paso.Y1), picCanvas.Width, picCanvas.Height, tamanoPixel);
                    p0 = new Point(p0.X + tamanoPixel / 2, p0.Y + tamanoPixel / 2);
                    p1 = new Point(p1.X + tamanoPixel / 2, p1.Y + tamanoPixel / 2);

                    using (Pen penLinea = new Pen(paso.Terminado ? Color.Green : Color.Orange, 3f))
                    {
                        g.DrawLine(penLinea, p0, p1);
                    }

                    GraficadorBase.DibujarPixelResaltado(g, Brushes.Blue, (int)Math.Round(paso.X0), (int)Math.Round(paso.Y0), tamanoPixel, picCanvas.Width, picCanvas.Height);
                    GraficadorBase.DibujarPixelResaltado(g, Brushes.Red, (int)Math.Round(paso.X1), (int)Math.Round(paso.Y1), tamanoPixel, picCanvas.Width, picCanvas.Height);

                    // Mostrar coordenadas recortadas en el lienzo
                    Point pScreen0 = GraficadorBase.CartesianoAPantalla((int)Math.Round(paso.X0), (int)Math.Round(paso.Y0), picCanvas.Width, picCanvas.Height, tamanoPixel);
                    Point pScreen1 = GraficadorBase.CartesianoAPantalla((int)Math.Round(paso.X1), (int)Math.Round(paso.Y1), picCanvas.Width, picCanvas.Height, tamanoPixel);
                    using (Font font = new Font("Segoe UI", 9F, FontStyle.Bold))
                    {
                        using (Brush brush = new SolidBrush(Color.Blue))
                        {
                            g.DrawString($"P0' ({paso.X0:F1}, {paso.Y0:F1})", font, brush, pScreen0.X + tamanoPixel + 2, pScreen0.Y - 2);
                        }
                        using (Brush brush = new SolidBrush(Color.Red))
                        {
                            g.DrawString($"P1' ({paso.X1:F1}, {paso.Y1:F1})", font, brush, pScreen1.X + tamanoPixel + 2, pScreen1.Y - 2);
                        }
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
                if (_lineStartPoint == null)
                {
                    _lineStartPoint = cart;
                    txtX0.Text = cart.X.ToString();
                    txtY0.Text = cart.Y.ToString();
                    txtX1.Clear();
                    txtY1.Clear();
                    pasosCalculados.Clear();
                    _pasoActual = -1;
                    tabla.DataSource = null;
                }
                else
                {
                    txtX1.Text = cart.X.ToString();
                    txtY1.Text = cart.Y.ToString();
                    _lineStartPoint = null;
                    pasosCalculados.Clear();
                    _pasoActual = -1;
                    tabla.DataSource = null;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                _lineStartPoint = null;
                txtX0.Clear(); txtY0.Clear();
                txtX1.Clear(); txtY1.Clear();
                pasosCalculados.Clear();
                _pasoActual = -1;
                tabla.DataSource = null;
            }
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point cart = GraficadorBase.PantallaACartesiano(e.X, e.Y, picCanvas.Width, picCanvas.Height, tamanoPixel);
            _currentMouseCartesian = cart;
            string lineState = _lineStartPoint == null ? "Esperando punto inicial" : $"Inicio: ({_lineStartPoint.Value.X}, {_lineStartPoint.Value.Y})";
            lblCoordenadas.Text = $"Cursor: ({cart.X}, {cart.Y})  |  Línea: {lineState} (Clic Izq: colocar, Clic Der: limpiar)";
            
            if (_lineStartPoint != null)
            {
                picCanvas.Invalidate();
            }
        }
    }
}
