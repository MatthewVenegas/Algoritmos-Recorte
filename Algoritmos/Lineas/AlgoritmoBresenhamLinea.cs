using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Lineas
{
    /// <summary>
    /// Algoritmo de Bresenham para líneas.
    /// Usa solo aritmética entera (sumas y restas), sin punto flotante.
    /// Basado en el parámetro de decisión p que determina qué pixel pintar.
    /// </summary>
    public class AlgoritmoBresenhamLinea
    {
        public List<PuntoLinea> CalcularPuntos(int x0, int y0, int x1, int y1)
        {
            var puntos = new List<PuntoLinea>();

            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            // Decidir si la pendiente es suave (|m| <= 1) o pronunciada (|m| > 1)
            bool intercambio = dy > dx;
            if (intercambio) { int tmp = dx; dx = dy; dy = tmp; }

            int p = 2 * dy - dx;   // Parámetro de decisión inicial
            int x = x0, y = y0;
            int paso = 0;

            for (int i = 0; i <= dx; i++)
            {
                string decision;
                if (p < 0)
                {
                    decision = $"p={p}<0 → NE (solo avanza {(intercambio ? "Y" : "X")})";
                }
                else
                {
                    decision = $"p={p}≥0 → E (avanza {(intercambio ? "X" : "Y")} también)";
                }

                puntos.Add(new PuntoLinea
                {
                    Paso   = paso++,
                    X      = x,
                    Y      = y,
                    XPixel = x,
                    YPixel = y,
                    Decision = decision
                });

                if (p >= 0)
                {
                    if (intercambio) x += sx; else y += sy;
                    p -= 2 * dx;
                }
                if (intercambio) y += sy; else x += sx;
                p += 2 * dy;
            }
            return puntos;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo de Bresenham (Línea)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "1. dx = |x1-x0|, dy = |y1-y0|\r\n" +
                "2. p₀ = 2·dy - dx   (parámetro de decisión)\r\n" +
                "3. Para cada paso:\r\n" +
                "   Si p < 0:\r\n" +
                "      → pixel(x, y)  (avanza solo en X)\r\n" +
                "      → p = p + 2·dy\r\n" +
                "   Si p ≥ 0:\r\n" +
                "      → pixel(x, y+1) (avanza en X e Y)\r\n" +
                "      → p = p + 2·dy - 2·dx\r\n\r\n" +
                "⚡ Solo usa sumas/restas de enteros.\r\n" +
                "✔ Más eficiente que DDA.\r\n" +
                "✔ Resultados idénticos a DDA con menos operaciones.";
        }
    }
}
