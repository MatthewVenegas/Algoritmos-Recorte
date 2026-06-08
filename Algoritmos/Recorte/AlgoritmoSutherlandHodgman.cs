using System;
using System.Collections.Generic;
using System.Drawing;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Recorte
{
    public class AlgoritmoSutherlandHodgman
    {
        public List<PasoRecorte> CalcularRecorte(List<PointF> verticesIniciales, double xMin, double xMax, double yMin, double yMax)
        {
            var pasos = new List<PasoRecorte>();
            int pasoNum = 1;

            // Paso 1: Polígono original
            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoNum++,
                Vertices = new List<PointF>(verticesIniciales),
                BordeClip = "Original",
                Explicacion = $"Inicio de Sutherland-Hodgman.\r\nPolígono original con {verticesIniciales.Count} vértices.\r\nVentana: X[{xMin}, {xMax}], Y[{yMin}, {yMax}].",
                Aceptada = false,
                Terminado = false
            });

            var verticesActuales = new List<PointF>(verticesIniciales);
            string[] bordes = { "Izquierdo", "Derecho", "Abajo", "Arriba" };
            double[] limites = { xMin, xMax, yMin, yMax };

            for (int i = 0; i < 4; i++)
            {
                if (verticesActuales.Count == 0)
                {
                    pasos.Add(new PasoRecorte
                    {
                        NumeroPaso = pasoNum++,
                        Vertices = new List<PointF>(),
                        BordeClip = bordes[i],
                        Explicacion = $"El polígono fue completamente recortado en el borde {bordes[i]}.",
                        Aceptada = false,
                        Terminado = true
                    });
                    break;
                }

                string explicacion;
                verticesActuales = RecortarBorde(verticesActuales, bordes[i], limites[i], out explicacion);

                pasos.Add(new PasoRecorte
                {
                    NumeroPaso = pasoNum++,
                    Vertices = new List<PointF>(verticesActuales),
                    BordeClip = bordes[i],
                    Explicacion = explicacion,
                    Aceptada = (i == 3 && verticesActuales.Count > 0),
                    Terminado = (i == 3)
                });
            }

            return pasos;
        }

        private List<PointF> RecortarBorde(List<PointF> verticesIn, string borde, double limite, out string explicacion)
        {
            var verticesOut = new List<PointF>();
            if (verticesIn.Count == 0)
            {
                explicacion = "Polígono vacío. No hay nada que recortar.";
                return verticesOut;
            }

            var detalles = new List<string>();
            detalles.Add($"Recorte contra borde {borde} ({limite:F1}):");

            for (int i = 0; i < verticesIn.Count; i++)
            {
                PointF s = verticesIn[i];
                PointF p = verticesIn[(i + 1) % verticesIn.Count];

                bool sInside = EstaAdentro(s, borde, limite);
                bool pInside = EstaAdentro(p, borde, limite);

                if (sInside && pInside)
                {
                    verticesOut.Add(p);
                    detalles.Add($"- ({s.X:F1},{s.Y:F1})➔({p.X:F1},{p.Y:F1}): Ambos dentro. Guarda ({p.X:F1},{p.Y:F1}).");
                }
                else if (sInside && !pInside)
                {
                    PointF intersect = EncontrarInterseccion(s, p, borde, limite);
                    verticesOut.Add(intersect);
                    detalles.Add($"- ({s.X:F1},{s.Y:F1})➔({p.X:F1},{p.Y:F1}): Entra a sale. Guarda intersección ({intersect.X:F1},{intersect.Y:F1}).");
                }
                else if (!sInside && pInside)
                {
                    PointF intersect = EncontrarInterseccion(s, p, borde, limite);
                    verticesOut.Add(intersect);
                    verticesOut.Add(p);
                    detalles.Add($"- ({s.X:F1},{s.Y:F1})➔({p.X:F1},{p.Y:F1}): Sale a entra. Guarda ({intersect.X:F1},{intersect.Y:F1}) y ({p.X:F1},{p.Y:F1}).");
                }
                else
                {
                    detalles.Add($"- ({s.X:F1},{s.Y:F1})➔({p.X:F1},{p.Y:F1}): Ambos fuera. Se descarta.");
                }
            }

            explicacion = string.Join("\r\n", detalles);
            return verticesOut;
        }

        private bool EstaAdentro(PointF pt, string borde, double limite)
        {
            if (borde == "Izquierdo") return pt.X >= limite;
            if (borde == "Derecho") return pt.X <= limite;
            if (borde == "Abajo") return pt.Y >= limite;
            if (borde == "Arriba") return pt.Y <= limite;
            return false;
        }

        private PointF EncontrarInterseccion(PointF s, PointF p, string borde, double limite)
        {
            float x = 0, y = 0;
            if (borde == "Izquierdo" || borde == "Derecho")
            {
                x = (float)limite;
                if (Math.Abs(p.X - s.X) > 0.0001)
                {
                    y = s.Y + (p.Y - s.Y) * (x - s.X) / (p.X - s.X);
                }
                else
                {
                    y = s.Y;
                }
            }
            else // Abajo o Arriba
            {
                y = (float)limite;
                if (Math.Abs(p.Y - s.Y) > 0.0001)
                {
                    x = s.X + (p.X - s.X) * (y - s.Y) / (p.Y - s.Y);
                }
                else
                {
                    x = s.X;
                }
            }
            return new PointF((float)Math.Round(x, 2), (float)Math.Round(y, 2));
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Sutherland-Hodgman (Recorte de Polígonos)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Recorta un polígono contra cada uno de los 4 bordes de forma secuencial:\r\n" +
                "1. Izquierda  2. Derecha  3. Abajo  4. Arriba\r\n\r\n" +
                "Para cada arista de inicio (S) a fin (P):\r\n" +
                "- S y P adentro ➔ Guardar P\r\n" +
                "- S adentro y P afuera ➔ Guardar Intersección(S, P)\r\n" +
                "- S afuera y P adentro ➔ Guardar Intersección(S, P) y P\r\n" +
                "- S y P afuera ➔ No guardar nada\r\n\r\n" +
                "La lista resultante se convierte en el polígono de entrada para el siguiente borde.";
        }
    }
}
