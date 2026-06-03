using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Lineas
{
    /// <summary>
    /// Algoritmo de Punto Medio para líneas.
    /// Evalúa la función implícita F(x,y) = dy·x - dx·y + dx·b en el punto medio.
    /// Similar a Bresenham pero derivado desde la función de línea.
    /// </summary>
    public class AlgoritmoPuntoMedioLinea
    {
        public List<PuntoLinea> CalcularPuntos(int x0, int y0, int x1, int y1)
        {
            var puntos = new List<PuntoLinea>();

            int dx = x1 - x0;
            int dy = y1 - y0;

            // Manejar todos los octantes normalizando
            int ax = Math.Abs(dx), ay = Math.Abs(dy);
            int sx = dx >= 0 ? 1 : -1;
            int sy = dy >= 0 ? 1 : -1;
            bool intercambio = ay > ax;

            int adx = intercambio ? ay : ax;
            int ady = intercambio ? ax : ay;

            // Parámetro de decisión: d = 2·ady - adx
            int d = 2 * ady - adx;
            int x = x0, y = y0;
            int paso = 0;

            for (int i = 0; i <= adx; i++)
            {
                string decision;
                if (d <= 0)
                {
                    decision = $"F(mid)={d}≤0 → Punto medio DENTRO → avanza solo {(intercambio ? "Y" : "X")}";
                }
                else
                {
                    decision = $"F(mid)={d}>0 → Punto medio FUERA  → avanza {(intercambio ? "X e Y" : "X e Y")}";
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

                if (d > 0)
                {
                    if (intercambio) x += sx; else y += sy;
                    d -= 2 * adx;
                }
                if (intercambio) y += sy; else x += sx;
                d += 2 * ady;
            }
            return puntos;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo de Punto Medio (Línea)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Evalúa la función implícita en el punto medio\r\n" +
                "entre dos candidatos de pixel.\r\n\r\n" +
                "F(x,y) = dy·x - dx·y + dx·b\r\n\r\n" +
                "1. d₀ = 2·|dy| - |dx|\r\n" +
                "2. Para cada columna x:\r\n" +
                "   Si F(mid) ≤ 0  → pixel inferior (y sin cambio)\r\n" +
                "      d += 2·|dy|\r\n" +
                "   Si F(mid) > 0  → pixel superior (y+1)\r\n" +
                "      d += 2·|dy| - 2·|dx|\r\n\r\n" +
                "⚡ Solo aritmética entera.\r\n" +
                "✔ Fundamentalmente equivalente a Bresenham.\r\n" +
                "✔ Derivación geométrica más intuitiva.";
        }
    }
}
