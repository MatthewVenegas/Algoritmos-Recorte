using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Relleno
{
    /// <summary>
    /// Flood Fill (relleno por inundación) — 4-conectividad.
    /// Parte de un pixel semilla y propaga a todos los vecinos vacíos (no-borde).
    /// Usa una cola (BFS) para propagación pixel a pixel.
    /// </summary>
    public class AlgoritmoFloodFill
    {
        public async Task EjecutarAsync(
            bool[,] borde,          // true = pixel de borde (negro)
            bool[,] relleno,        // resultado: true = pixel rellenado
            int semillaX, int semillaY,
            int ancho, int alto,
            int delayMs,
            Action<int, int> onPixelRellenado,
            Func<bool> cancelado)
        {
            if (semillaX < 0 || semillaX >= ancho || semillaY < 0 || semillaY >= alto) return;
            if (borde[semillaX, semillaY]) return;     // No se puede rellenar sobre un borde
            if (relleno[semillaX, semillaY]) return;   // Ya estaba rellenado

            var cola = new Queue<(int x, int y)>();
            cola.Enqueue((semillaX, semillaY));
            relleno[semillaX, semillaY] = true;
            onPixelRellenado?.Invoke(semillaX, semillaY);
            await Task.Delay(Math.Max(1, delayMs));

            int[] dx4 = { 0, 1, 0, -1 };
            int[] dy4 = { -1, 0, 1, 0 };

            while (cola.Count > 0 && !cancelado())
            {
                var (cx, cy) = cola.Dequeue();
                for (int d = 0; d < 4; d++)
                {
                    int nx = cx + dx4[d];
                    int ny = cy + dy4[d];
                    if (nx >= 0 && nx < ancho && ny >= 0 && ny < alto
                        && !borde[nx, ny] && !relleno[nx, ny])
                    {
                        relleno[nx, ny] = true;
                        cola.Enqueue((nx, ny));
                        onPixelRellenado?.Invoke(nx, ny);
                        await Task.Delay(Math.Max(1, delayMs));
                    }
                }
            }
        }

        public string ObtenerExplicacion()
        {
            return
                "Flood Fill (Relleno por Inundación)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Propagación BFS desde un pixel semilla.\r\n\r\n" +
                "1. Insertar semilla en cola\r\n" +
                "2. Mientras cola no vacía:\r\n" +
                "   a. Desencolar pixel (x, y)\r\n" +
                "   b. Para cada vecino (4-conectividad):\r\n" +
                "      Si vacío y no visitado:\r\n" +
                "         → Colorear pixel\r\n" +
                "         → Encolar vecino\r\n\r\n" +
                "🖱 Click izquierdo → dibujar borde\r\n" +
                "🖱 Click derecho   → colocar semilla\r\n" +
                "▶ Presionar RELLENAR para ejecutar\r\n\r\n" +
                "✔ Simple e intuitivo.\r\n" +
                "✘ Puede usar mucha memoria en áreas grandes.";
        }
    }
}
