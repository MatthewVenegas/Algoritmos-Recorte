using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Relleno
{
    /// <summary>
    /// Scan Line Fill (relleno por líneas de escaneo).
    /// Recorre cada fila Y del canvas y busca intersecciones con los bordes.
    /// Rellena los pixels entre cada par de intersecciones.
    /// </summary>
    public class AlgoritmoScanLine
    {
        public async Task EjecutarAsync(
            bool[,] borde,
            bool[,] relleno,
            int ancho, int alto,
            int delayMs,
            Action<int, int> onPixelRellenado,
            Func<bool> cancelado)
        {
            for (int y = 0; y < alto && !cancelado(); y++)
            {
                // Encontrar todos los pixels de borde en esta fila
                var intersecciones = new List<int>();
                for (int x = 0; x < ancho; x++)
                {
                    if (borde[x, y])
                        intersecciones.Add(x);
                }

                // Necesitamos al menos 2 intersecciones para rellenar
                if (intersecciones.Count < 2) continue;

                // Rellenar entre pares de intersecciones
                for (int i = 0; i + 1 < intersecciones.Count; i += 2)
                {
                    int xIni = intersecciones[i] + 1;
                    int xFin = intersecciones[i + 1];

                    for (int x = xIni; x < xFin && !cancelado(); x++)
                    {
                        if (!borde[x, y] && !relleno[x, y])
                        {
                            relleno[x, y] = true;
                            onPixelRellenado?.Invoke(x, y);
                            await Task.Delay(Math.Max(1, delayMs));
                        }
                    }
                }
            }
        }

        public string ObtenerExplicacion()
        {
            return
                "Scan Line Fill (Líneas de Escaneo)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Rellena escaneando horizontalmente fila por fila.\r\n\r\n" +
                "Para cada fila Y:\r\n" +
                "1. Encontrar intersecciones con los bordes\r\n" +
                "2. Ordenar intersecciones de izquierda a derecha\r\n" +
                "3. Rellenar entre cada par:\r\n" +
                "   x₁ → x₂: colorear\r\n" +
                "   x₃ → x₄: colorear\r\n" +
                "   ...\r\n\r\n" +
                "🖱 Dibuja el contorno cerrado con clicks\r\n" +
                "▶ Presionar RELLENAR para ejecutar\r\n\r\n" +
                "✔ Eficiente para polígonos complejos.\r\n" +
                "✔ No necesita semilla.\r\n" +
                "✔ Usado en render 3D moderno.";
        }
    }
}
