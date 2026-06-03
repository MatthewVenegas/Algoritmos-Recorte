using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Relleno
{
    /// <summary>
    /// Boundary Fill (relleno por frontera) — 4-conectividad.
    /// Similar a Flood Fill pero se detiene al encontrar pixels de borde (color frontera).
    /// Puede usarse cuando el borde tiene un color distinto al fondo y al relleno.
    /// </summary>
    public class AlgoritmoBoundaryFill
    {
        public async Task EjecutarAsync(
            bool[,] borde,
            bool[,] relleno,
            int semillaX, int semillaY,
            int ancho, int alto,
            int delayMs,
            Action<int, int> onPixelRellenado,
            Func<bool> cancelado)
        {
            if (semillaX < 0 || semillaX >= ancho || semillaY < 0 || semillaY >= alto) return;
            if (borde[semillaX, semillaY]) return;
            if (relleno[semillaX, semillaY]) return;

            // Usa Stack (DFS) a diferencia de FloodFill que usa Queue (BFS)
            // Esto produce un patrón de propagación diferente y más "zigzagueante"
            var pila = new Stack<(int x, int y)>();
            pila.Push((semillaX, semillaY));
            relleno[semillaX, semillaY] = true;
            onPixelRellenado?.Invoke(semillaX, semillaY);
            await Task.Delay(Math.Max(1, delayMs));

            int[] dx4 = { 0, 1, 0, -1 };
            int[] dy4 = { -1, 0, 1, 0 };

            while (pila.Count > 0 && !cancelado())
            {
                var (cx, cy) = pila.Pop();
                for (int d = 0; d < 4; d++)
                {
                    int nx = cx + dx4[d];
                    int ny = cy + dy4[d];
                    // Condición de frontera: NO es borde (color frontera)
                    if (nx >= 0 && nx < ancho && ny >= 0 && ny < alto
                        && !borde[nx, ny] && !relleno[nx, ny])
                    {
                        relleno[nx, ny] = true;
                        pila.Push((nx, ny));
                        onPixelRellenado?.Invoke(nx, ny);
                        await Task.Delay(Math.Max(1, delayMs));
                    }
                }
            }
        }

        public string ObtenerExplicacion()
        {
            return
                "Boundary Fill (Relleno por Frontera)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Propagación DFS desde un pixel semilla.\r\n" +
                "Se detiene al encontrar pixels de BORDE.\r\n\r\n" +
                "1. Insertar semilla en PILA (DFS vs BFS)\r\n" +
                "2. Mientras pila no vacía:\r\n" +
                "   a. Desapilar pixel (x, y)\r\n" +
                "   b. Para cada vecino (4-conectividad):\r\n" +
                "      Si NO es borde Y NO rellenado:\r\n" +
                "         → Colorear pixel\r\n" +
                "         → Apilar vecino\r\n\r\n" +
                "🖱 Click izquierdo → dibujar borde\r\n" +
                "🖱 Click derecho   → colocar semilla\r\n" +
                "▶ Presionar RELLENAR para ejecutar\r\n\r\n" +
                "✔ Trabaja con cualquier forma cerrada.\r\n" +
                "⚠ DFS puede causar stack overflow en áreas grandes.\r\n" +
                "⚡ Patrón de propagación diferente a Flood Fill.";
        }
    }
}
