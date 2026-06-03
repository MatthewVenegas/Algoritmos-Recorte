using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmosDeDiscretizacion.Algoritmos.Lineas;
using AlgoritmosDeDiscretizacion.Modelos;
using AlgoritmosDeDiscretizacion.Utilidades;

namespace AlgoritmosDeDiscretizacion
{
    public partial class FrmLineas : Form
    {
        // ── Algoritmos ────────────────────────────────────────────────────
        private readonly AlgoritmoDDA           _dda           = new AlgoritmoDDA();
        private readonly AlgoritmoBresenhamLinea _bresenham     = new AlgoritmoBresenhamLinea();
        private readonly AlgoritmoPuntoMedioLinea _puntoMedio   = new AlgoritmoPuntoMedioLinea();

        // ── Estado ────────────────────────────────────────────────────────
        private List<PuntoLinea> _puntos     = new List<PuntoLinea>();
        private int _pasoActual              = -1;   // -1 = mostrar todo
        private int _tamPixel                = 20;
        private bool _animando               = false;
        private bool _cancelar               = false;

        public FrmLineas()
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
                case 0: txtExplicacion.Text = _dda.ObtenerExplicacion(); break;
                case 1: txtExplicacion.Text = _bresenham.ObtenerExplicacion(); break;
                case 2: txtExplicacion.Text = _puntoMedio.ObtenerExplicacion(); break;
            }
        }

        // ── Graficar (todos los puntos a la vez) ──────────────────────────
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!ObtenerParametros(out int x0, out int y0, out int x1, out int y1)) return;
            _cancelar = true;   // Cancelar cualquier animación en curso
            System.Threading.Thread.Sleep(50);
            _cancelar = false;

            _puntos = CalcularPuntos(x0, y0, x1, y1);
            _pasoActual = -1;   // Mostrar todos
            ActualizarTabla();
            ActualizarEcuacion(x0, y0, x1, y1);
            picCanvas.Invalidate();
        }

        // ── Paso a paso (animación) ───────────────────────────────────────
        private async void btnPasoPaso_Click(object sender, EventArgs e)
        {
            if (_animando) { _cancelar = true; return; }
            if (!ObtenerParametros(out int x0, out int y0, out int x1, out int y1)) return;

            _puntos = CalcularPuntos(x0, y0, x1, y1);
            _pasoActual = 0;
            ActualizarEcuacion(x0, y0, x1, y1);
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
                // Resaltar fila en tabla
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
            txtX0.Text = "0"; txtY0.Text = "0";
            txtX1.Text = "5"; txtY1.Text = "3";
            lblEcuacion.Text = "Ecuación de la recta: —";
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
        private bool ObtenerParametros(out int x0, out int y0, out int x1, out int y1)
        {
            x0 = y0 = x1 = y1 = 0;
            if (!int.TryParse(txtX0.Text, out x0) || !int.TryParse(txtY0.Text, out y0) ||
                !int.TryParse(txtX1.Text, out x1) || !int.TryParse(txtY1.Text, out y1))
            {
                lblError.Text = "⚠ Por favor ingrese valores enteros válidos.";
                return false;
            }
            if (x0 == x1 && y0 == y1)
            {
                lblError.Text = "⚠ Los puntos de inicio y fin no pueden ser iguales.";
                return false;
            }
            lblError.Text = "";
            return true;
        }

        // ── Delegar al algoritmo seleccionado ────────────────────────────
        private List<PuntoLinea> CalcularPuntos(int x0, int y0, int x1, int y1)
        {
            switch (cmbAlgoritmo.SelectedIndex)
            {
                case 1: return _bresenham.CalcularPuntos(x0, y0, x1, y1);
                case 2: return _puntoMedio.CalcularPuntos(x0, y0, x1, y1);
                default: return _dda.CalcularPuntos(x0, y0, x1, y1);
            }
        }

        // ── Ecuación de la recta ─────────────────────────────────────────
        private void ActualizarEcuacion(int x0, int y0, int x1, int y1)
        {
            if (x0 == x1)
            {
                lblEcuacion.Text = $"Recta vertical: x = {x0}";
                return;
            }
            double m = _dda.CalcularPendiente(x0, y0, x1, y1);
            double b = _dda.CalcularIntercepto(x0, y0, m);
            string signo = b < 0 ? "-" : "+";
            lblEcuacion.Text = $"y = {m:F2}x {signo} {Math.Abs(b):F2}  |  Δx={x1-x0}, Δy={y1-y0}";
        }

        // ── Tabla ─────────────────────────────────────────────────────────
        private void ActualizarTabla()
        {
            tabla.DataSource = null;
            tabla.DataSource = _puntos;
            if (tabla.Columns.Count == 0) return;
            if (tabla.Columns.Contains("Paso"))     tabla.Columns["Paso"].HeaderText = "Paso";
            if (tabla.Columns.Contains("X"))        tabla.Columns["X"].HeaderText = "x real";
            if (tabla.Columns.Contains("Y"))        tabla.Columns["Y"].HeaderText = "y real";
            if (tabla.Columns.Contains("XPixel"))   tabla.Columns["XPixel"].HeaderText = "x píxel";
            if (tabla.Columns.Contains("YPixel"))   tabla.Columns["YPixel"].HeaderText = "y píxel";
            if (tabla.Columns.Contains("Decision")) tabla.Columns["Decision"].HeaderText = "Decisión";
            if (tabla.Columns.Contains("X"))        tabla.Columns["X"].DefaultCellStyle.Format = "0.00";
            if (tabla.Columns.Contains("Y"))        tabla.Columns["Y"].DefaultCellStyle.Format = "0.00";
        }

        private void ActualizarFilaTabla(int index)
        {
            // Agregar fila progresivamente
            if (tabla.DataSource != null) tabla.DataSource = null;
            // Mostrar hasta el paso actual
            var subset = _puntos.GetRange(0, index + 1);
            tabla.DataSource = subset;
            if (tabla.Columns.Count > 0)
            {
                if (tabla.Columns.Contains("X")) tabla.Columns["X"].DefaultCellStyle.Format = "0.00";
                if (tabla.Columns.Contains("Y")) tabla.Columns["Y"].DefaultCellStyle.Format = "0.00";
            }
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

            // Línea real (punteada roja)
            var primero = _puntos[0];
            var ultimo  = _pasoActual >= 0 ? _puntos[_pasoActual] : _puntos[_puntos.Count - 1];
            GraficadorBase.DibujarLineaReal(g,
                primero.XPixel, primero.YPixel,
                _puntos[_puntos.Count - 1].XPixel, _puntos[_puntos.Count - 1].YPixel,
                _tamPixel, picCanvas.Width, picCanvas.Height);

            int limite = _pasoActual >= 0 ? _pasoActual : _puntos.Count - 1;

            using (SolidBrush brPixel   = new SolidBrush(Color.FromArgb(0, 128, 128)))
            using (SolidBrush brActual  = new SolidBrush(Color.FromArgb(255, 200, 0)))
            {
                for (int i = 0; i <= limite; i++)
                {
                    var p = _puntos[i];
                    if (i == limite && _pasoActual >= 0)
                        GraficadorBase.DibujarPixelResaltado(g, brActual, p.XPixel, p.YPixel,
                            _tamPixel, picCanvas.Width, picCanvas.Height);
                    else
                        GraficadorBase.DibujarPixel(g, brPixel, p.XPixel, p.YPixel,
                            _tamPixel, picCanvas.Width, picCanvas.Height);
                }
            }

            // Etiquetas del pixel actual
            if (_pasoActual >= 0 && _pasoActual < _puntos.Count)
            {
                var pc = _puntos[_pasoActual];
                var pt = GraficadorBase.CartesianoAPantalla(pc.XPixel, pc.YPixel,
                    picCanvas.Width, picCanvas.Height, _tamPixel);
                using (Font fnt = new Font("Segoe UI", 7.5f, FontStyle.Bold))
                using (SolidBrush br = new SolidBrush(Color.FromArgb(180, 60, 0)))
                    g.DrawString($"k={pc.Paso} ({pc.XPixel},{pc.YPixel})", fnt, br,
                        pt.X + _tamPixel + 2, pt.Y);
            }
        }

        // ── Coordenadas del cursor ────────────────────────────────────────
        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var cart = GraficadorBase.PantallaACartesiano(e.X, e.Y,
                picCanvas.Width, picCanvas.Height, _tamPixel);
            lblCoordenadas.Text = $"Cursor: ({cart.X}, {cart.Y})";
        }

        private void FrmLineas_Load(object sender, EventArgs e)
        {

        }
    }
}
