using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmosDeDiscretizacion.Algoritmos.Circulos;
using AlgoritmosDeDiscretizacion.Modelos;
using AlgoritmosDeDiscretizacion.Utilidades;

namespace AlgoritmosDeDiscretizacion
{
    public partial class FrmCirculos : Form
    {
        // ── Algoritmos ────────────────────────────────────────────────────
        private readonly AlgoritmoCirculoMidPoint       _midPoint      = new AlgoritmoCirculoMidPoint();
        private readonly AlgoritmoCirculoBresenham     _bresenham     = new AlgoritmoCirculoBresenham();
        private readonly AlgoritmoCirculoTrigonometrico _trig          = new AlgoritmoCirculoTrigonometrico();

        // ── Estado ────────────────────────────────────────────────────────
        private List<PuntoCirculoAlg> _puntos = new List<PuntoCirculoAlg>();
        private int _pasoActual               = -1;   // -1 = mostrar todo
        private int _tamPixel                 = 20;
        private bool _animando                = false;
        private bool _cancelar                = false;

        public FrmCirculos()
        {
            InitializeComponent();
            GraficadorBase.EstilizarTabla(tabla);
            ActualizarExplicacion();
        }

        // ── Cambio de algoritmo ───────────────────────────────────────────
        private void cmbAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarExplicacion();
            Limpiar();
        }

        private void ActualizarExplicacion()
        {
            switch (cmbAlgoritmo.SelectedIndex)
            {
                case 0: txtExplicacion.Text = _midPoint.ObtenerExplicacion(); break;
                case 1: txtExplicacion.Text = _bresenham.ObtenerExplicacion(); break;
                case 2: txtExplicacion.Text = _trig.ObtenerExplicacion(); break;
            }
        }

        // ── Graficar (todos los puntos a la vez) ──────────────────────────
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!ObtenerParametros(out int xc, out int yc, out int r)) return;
            _cancelar = true;   // Cancelar cualquier animación en curso
            System.Threading.Thread.Sleep(50);
            _cancelar = false;

            _puntos = CalcularPuntos(xc, yc, r);
            _pasoActual = -1;   // Mostrar todos
            ActualizarTabla();
            ActualizarInfo(xc, yc, r);
            picCanvas.Invalidate();
        }

        // ── Paso a paso (animación) ───────────────────────────────────────
        private async void btnPasoPaso_Click(object sender, EventArgs e)
        {
            if (_animando) { _cancelar = true; return; }
            if (!ObtenerParametros(out int xc, out int yc, out int r)) return;

            _puntos = CalcularPuntos(xc, yc, r);
            _pasoActual = 0;
            ActualizarInfo(xc, yc, r);
            tabla.DataSource = null;
            lblError.Text = "";

            _animando = true;
            _cancelar = false;
            btnPasoPaso.Text = "⏹  Detener";
            btnPasoPaso.BackColor = Color.FromArgb(180, 60, 60);

            int delay = trkVelocidad.Value;
            for (int i = 0; i < _puntos.Count && !_cancelar; i++)
            {
                _pasoActual = i;
                ActualizarFilaTabla(i);
                picCanvas.Invalidate();
                await Task.Delay(Math.Max(1, delay));
            }

            if (!_cancelar)
            {
                _pasoActual = -1;  // Mostrar todo al final
                ActualizarTabla();
                picCanvas.Invalidate();
            }

            _animando = false;
            _cancelar = false;
            btnPasoPaso.Text = "⏭  Paso a Paso";
            btnPasoPaso.BackColor = Color.FromArgb(0, 172, 172);
        }

        // ── Limpiar ───────────────────────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            _cancelar = true;
            Limpiar();
        }

        private void Limpiar()
        {
            txtXc.Text = "0"; txtYc.Text = "0";
            txtR.Text = "5";
            lblInfo.Text = "Círculo: x²+y²=r²  —  Parámetros: —";
            lblError.Text = "";
            _puntos.Clear();
            _pasoActual = -1;
            tabla.DataSource = null;
            picCanvas.Invalidate();
        }

        // ── Velocidad ─────────────────────────────────────────────────────
        private void trkVelocidad_Scroll(object sender, EventArgs e)
        {
            lblVelValor.Text = trkVelocidad.Value + "ms";
        }

        // ── Validación de parámetros ──────────────────────────────────────
        private bool ObtenerParametros(out int xc, out int yc, out int r)
        {
            xc = yc = r = 0;
            if (!int.TryParse(txtXc.Text, out xc) || !int.TryParse(txtYc.Text, out yc) || !int.TryParse(txtR.Text, out r))
            {
                lblError.Text = "⚠ Por favor ingrese valores enteros válidos.";
                return false;
            }
            if (r <= 0)
            {
                lblError.Text = "⚠ El radio r debe ser mayor que 0.";
                return false;
            }
            lblError.Text = "";
            return true;
        }

        // ── Delegar al algoritmo seleccionado ────────────────────────────
        private List<PuntoCirculoAlg> CalcularPuntos(int xc, int yc, int r)
        {
            switch (cmbAlgoritmo.SelectedIndex)
            {
                case 1: return _bresenham.CalcularPuntos(xc, yc, r);
                case 2: return _trig.CalcularPuntos(xc, yc, r);
                default: return _midPoint.CalcularPuntos(xc, yc, r);
            }
        }

        // ── Información del círculo ──────────────────────────────────────
        private void ActualizarInfo(int xc, int yc, int r)
        {
            string signX = xc < 0 ? "+" : "-";
            string signY = yc < 0 ? "+" : "-";
            string strXc = xc == 0 ? "x²" : $"(x {signX} {Math.Abs(xc)})²";
            string strYc = yc == 0 ? "y²" : $"(y {signY} {Math.Abs(yc)})²";

            lblInfo.Text = $"{strXc} + {strYc} = {r * r} (r={r})";
        }

        // ── Tabla ─────────────────────────────────────────────────────────
        private void ActualizarTabla()
        {
            tabla.DataSource = null;
            tabla.DataSource = _puntos;
            if (tabla.Columns.Count == 0) return;
            if (tabla.Columns.Contains("Paso"))     tabla.Columns["Paso"].HeaderText = "Paso";
            if (tabla.Columns.Contains("X"))        tabla.Columns["X"].HeaderText = "x píxel";
            if (tabla.Columns.Contains("Y"))        tabla.Columns["Y"].HeaderText = "y píxel";
            if (tabla.Columns.Contains("P"))        tabla.Columns["P"].HeaderText = "Parámetro";
            if (tabla.Columns.Contains("Decision")) tabla.Columns["Decision"].HeaderText = "Decisión";
            if (tabla.Columns.Contains("Octante"))  tabla.Columns["Octante"].HeaderText = "Detalle";
        }

        private void ActualizarFilaTabla(int index)
        {
            if (tabla.DataSource != null) tabla.DataSource = null;
            var subset = _puntos.GetRange(0, index + 1);
            tabla.DataSource = subset;
            if (tabla.Rows.Count > 0)
                tabla.FirstDisplayedScrollingRowIndex = tabla.Rows.Count - 1;
        }

        // ── Paint ─────────────────────────────────────────────────────────
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            GraficadorBase.DibujarCuadricula(g, picCanvas.Width, picCanvas.Height, _tamPixel);
            GraficadorBase.DibujarEjes(g, picCanvas.Width, picCanvas.Height, _tamPixel);

            if (_puntos == null || _puntos.Count == 0) return;
            if (!ObtenerParametros(out int xc, out int yc, out int r)) return;

            // Dibujar círculo matemático real (línea roja continua de guía)
            using (Pen penReal = new Pen(Color.FromArgb(200, 255, 0, 0), 1.5f))
            {
                penReal.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                // xc, yc en coordenadas cartesianas a coordenadas de pantalla
                var centroPt = GraficadorBase.CartesianoAPantalla(xc, yc, picCanvas.Width, picCanvas.Height, _tamPixel);
                // El radio en pixeles reales de pantalla es r * _tamPixel
                int rPx = r * _tamPixel;
                g.DrawEllipse(penReal, centroPt.X - rPx + _tamPixel / 2.0f, centroPt.Y - rPx + _tamPixel / 2.0f, rPx * 2, rPx * 2);
            }

            int limite = _pasoActual >= 0 ? _pasoActual : _puntos.Count - 1;

            using (SolidBrush brPixel   = new SolidBrush(Color.FromArgb(0, 128, 128)))
            using (SolidBrush brActual  = new SolidBrush(Color.FromArgb(255, 200, 0)))
            {
                for (int i = 0; i <= limite; i++)
                {
                    var p = _puntos[i];
                    bool esUltimo = (i == limite && _pasoActual >= 0);
                    var brush = esUltimo ? brActual : brPixel;

                    if (cmbAlgoritmo.SelectedIndex == 2)
                    {
                        // Algoritmo Trigonométrico: el punto p.X y p.Y ya es relativo al origen de la discretización
                        // y cubre 360 grados, pero el algoritmo almacena el desplazamiento xPixel - xc, yPixel - yc
                        GraficadorBase.DibujarPixel(g, brush, xc + p.X, yc + p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                    }
                    else
                    {
                        // Punto Medio o Bresenham (8 octantes de simetría)
                        if (esUltimo)
                        {
                            // En el paso a paso, podemos resaltar los 8 puntos que se pintan simultáneamente en este paso
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc + p.X, yc + p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc - p.X, yc + p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc + p.X, yc - p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc - p.X, yc - p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc + p.Y, yc + p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc - p.Y, yc + p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc + p.Y, yc - p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixelResaltado(g, brush, xc - p.Y, yc - p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                        }
                        else
                        {
                            GraficadorBase.DibujarPixel(g, brush, xc + p.X, yc + p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc - p.X, yc + p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc + p.X, yc - p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc - p.X, yc - p.Y, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc + p.Y, yc + p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc - p.Y, yc + p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc + p.Y, yc - p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                            GraficadorBase.DibujarPixel(g, brush, xc - p.Y, yc - p.X, _tamPixel, picCanvas.Width, picCanvas.Height);
                        }
                    }
                }
            }

            // Etiquetas del pixel actual
            if (_pasoActual >= 0 && _pasoActual < _puntos.Count)
            {
                var pc = _puntos[_pasoActual];
                var pt = GraficadorBase.CartesianoAPantalla(xc + pc.X, yc + pc.Y, picCanvas.Width, picCanvas.Height, _tamPixel);
                using (Font fnt = new Font("Segoe UI", 7.5f, FontStyle.Bold))
                using (SolidBrush br = new SolidBrush(Color.FromArgb(180, 60, 0)))
                    g.DrawString($"k={pc.Paso} ({xc + pc.X},{yc + pc.Y})", fnt, br, pt.X + _tamPixel + 2, pt.Y);
            }
        }

        // ── Coordenadas del cursor ────────────────────────────────────────
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var cart = GraficadorBase.PantallaACartesiano(e.X, e.Y, picCanvas.Width, picCanvas.Height, _tamPixel);
            lblCoordenadas.Text = $"Cursor: ({cart.X}, {cart.Y})";
        }

        private void FrmCirculos_Load(object sender, EventArgs e)
        {

        }
    }
}
