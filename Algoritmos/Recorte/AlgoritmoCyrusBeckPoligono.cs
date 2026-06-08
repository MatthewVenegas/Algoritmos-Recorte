using System;
using System.Collections.Generic;
using System.Drawing;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Recorte
{
    public class AlgoritmoCyrusBeckPoligono
    {
        private struct Edge
        {
            public PointF Point; // A point on the window edge
            public PointF Normal; // Inward normal vector
            public string Name;
        }

        public List<PasoRecorte> CalcularRecorte(List<PointF> subjectPoly, double xMin, double xMax, double yMin, double yMax)
        {
            var pasos = new List<PasoRecorte>();
            int pasoNum = 1;

            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoNum++,
                Vertices = new List<PointF>(subjectPoly),
                BordeClip = "Original",
                Explicacion = $"Inicio de Cyrus-Beck para Polígonos.\r\nPolígono original: {subjectPoly.Count} vértices.\r\nVentana: X[{xMin}, {xMax}], Y[{yMin}, {yMax}].",
                Aceptada = false,
                Terminado = false
            });

            // Definir las 4 aristas de la ventana de recorte con sus vectores normales hacia adentro
            var windowEdges = new List<Edge>
            {
                new Edge { Point = new PointF((float)xMin, (float)yMin), Normal = new PointF(1, 0), Name = "Izquierda" },  // Normal apunta a la derecha
                new Edge { Point = new PointF((float)xMax, (float)yMin), Normal = new PointF(-1, 0), Name = "Derecha" },   // Normal apunta a la izquierda
                new Edge { Point = new PointF((float)xMin, (float)yMin), Normal = new PointF(0, 1), Name = "Abajo" },      // Normal apunta hacia arriba
                new Edge { Point = new PointF((float)xMin, (float)yMax), Normal = new PointF(0, -1), Name = "Arriba" }     // Normal apunta hacia abajo
            };

            var clippedSegments = new List<Tuple<PointF, PointF>>();
            var explicacionDetallada = new List<string>();

            // Recortar cada arista del polígono sujeto
            for (int i = 0; i < subjectPoly.Count; i++)
            {
                PointF p0 = subjectPoly[i];
                PointF p1 = subjectPoly[(i + 1) % subjectPoly.Count];

                double tE = 0.0;
                double tS = 1.0;
                PointF d = new PointF(p1.X - p0.X, p1.Y - p0.Y);
                bool visible = true;

                explicacionDetallada.Add($"Arista {i}: ({p0.X:F1},{p0.Y:F1}) ➔ ({p1.X:F1},{p1.Y:F1})");

                foreach (var edge in windowEdges)
                {
                    float numerator = edge.Normal.X * (edge.Point.X - p0.X) + edge.Normal.Y * (edge.Point.Y - p0.Y);
                    float denominator = edge.Normal.X * d.X + edge.Normal.Y * d.Y;

                    if (denominator == 0) // Paralelo
                    {
                        if (numerator < 0) // Fuera
                        {
                            visible = false;
                            explicacionDetallada.Add($"- Paralela y fuera de borde {edge.Name}. Se descarta.");
                            break;
                        }
                    }
                    else
                    {
                        double t = numerator / denominator;
                        if (denominator > 0) // Entrando
                        {
                            if (t > tE) tE = t;
                        }
                        else // Saliendo
                        {
                            if (t < tS) tS = t;
                        }
                    }
                }

                if (visible && tE <= tS)
                {
                    PointF c0 = new PointF((float)(p0.X + tE * d.X), (float)(p0.Y + tE * d.Y));
                    PointF c1 = new PointF((float)(p0.X + tS * d.X), (float)(p0.Y + tS * d.Y));
                    clippedSegments.Add(new Tuple<PointF, PointF>(c0, c1));
                    explicacionDetallada.Add($"- Recortado: ({c0.X:F2},{c0.Y:F2}) a ({c1.X:F2},{c1.Y:F2}) [tE={tE:F3}, tS={tS:F3}].");
                }
                else
                {
                    explicacionDetallada.Add("- Completamente fuera del área visible.");
                }
            }

            // Reconstruir el polígono resultante uniendo los segmentos en orden
            var resultadoVertices = ReconstruirPoligono(clippedSegments);

            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoNum++,
                Vertices = resultadoVertices,
                BordeClip = "Cyrus-Beck",
                Explicacion = string.Join("\r\n", explicacionDetallada),
                Aceptada = resultadoVertices.Count >= 3,
                Terminado = true
            });

            return pasos;
        }

        private List<PointF> ReconstruirPoligono(List<Tuple<PointF, PointF>> segments)
        {
            var poly = new List<PointF>();
            if (segments.Count == 0) return poly;

            // Para simplificar la reconstrucción geométrica:
            // Añadimos secuencialmente los puntos únicos en orden de recorrido
            foreach (var seg in segments)
            {
                // Agregar c0 si no está duplicado consecutivamente
                if (poly.Count == 0 || DistanciaCuadrado(poly[poly.Count - 1], seg.Item1) > 0.01)
                {
                    poly.Add(seg.Item1);
                }
                // Agregar c1 si no está duplicado consecutivamente
                if (DistanciaCuadrado(poly[poly.Count - 1], seg.Item2) > 0.01)
                {
                    poly.Add(seg.Item2);
                }
            }

            // Si el último punto y el primero coinciden, remover el duplicado final
            if (poly.Count > 1 && DistanciaCuadrado(poly[poly.Count - 1], poly[0]) < 0.01)
            {
                poly.RemoveAt(poly.Count - 1);
            }

            return poly;
        }

        private double DistanciaCuadrado(PointF a, PointF b)
        {
            return (a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y);
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Cyrus-Beck (Recorte de Polígonos)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Recorta aristas de manera paramétrica vectorial contra la ventana:\r\n" +
                "P(t) = P₀ + t·D  (0 ≤ t ≤ 1)\r\n\r\n" +
                "Usa normales interiores (N_i) y puntos de borde (f_i) para calcular:\r\n" +
                "t = [N_i · (f_i - P₀)] / [N_i · D]\r\n\r\n" +
                "Para cada arista:\r\n" +
                "- Si N_i · D > 0 ➔ Límite de Entrada. tE = Max(tE, t)\r\n" +
                "- Si N_i · D < 0 ➔ Límite de Salida.  tS = Min(tS, t)\r\n" +
                "Si tE ≤ tS ➔ El segmento se recorta a [tE, tS] y se unen los segmentos.";
        }
    }
}
