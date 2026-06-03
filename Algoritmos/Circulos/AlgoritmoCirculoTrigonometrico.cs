using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Circulos
{
    /// <summary>
    /// Algoritmo Trigonométrico para círculos.
    /// Usa x = xc + r·cos(θ),  y = yc + r·sin(θ)  para θ en [0°, 360°].
    /// El incremento del ángulo se ajusta para cubrir todos los píxeles.
    /// </summary>
    public class AlgoritmoCirculoTrigonometrico
    {
        public List<PuntoCirculoAlg> CalcularPuntos(int xc, int yc, int r)
        {
            var pasos   = new List<PuntoCirculoAlg>();
            var pixeles = new List<(int x, int y)>();
            var visitados = new HashSet<(int, int)>();

            // Incremento de ángulo: 1/r radianes garantiza que no queden huecos
            double dTheta = 1.0 / r;
            int paso = 0;

            for (double theta = 0; theta <= 2 * Math.PI + dTheta; theta += dTheta)
            {
                double xReal = xc + r * Math.Cos(theta);
                double yReal = yc + r * Math.Sin(theta);
                int xPixel = (int)Math.Round(xReal);
                int yPixel = (int)Math.Round(yReal);

                double grados = theta * 180.0 / Math.PI;

                pasos.Add(new PuntoCirculoAlg
                {
                    Paso     = paso++,
                    X        = xPixel - xc,
                    Y        = yPixel - yc,
                    P        = (int)(grados),
                    Decision = $"θ={grados:F1}° → ({xPixel},{yPixel})",
                    Octante  = $"cos={Math.Cos(theta):F2}, sin={Math.Sin(theta):F2}"
                });

                var key = (xPixel, yPixel);
                if (!visitados.Contains(key))
                {
                    visitados.Add(key);
                    pixeles.Add(key);
                }
            }

            _pixeles = pixeles;
            return pasos;
        }

        private List<(int x, int y)> _pixeles = new List<(int, int)>();
        public List<(int x, int y)> ObtenerPixeles() => _pixeles;

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Trigonométrico — Círculo\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Paramétrico directo usando funciones trigonométricas.\r\n\r\n" +
                "Para θ de 0° a 360° con Δθ = 1/r:\r\n" +
                "   x = xc + r · cos(θ)\r\n" +
                "   y = yc + r · sin(θ)\r\n" +
                "   pixel(round(x), round(y))\r\n\r\n" +
                "⚡ Usa cos() y sin() → punto flotante.\r\n" +
                "✘ Más lento (funciones transcendentales).\r\n" +
                "✔ Conceptualmente simple.\r\n" +
                "✔ Fácil de entender.\r\n" +
                "✘ No aprovecha simetría (salvo con θ en [0,π/4]).";
        }
    }
}
