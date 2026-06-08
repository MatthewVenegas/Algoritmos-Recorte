using System;
using System.Drawing;

namespace AlgoritmosDeDiscretizacion.Utilidades
{
    /// <summary>
    /// Clase utilitaria compartida por todos los algoritmos.
    /// Provee métodos para dibujar cuadrícula, ejes, píxeles y transformar coordenadas cartesianas.
    /// </summary>
    public static class GraficadorBase
    {
        // ── Colores turquesa ─────────────────────────────────────────────
        public static readonly Color ColorPrimario      = Color.FromArgb(0, 128, 128);
        public static readonly Color ColorSecundario    = Color.FromArgb(0, 172, 172);
        public static readonly Color ColorFondoPanel    = Color.FromArgb(224, 247, 247);
        public static readonly Color ColorTexto         = Color.FromArgb(0, 80, 80);
        public static readonly Color ColorBotonPrimario = Color.FromArgb(0, 150, 150);
        public static readonly Color ColorBotonSecundario = Color.FromArgb(204, 240, 240);
        public static readonly Color ColorHeaderTabla   = Color.FromArgb(0, 128, 128);
        public static readonly Color ColorHeaderTexto   = Color.White;
        public static readonly Color ColorError         = Color.FromArgb(180, 60, 60);
        public static readonly Color ColorPixelLinea    = Color.FromArgb(0, 128, 128);
        public static readonly Color ColorPixelCirculo  = Color.FromArgb(0, 100, 180);
        public static readonly Color ColorLineaReal     = Color.FromArgb(200, 60, 60);
        public static readonly Color ColorPasoActual    = Color.FromArgb(255, 180, 0);

        // ── Transformación cartesiana ────────────────────────────────────
        /// <summary>Convierte coordenada cartesiana a pixel de pantalla.</summary>
        public static Point CartesianoAPantalla(int x, int y, int anchoCanvas, int altoCanvas, int tamPixel)
        {
            int centroX = (anchoCanvas / 2 / tamPixel) * tamPixel;
            int centroY = (altoCanvas  / 2 / tamPixel) * tamPixel;
            return new Point(centroX + x * tamPixel, centroY - y * tamPixel);
        }

        /// <summary>Convierte pixel de pantalla a coordenada cartesiana.</summary>
        public static Point PantallaACartesiano(int px, int py, int anchoCanvas, int altoCanvas, int tamPixel)
        {
            int centroX = (anchoCanvas / 2 / tamPixel) * tamPixel;
            int centroY = (altoCanvas  / 2 / tamPixel) * tamPixel;
            return new Point((px - centroX) / tamPixel, (centroY - py) / tamPixel);
        }

        // ── Cuadrícula ───────────────────────────────────────────────────
        public static void DibujarCuadricula(Graphics g, int ancho, int alto, int tamPixel)
        {
            using (Pen penGrid = new Pen(Color.FromArgb(210, 230, 230), 1f))
            using (Pen penCuadro = new Pen(Color.FromArgb(180, 215, 215), 1f))
            {
                int centroX = (ancho / 2 / tamPixel) * tamPixel;
                int centroY = (alto  / 2 / tamPixel) * tamPixel;

                // Líneas verticales
                for (int x = centroX; x <= ancho; x += tamPixel)
                    g.DrawLine(penGrid, x, 0, x, alto);
                for (int x = centroX; x >= 0; x -= tamPixel)
                    g.DrawLine(penGrid, x, 0, x, alto);

                // Líneas horizontales
                for (int y = centroY; y <= alto; y += tamPixel)
                    g.DrawLine(penGrid, 0, y, ancho, y);
                for (int y = centroY; y >= 0; y -= tamPixel)
                    g.DrawLine(penGrid, 0, y, ancho, y);
            }
        }

        // ── Ejes ─────────────────────────────────────────────────────────
        public static void DibujarEjes(Graphics g, int ancho, int alto, int tamPixel)
        {
            int centroX = (ancho / 2 / tamPixel) * tamPixel;
            int centroY = (alto  / 2 / tamPixel) * tamPixel;

            using (Pen penEje = new Pen(Color.FromArgb(0, 80, 80), 2f))
            {
                // Eje X
                g.DrawLine(penEje, 0, centroY, ancho, centroY);
                // Eje Y
                g.DrawLine(penEje, centroX, 0, centroX, alto);

                // Flechas
                g.DrawLine(penEje, ancho - 10, centroY - 5, ancho, centroY);
                g.DrawLine(penEje, ancho - 10, centroY + 5, ancho, centroY);
                g.DrawLine(penEje, centroX - 5, 10, centroX, 0);
                g.DrawLine(penEje, centroX + 5, 10, centroX, 0);
            }

            // Etiquetas de ejes
            using (Font fnt = new Font("Segoe UI", 7f, FontStyle.Bold))
            using (SolidBrush br = new SolidBrush(Color.FromArgb(0, 80, 80)))
            {
                g.DrawString("X", fnt, br, ancho - 14, centroY + 4);
                g.DrawString("Y", fnt, br, centroX + 4, 2);
                g.DrawString("0", fnt, br, centroX + 3, centroY + 3);
            }

            // Marcas numéricas en el eje X
            DibujarMarcasNumericas(g, ancho, alto, tamPixel);
        }

        private static void DibujarMarcasNumericas(Graphics g, int ancho, int alto, int tamPixel)
        {
            int centroX = (ancho / 2 / tamPixel) * tamPixel;
            int centroY = (alto  / 2 / tamPixel) * tamPixel;
            using (Font fnt = new Font("Segoe UI", 6f))
            using (SolidBrush br = new SolidBrush(Color.FromArgb(80, 120, 120)))
            using (Pen tick = new Pen(Color.FromArgb(0, 80, 80), 1f))
            {
                // Marcas eje X
                for (int x = centroX + tamPixel; x < ancho - 10; x += tamPixel)
                {
                    int val = (x - centroX) / tamPixel;
                    g.DrawLine(tick, x, centroY - 3, x, centroY + 3);
                    if (val % 2 == 0) g.DrawString(val.ToString(), fnt, br, x - 4, centroY + 5);
                }
                for (int x = centroX - tamPixel; x > 5; x -= tamPixel)
                {
                    int val = (x - centroX) / tamPixel;
                    g.DrawLine(tick, x, centroY - 3, x, centroY + 3);
                    if (val % 2 == 0) g.DrawString(val.ToString(), fnt, br, x - 6, centroY + 5);
                }
                // Marcas eje Y
                for (int y = centroY - tamPixel; y > 5; y -= tamPixel)
                {
                    int val = (centroY - y) / tamPixel;
                    g.DrawLine(tick, centroX - 3, y, centroX + 3, y);
                    if (val % 2 == 0) g.DrawString(val.ToString(), fnt, br, centroX + 5, y - 6);
                }
                for (int y = centroY + tamPixel; y < alto - 5; y += tamPixel)
                {
                    int val = (centroY - y) / tamPixel;
                    g.DrawLine(tick, centroX - 3, y, centroX + 3, y);
                    if (val % 2 == 0) g.DrawString(val.ToString(), fnt, br, centroX + 5, y - 6);
                }
            }
        }

        // ── Dibujar Pixel ────────────────────────────────────────────────
        /// <summary>Dibuja un pixel en coordenadas cartesianas.</summary>
        public static void DibujarPixel(Graphics g, Brush color, int x, int y, int tamPixel, int anchoCanvas, int altoCanvas)
        {
            Point p = CartesianoAPantalla(x, y, anchoCanvas, altoCanvas, tamPixel);
            g.FillRectangle(color, p.X, p.Y, tamPixel, tamPixel);
        }

        /// <summary>Dibuja un pixel con borde resaltado (para paso actual).</summary>
        public static void DibujarPixelResaltado(Graphics g, Brush color, int x, int y, int tamPixel, int anchoCanvas, int altoCanvas)
        {
            Point p = CartesianoAPantalla(x, y, anchoCanvas, altoCanvas, tamPixel);
            g.FillRectangle(color, p.X, p.Y, tamPixel, tamPixel);
            using (Pen pen = new Pen(Color.FromArgb(255, 220, 0), 2f))
                g.DrawRectangle(pen, p.X, p.Y, tamPixel - 1, tamPixel - 1);
        }

        // ── Dibujar Línea Real ───────────────────────────────────────────
        public static void DibujarLineaReal(Graphics g, int x0, int y0, int x1, int y1,
            int tamPixel, int anchoCanvas, int altoCanvas)
        {
            Point p0 = CartesianoAPantalla(x0, y0, anchoCanvas, altoCanvas, tamPixel);
            Point p1 = CartesianoAPantalla(x1, y1, anchoCanvas, altoCanvas, tamPixel);
            // Ajustar al centro del pixel
            p0 = new Point(p0.X + tamPixel / 2, p0.Y + tamPixel / 2);
            p1 = new Point(p1.X + tamPixel / 2, p1.Y + tamPixel / 2);
            using (Pen pen = new Pen(Color.FromArgb(200, 200, 60, 60), 2f))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(pen, p0, p1);
            }
        }

        // ── Dibujar Círculo Real ─────────────────────────────────────────
        public static void DibujarCirculoReal(Graphics g, int xc, int yc, int r,
            int tamPixel, int anchoCanvas, int altoCanvas)
        {
            Point centro = CartesianoAPantalla(xc, yc, anchoCanvas, altoCanvas, tamPixel);
            int radioPixels = r * tamPixel;
            using (Pen pen = new Pen(Color.FromArgb(180, 200, 60, 60), 2f))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawEllipse(pen,
                    centro.X + tamPixel / 2 - radioPixels,
                    centro.Y + tamPixel / 2 - radioPixels,
                    radioPixels * 2,
                    radioPixels * 2);
            }
        }

        // ── Aplicar estilo a tabla ───────────────────────────────────────
        public static void EstilizarTabla(System.Windows.Forms.DataGridView tabla)
        {
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = ColorHeaderTabla;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = ColorHeaderTexto;
            tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 250, 250);
            tabla.DefaultCellStyle.Font = new Font("Segoe UI", 8.5f);
            tabla.DefaultCellStyle.ForeColor = ColorTexto;
            tabla.RowHeadersWidth = 35;
            tabla.RowTemplate.Height = 22;
            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tabla.GridColor = Color.FromArgb(200, 230, 230);
        }

        // Añadir dentro de GraficadorBase.cs
        public static void DibujarRegionesRecorte(Graphics g, int xMin, int xMax, int yMin, int yMax, int tamPixel, int anchoCanvas, int altoCanvas)
        {
            Point pMin = CartesianoAPantalla(xMin, yMin, anchoCanvas, altoCanvas, tamPixel);
            Point pMax = CartesianoAPantalla(xMax, yMax, anchoCanvas, altoCanvas, tamPixel);

            using (Pen penRegion = new Pen(Color.FromArgb(100, 0, 150, 150), 2f))
            {
                penRegion.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                // Líneas verticales (Izquierda y Derecha)
                g.DrawLine(penRegion, pMin.X, 0, pMin.X, altoCanvas);
                g.DrawLine(penRegion, pMax.X, 0, pMax.X, altoCanvas);

                // Líneas horizontales (Arriba y Abajo) - Recuerda que en pantalla la Y está invertida
                g.DrawLine(penRegion, 0, pMin.Y, anchoCanvas, pMin.Y);
                g.DrawLine(penRegion, 0, pMax.Y, anchoCanvas, pMax.Y);
            }

            // Dibujar el rectángulo central (Ventana de Recorte)
            using (Pen penVentana = new Pen(Color.FromArgb(200, 0, 80, 80), 3f))
            {
                int anchoVentana = pMax.X - pMin.X;
                int altoVentana = pMin.Y - pMax.Y; // pMin.Y está más abajo en pantalla
                g.DrawRectangle(penVentana, pMin.X, pMax.Y, anchoVentana, altoVentana);
            }
        }
    }
}
