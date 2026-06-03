using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlgoritmosDeDiscretizacion.Algoritmos.Relleno;

namespace AlgoritmosDeDiscretizacion
{
    public partial class FrmPixelEditor : Form
    {
        // ── Algoritmos de Relleno ─────────────────────────────────────────
        private readonly AlgoritmoFloodFill    _flood    = new AlgoritmoFloodFill();
        private readonly AlgoritmoBoundaryFill _boundary = new AlgoritmoBoundaryFill();
        private readonly AlgoritmoScanLine     _scanLine = new AlgoritmoScanLine();

        // ── Estado del Lienzo ─────────────────────────────────────────────
        private bool[,] _borde;
        private bool[,] _relleno;
        private int _ancho = 30;
        private int _alto = 25;

        private int _semillaX = -1;
        private int _semillaY = -1;

        private bool _isDrawing = false;
        private bool _cancelarRelleno = false;
        private bool _ejecutandoRelleno = false;

        public FrmPixelEditor()
        {
            InitializeComponent();
            RedimensionarLienzo();
            ActualizarExplicacion();
        }

        // ── Selección de Algoritmo ────────────────────────────────────────
        private void cmbAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarExplicacion();
            LimpiarLienzoCompleto();
        }

        private void ActualizarExplicacion()
        {
            switch (cmbAlgoritmo.SelectedIndex)
            {
                case 0: txtExplicacion.Text = _flood.ObtenerExplicacion(); break;
                case 1: txtExplicacion.Text = _boundary.ObtenerExplicacion(); break;
                case 2: txtExplicacion.Text = _scanLine.ObtenerExplicacion(); break;
            }
        }

        // ── Redimensionar Lienzo ──────────────────────────────────────────
        private void btnRedimensionar_Click(object sender, EventArgs e)
        {
            if (_ejecutandoRelleno) return;
            _ancho = (int)numAncho.Value;
            _alto = (int)numAlto.Value;
            RedimensionarLienzo();
        }

        private void RedimensionarLienzo()
        {
            _borde = new bool[_ancho, _alto];
            _relleno = new bool[_ancho, _alto];
            _semillaX = -1;
            _semillaY = -1;
            lblError.Text = "";
            ActualizarInfoLabel();
            picCanvas.Invalidate();
        }

        // ── Limpiar Lienzo ────────────────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (_ejecutandoRelleno)
            {
                _cancelarRelleno = true;
            }
            LimpiarLienzoCompleto();
        }

        private void LimpiarLienzoCompleto()
        {
            Array.Clear(_borde, 0, _borde.Length);
            Array.Clear(_relleno, 0, _relleno.Length);
            _semillaX = -1;
            _semillaY = -1;
            lblError.Text = "";
            ActualizarInfoLabel();
            picCanvas.Invalidate();
        }

        // ── TrkVelocidad ──────────────────────────────────────────────────
        private void trkVelocidad_Scroll(object sender, EventArgs e)
        {
            lblVelValor.Text = trkVelocidad.Value + "ms";
        }

        // ── Relleno Asíncrono e Interactivo ───────────────────────────────
        private async void btnRellenar_Click(object sender, EventArgs e)
        {
            if (_ejecutandoRelleno) return;

            // Validar parámetros según algoritmo
            int algoritmoIdx = cmbAlgoritmo.SelectedIndex;
            if (algoritmoIdx != 2) // Flood Fill o Boundary Fill requieren semilla
            {
                if (_semillaX < 0 || _semillaX >= _ancho || _semillaY < 0 || _semillaY >= _alto)
                {
                    lblError.Text = "⚠ Debe colocar una semilla en el lienzo para iniciar.";
                    return;
                }
                if (_borde[_semillaX, _semillaY])
                {
                    lblError.Text = "⚠ La semilla no puede estar sobre un píxel de borde.";
                    return;
                }
            }

            lblError.Text = "";
            _ejecutandoRelleno = true;
            _cancelarRelleno = false;
            
            // UI State
            btnRellenar.Enabled = false;
            btnRedimensionar.Enabled = false;
            cmbAlgoritmo.Enabled = false;
            grpModo.Enabled = false;

            // Limpiar relleno anterior
            Array.Clear(_relleno, 0, _relleno.Length);
            picCanvas.Invalidate();

            int delay = trkVelocidad.Value;

            try
            {
                if (algoritmoIdx == 0) // Flood Fill
                {
                    await _flood.EjecutarAsync(
                        _borde, _relleno,
                        _semillaX, _semillaY,
                        _ancho, _alto,
                        delay,
                        (x, y) => picCanvas.Invalidate(),
                        () => _cancelarRelleno
                    );
                }
                else if (algoritmoIdx == 1) // Boundary Fill
                {
                    await _boundary.EjecutarAsync(
                        _borde, _relleno,
                        _semillaX, _semillaY,
                        _ancho, _alto,
                        delay,
                        (x, y) => picCanvas.Invalidate(),
                        () => _cancelarRelleno
                    );
                }
                else // Scan Line
                {
                    await _scanLine.EjecutarAsync(
                        _borde, _relleno,
                        _ancho, _alto,
                        delay,
                        (x, y) => picCanvas.Invalidate(),
                        () => _cancelarRelleno
                    );
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"⚠ Error durante el relleno: {ex.Message}";
            }

            _ejecutandoRelleno = false;
            _cancelarRelleno = false;

            btnRellenar.Enabled = true;
            btnRedimensionar.Enabled = true;
            cmbAlgoritmo.Enabled = true;
            grpModo.Enabled = true;
            
            ActualizarInfoLabel();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (_ejecutandoRelleno)
            {
                _cancelarRelleno = true;
            }
        }

        // ── Paint del Lienzo ──────────────────────────────────────────────
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.FromArgb(248, 252, 252));

            int tamCell = Math.Min(picCanvas.Width / _ancho, picCanvas.Height / _alto);
            int gridW = _ancho * tamCell;
            int gridH = _alto * tamCell;
            int offsetRealX = (picCanvas.Width - gridW) / 2;
            int offsetRealY = (picCanvas.Height - gridH) / 2;

            // Píxeles
            using (SolidBrush brBorde = new SolidBrush(Color.FromArgb(45, 52, 54))) // Gris muy oscuro/negro
            using (SolidBrush brRelleno = new SolidBrush(Color.FromArgb(255, 140, 0))) // Naranja
            using (SolidBrush brVacio = new SolidBrush(Color.White))
            using (Pen penGrid = new Pen(Color.FromArgb(220, 235, 235), 1))
            {
                for (int x = 0; x < _ancho; x++)
                {
                    for (int y = 0; y < _alto; y++)
                    {
                        Rectangle rect = new Rectangle(offsetRealX + x * tamCell, offsetRealY + y * tamCell, tamCell, tamCell);
                        
                        if (_borde[x, y])
                            g.FillRectangle(brBorde, rect);
                        else if (_relleno[x, y])
                            g.FillRectangle(brRelleno, rect);
                        else
                            g.FillRectangle(brVacio, rect);

                        g.DrawRectangle(penGrid, rect);
                    }
                }
            }

            // Dibujar Semilla
            if (_semillaX >= 0 && _semillaX < _ancho && _semillaY >= 0 && _semillaY < _alto)
            {
                Rectangle rectSeed = new Rectangle(
                    offsetRealX + _semillaX * tamCell + tamCell / 4, 
                    offsetRealY + _semillaY * tamCell + tamCell / 4, 
                    tamCell / 2, 
                    tamCell / 2
                );

                using (SolidBrush brSeed = new SolidBrush(Color.FromArgb(235, 77, 75))) // Rojo vibrante
                {
                    g.FillEllipse(brSeed, rectSeed);
                }

                using (Pen pCross = new Pen(Color.White, 2f))
                {
                    g.DrawLine(pCross, offsetRealX + _semillaX * tamCell + tamCell / 2, offsetRealY + _semillaY * tamCell + 2,
                                      offsetRealX + _semillaX * tamCell + tamCell / 2, offsetRealY + (_semillaY + 1) * tamCell - 2);
                    g.DrawLine(pCross, offsetRealX + _semillaX * tamCell + 2, offsetRealY + _semillaY * tamCell + tamCell / 2,
                                      offsetRealX + (_semillaX + 1) * tamCell - 2, offsetRealY + _semillaY * tamCell + tamCell / 2);
                }
            }

            // Marco del lienzo
            using (Pen penBorder = new Pen(Color.FromArgb(0, 128, 128), 2))
            {
                g.DrawRectangle(penBorder, offsetRealX, offsetRealY, gridW, gridH);
            }
        }

        // ── Interacción con el Mouse ──────────────────────────────────────
        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (_ejecutandoRelleno) return;

            int tamCell = Math.Min(picCanvas.Width / _ancho, picCanvas.Height / _alto);
            int gridW = _ancho * tamCell;
            int gridH = _alto * tamCell;
            int offsetRealX = (picCanvas.Width - gridW) / 2;
            int offsetRealY = (picCanvas.Height - gridH) / 2;

            int x = (e.X - offsetRealX) / tamCell;
            int y = (e.Y - offsetRealY) / tamCell;

            if (x >= 0 && x < _ancho && y >= 0 && y < _alto)
            {
                // Click derecho coloca semilla en cualquier modo
                if (e.Button == MouseButtons.Right || rdbSemilla.Checked)
                {
                    if (!_borde[x, y])
                    {
                        _semillaX = x;
                        _semillaY = y;
                        _relleno[x, y] = false;
                        lblError.Text = "";
                        picCanvas.Invalidate();
                        ActualizarInfoLabel();
                    }
                }
                else if (rdbDibujar.Checked && e.Button == MouseButtons.Left)
                {
                    _isDrawing = true;
                    _borde[x, y] = true;
                    _relleno[x, y] = false;
                    if (_semillaX == x && _semillaY == y) { _semillaX = -1; _semillaY = -1; }
                    picCanvas.Invalidate();
                }
                else if (rdbBorrar.Checked && e.Button == MouseButtons.Left)
                {
                    _isDrawing = true;
                    _borde[x, y] = false;
                    _relleno[x, y] = false;
                    picCanvas.Invalidate();
                }
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            int tamCell = Math.Min(picCanvas.Width / _ancho, picCanvas.Height / _alto);
            int gridW = _ancho * tamCell;
            int gridH = _alto * tamCell;
            int offsetRealX = (picCanvas.Width - gridW) / 2;
            int offsetRealY = (picCanvas.Height - gridH) / 2;

            int x = (e.X - offsetRealX) / tamCell;
            int y = (e.Y - offsetRealY) / tamCell;

            if (x >= 0 && x < _ancho && y >= 0 && y < _alto)
            {
                string estado = _borde[x, y] ? "Borde (Muro)" : (_relleno[x, y] ? "Rellenado" : "Vacío");
                if (x == _semillaX && y == _semillaY) estado += " [Semilla]";
                lblCoordenadas.Text = $"Cursor: ({x}, {y})  |  Estado Celda: {estado}";

                if (_isDrawing && !_ejecutandoRelleno)
                {
                    if (rdbDibujar.Checked)
                    {
                        _borde[x, y] = true;
                        _relleno[x, y] = false;
                        if (_semillaX == x && _semillaY == y) { _semillaX = -1; _semillaY = -1; }
                    }
                    else if (rdbBorrar.Checked)
                    {
                        _borde[x, y] = false;
                        _relleno[x, y] = false;
                    }
                    picCanvas.Invalidate();
                }
            }
            else
            {
                lblCoordenadas.Text = $"Cursor: (—, —)  |  Estado Celda: —";
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            _isDrawing = false;
            ActualizarInfoLabel();
        }

        // ── Helper Labels ─────────────────────────────────────────────────
        private void ActualizarInfoLabel()
        {
            string semStr = (_semillaX >= 0) ? $"({_semillaX}, {_semillaY})" : "No colocada";
            int bordes = 0;
            for (int x = 0; x < _ancho; x++)
                for (int y = 0; y < _alto; y++)
                    if (_borde[x, y]) bordes++;

            lblInfo.Text = $"Semilla: {semStr}  —  Bordes pintados: {bordes}";
        }

        private void FrmPixelEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
