using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Circulos
{
    /// <summary>
    /// Algoritmo de Punto Medio para círculos (Bresenham).
    /// Genera los puntos del primer octante y los refleja en los 8 octantes.
    /// Parámetro de decisión: p = 1 - r (inicial)
    /// </summary>
    public class AlgoritmoCirculoMidPoint
    {
        public List<PuntoCirculoAlg> CalcularPuntos(int xc, int yc, int r)
        {
            var pasos  = new List<PuntoCirculoAlg>();
            var pixeles = new List<(int x, int y)>();

            int x = 0;
            int y = r;
            int p = 1 - r;
            int paso = 0;

            AgregarPaso(pasos, paso++, x, y, p, "Inicio");
            AgregarSimetria(pixeles, xc, yc, x, y);

            while (x < y)
            {
                x++;
                string dec;
                if (p < 0)
                {
                    p = p + 2 * x + 1;
                    dec = $"p={p - (2*x+1)}<0 → E: p'={p}";
                }
                else
                {
                    y--;
                    p = p + 2 * (x - y) + 1;
                    dec = $"p={p - (2*(x-y)+1)}≥0 → SE: y--, p'={p}";
                }
                AgregarPaso(pasos, paso++, x, y, p, dec);
                AgregarSimetria(pixeles, xc, yc, x, y);
            }

            // Guardar los pixeles finales en el último paso para uso del formulario
            _pixeles = pixeles;
            return pasos;
        }

        private List<(int x, int y)> _pixeles = new List<(int, int)>();
        public List<(int x, int y)> ObtenerPixeles() => _pixeles;

        private void AgregarPaso(List<PuntoCirculoAlg> lista, int paso, int x, int y, int p, string dec)
        {
            lista.Add(new PuntoCirculoAlg
            {
                Paso = paso, X = x, Y = y, P = p,
                Decision = dec,
                Octante = $"({x},{y}) → 8 simétricos"
            });
        }

        private void AgregarSimetria(List<(int, int)> pixeles, int xc, int yc, int x, int y)
        {
            pixeles.Add((xc + x, yc + y));
            pixeles.Add((xc - x, yc + y));
            pixeles.Add((xc + x, yc - y));
            pixeles.Add((xc - x, yc - y));
            pixeles.Add((xc + y, yc + x));
            pixeles.Add((xc - y, yc + x));
            pixeles.Add((xc + y, yc - x));
            pixeles.Add((xc - y, yc - x));
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo de Punto Medio — Círculo\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Calcula el 1er octante y aplica simetría 8-vía.\r\n\r\n" +
                "1. Inicio: x=0, y=r\r\n" +
                "   p₀ = 1 - r\r\n" +
                "2. Mientras x < y:\r\n" +
                "   x++\r\n" +
                "   Si p < 0:\r\n" +
                "      p = p + 2x + 1   (mueve E)\r\n" +
                "   Si p ≥ 0:\r\n" +
                "      y--\r\n" +
                "      p = p + 2(x-y)+1  (mueve SE)\r\n" +
                "3. Simetría de 8 octantes:\r\n" +
                "   (±x,±y), (±y,±x)\r\n\r\n" +
                "⚡ Solo enteros. Muy eficiente.\r\n" +
                "✔ El más usado en hardware gráfico.";
        }
    }
}
