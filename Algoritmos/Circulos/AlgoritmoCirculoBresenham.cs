using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Circulos
{
    /// <summary>
    /// Algoritmo de Bresenham para círculos.
    /// Evalúa la función de círculo f(x,y) = x² + y² - r²
    /// para decidir si moverse E o SE en el primer octante.
    /// </summary>
    public class AlgoritmoCirculoBresenham
    {
        public List<PuntoCirculoAlg> CalcularPuntos(int xc, int yc, int r)
        {
            var pasos   = new List<PuntoCirculoAlg>();
            var pixeles = new List<(int x, int y)>();

            int x = 0;
            int y = r;
            // f = x² + y² - r²  (el pixel (x,y) ideal está en el círculo)
            // Usamos: d = 3 - 2r  para el inicio del primer octante
            int d = 3 - 2 * r;
            int paso = 0;

            AgregarPaso(pasos, paso++, x, y, d, "Inicio");
            AgregarSimetria(pixeles, xc, yc, x, y);

            while (x < y)
            {
                x++;
                string dec;
                if (d < 0)
                {
                    d = d + 4 * x + 6;
                    dec = $"d={d - (4*x+6)}<0 → E: d'={d}";
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                    dec = $"d={d - (4*(x-y+1)+10)+4}≥0 → SE: y--, d'={d}";
                }
                AgregarPaso(pasos, paso++, x, y, d, dec);
                AgregarSimetria(pixeles, xc, yc, x, y);
            }

            _pixeles = pixeles;
            return pasos;
        }

        private List<(int x, int y)> _pixeles = new List<(int, int)>();
        public List<(int x, int y)> ObtenerPixeles() => _pixeles;

        private void AgregarPaso(List<PuntoCirculoAlg> lista, int paso, int x, int y, int d, string dec)
        {
            lista.Add(new PuntoCirculoAlg
            {
                Paso = paso, X = x, Y = y, P = d,
                Decision = dec,
                Octante = $"f({x},{y})={x*x + y*y}"
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
                "Algoritmo de Bresenham — Círculo\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Evalúa f(x,y) = x² + y² - r² en el pixel medio.\r\n\r\n" +
                "1. Inicio: x=0, y=r\r\n" +
                "   d₀ = 3 - 2r\r\n" +
                "2. Mientras x < y:\r\n" +
                "   x++\r\n" +
                "   Si d < 0:\r\n" +
                "      d = d + 4x + 6   (E)\r\n" +
                "   Si d ≥ 0:\r\n" +
                "      d = d + 4(x-y) + 10, y--  (SE)\r\n" +
                "3. Simetría 8 octantes: (±x,±y), (±y,±x)\r\n\r\n" +
                "⚡ Solo enteros.\r\n" +
                "✔ Alternativa a MidPoint con diferente d inicial.\r\n" +
                "✔ Mismos resultados visuales.";
        }
    }
}
