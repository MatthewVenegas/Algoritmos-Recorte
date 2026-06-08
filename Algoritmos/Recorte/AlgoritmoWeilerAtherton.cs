using System;
using System.Collections.Generic;
using System.Drawing;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Recorte
{
    public class AlgoritmoWeilerAtherton
    {
        private class VertexNode
        {
            public PointF Point { get; set; }
            public bool IsIntersection { get; set; }
            public bool IsEntering { get; set; }
            public bool Visited { get; set; }
            
            public VertexNode(PointF p, bool isInter = false, bool entering = false)
            {
                Point = p;
                IsIntersection = isInter;
                IsEntering = entering;
                Visited = false;
            }
        }

        private bool EstaAdentro(PointF pt, double xMin, double xMax, double yMin, double yMax)
        {
            return pt.X >= xMin && pt.X <= xMax && pt.Y >= yMin && pt.Y <= yMax;
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
                Explicacion = $"Inicio de Weiler-Atherton.\r\nPolígono sujeto: {subjectPoly.Count} vértices.\r\nVentana: X[{xMin}, {xMax}], Y[{yMin}, {yMax}].",
                Aceptada = false,
                Terminado = false
            });

            // 1. Encontrar intersecciones y construir las listas del polígono sujeto y de la ventana
            var subjectList = new List<VertexNode>();
            var windowList = new List<VertexNode>();

            // Inicializar vértices de la ventana en sentido horario
            var windowVertices = new List<PointF>
            {
                new PointF((float)xMin, (float)yMax), // Top-Left
                new PointF((float)xMax, (float)yMax), // Top-Right
                new PointF((float)xMax, (float)yMin), // Bottom-Right
                new PointF((float)xMin, (float)yMin)  // Bottom-Left
            };

            foreach (var wp in windowVertices)
            {
                windowList.Add(new VertexNode(wp));
            }

            // Para cada arista del polígono sujeto, buscar intersecciones con los bordes de la ventana
            var intersecciones = new List<VertexNode>();

            for (int i = 0; i < subjectPoly.Count; i++)
            {
                PointF s = subjectPoly[i];
                PointF p = subjectPoly[(i + 1) % subjectPoly.Count];

                subjectList.Add(new VertexNode(s));

                // Buscar intersecciones en esta arista con los 4 bordes
                var aristaIntersecciones = new List<Tuple<double, VertexNode>>(); // Tuple of parameter t, Node

                // Borde izquierdo: x = xMin
                BuscarInterseccionEjeX(s, p, xMin, yMin, yMax, ref aristaIntersecciones, xMin, xMax, yMin, yMax);
                // Borde derecho: x = xMax
                BuscarInterseccionEjeX(s, p, xMax, yMin, yMax, ref aristaIntersecciones, xMin, xMax, yMin, yMax);
                // Borde inferior: y = yMin
                BuscarInterseccionEjeY(s, p, yMin, xMin, xMax, ref aristaIntersecciones, xMin, xMax, yMin, yMax);
                // Borde superior: y = yMax
                BuscarInterseccionEjeY(s, p, yMax, xMin, xMax, ref aristaIntersecciones, xMin, xMax, yMin, yMax);

                // Ordenar las intersecciones de esta arista por el parámetro t (distancia desde s)
                aristaIntersecciones.Sort((a, b) => a.Item1.CompareTo(b.Item1));

                // Insertarlas en la lista del polígono sujeto
                foreach (var tuple in aristaIntersecciones)
                {
                    subjectList.Add(tuple.Item2);
                    intersecciones.Add(tuple.Item2);
                }
            }

            // Si no hay intersecciones, determinar si el polígono está todo adentro o todo afuera
            if (intersecciones.Count == 0)
            {
                bool todoAdentro = true;
                foreach (var pt in subjectPoly)
                {
                    if (!EstaAdentro(pt, xMin, xMax, yMin, yMax))
                    {
                        todoAdentro = false;
                        break;
                    }
                }

                if (todoAdentro)
                {
                    pasos.Add(new PasoRecorte
                    {
                        NumeroPaso = pasoNum,
                        Vertices = new List<PointF>(subjectPoly),
                        BordeClip = "Fin",
                        Explicacion = "El polígono está completamente dentro de la ventana de recorte.",
                        Aceptada = true,
                        Terminado = true
                    });
                }
                else
                {
                    pasos.Add(new PasoRecorte
                    {
                        NumeroPaso = pasoNum,
                        Vertices = new List<PointF>(),
                        BordeClip = "Fin",
                        Explicacion = "El polígono está completamente fuera de la ventana.",
                        Aceptada = false,
                        Terminado = true
                    });
                }
                return pasos;
            }

            // 2. Insertar las intersecciones en la lista de la ventana en orden horario
            foreach (var inter in intersecciones)
            {
                InsertarInterseccionEnVentana(windowList, inter, xMin, xMax, yMin, yMax);
            }

            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoNum++,
                Vertices = GetPointsFromNodes(subjectList),
                BordeClip = "Intersecciones",
                Explicacion = $"Se detectaron {intersecciones.Count} intersecciones. Clasificadas como entrada/salida e insertadas en ambas listas.",
                Terminado = false,
                Aceptada = false
            });

            // 3. Travesía de las listas para generar el polígono recortado
            var resultadoVertices = new List<PointF>();
            var detallesTravesia = new List<string>();

            // Encontrar todas las intersecciones de entrada
            foreach (var subjectNode in subjectList)
            {
                if (subjectNode.IsIntersection && subjectNode.IsEntering && !subjectNode.Visited)
                {
                    var loop = new List<PointF>();
                    VertexNode currNode = subjectNode;
                    bool enPoligonoSujeto = true;

                    detallesTravesia.Add($"Iniciando travesía en punto de entrada ({currNode.Point.X:F1}, {currNode.Point.Y:F1}):");

                    while (currNode != null && !currNode.Visited)
                    {
                        currNode.Visited = true;
                        
                        // Marcar nodo homólogo en la otra lista
                        MarcarHomologoComoVisitado(subjectList, windowList, currNode);

                        loop.Add(currNode.Point);

                        if (enPoligonoSujeto)
                        {
                            // Seguir el polígono sujeto hasta encontrar una intersección de salida
                            int idx = subjectList.IndexOf(currNode);
                            int nextIdx = (idx + 1) % subjectList.Count;
                            VertexNode nextNode = subjectList[nextIdx];

                            if (currNode.IsIntersection && !currNode.IsEntering && currNode != subjectNode)
                            {
                                // Es una salida, cambiar a la ventana
                                enPoligonoSujeto = false;
                                detallesTravesia.Add($"- Llegó a salida ({currNode.Point.X:F1}, {currNode.Point.Y:F1}). Cambiando a lista de Ventana.");
                                // Encontrar este nodo en la lista de la ventana
                                currNode = EncontrarEnLista(windowList, currNode.Point);
                            }
                            else
                            {
                                currNode = nextNode;
                            }
                        }
                        else
                        {
                            // Seguir la ventana en sentido horario hasta encontrar una entrada
                            int idx = windowList.IndexOf(currNode);
                            int nextIdx = (idx + 1) % windowList.Count;
                            VertexNode nextNode = windowList[nextIdx];

                            if (currNode.IsIntersection && currNode.IsEntering && currNode.Point != subjectNode.Point)
                            {
                                // Regresar al polígono sujeto
                                enPoligonoSujeto = true;
                                detallesTravesia.Add($"- Llegó a entrada ({currNode.Point.X:F1}, {currNode.Point.Y:F1}). Cambiando a lista de Polígono.");
                                currNode = EncontrarEnLista(subjectList, currNode.Point);
                            }
                            else
                            {
                                currNode = nextNode;
                            }
                        }

                        // Detener si cerramos el ciclo
                        if (currNode != null && currNode.Point == subjectNode.Point)
                        {
                            detallesTravesia.Add($"- Cerró el ciclo en ({currNode.Point.X:F1}, {currNode.Point.Y:F1}).");
                            break;
                        }
                    }

                    if (loop.Count > 0)
                    {
                        resultadoVertices.AddRange(loop);
                    }
                }
            }

            // Si no se encontró ningún ciclo cerrado pero se procesó
            if (resultadoVertices.Count == 0)
            {
                resultadoVertices = GetPointsFromNodes(subjectList); // Fallback
            }

            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoNum,
                Vertices = resultadoVertices,
                BordeClip = "Fin",
                Explicacion = $"Travesía finalizada. Polígono recortado:\r\n" + string.Join("\r\n", detallesTravesia),
                Aceptada = resultadoVertices.Count > 0,
                Terminado = true
            });

            return pasos;
        }

        private void BuscarInterseccionEjeX(PointF a, PointF b, double xLim, double yMin, double yMax, ref List<Tuple<double, VertexNode>> list, double xMin, double xMax, double ywMin, double ywMax)
        {
            if (Math.Abs(b.X - a.X) > 0.0001)
            {
                double t = (xLim - a.X) / (b.X - a.X);
                if (t >= 0 && t <= 1)
                {
                    double y = a.Y + t * (b.Y - a.Y);
                    if (y >= yMin && y <= yMax)
                    {
                        PointF inter = new PointF((float)xLim, (float)y);
                        // Determinar si entra o sale
                        bool isEntering = b.X > a.X; // Si se mueve a la derecha, cruza de izquierda a derecha (puede entrar si es xMin, o salir si es xMax)
                        if (xLim == xMin) isEntering = b.X > a.X; // Cruza xMin a la derecha -> entra
                        if (xLim == xMax) isEntering = b.X < a.X; // Cruza xMax a la izquierda -> entra
                        
                        list.Add(new Tuple<double, VertexNode>(t, new VertexNode(inter, true, isEntering)));
                    }
                }
            }
        }

        private void BuscarInterseccionEjeY(PointF a, PointF b, double yLim, double xMin, double xMax, ref List<Tuple<double, VertexNode>> list, double xwMin, double xwMax, double yMin, double yMax)
        {
            if (Math.Abs(b.Y - a.Y) > 0.0001)
            {
                double t = (yLim - a.Y) / (b.Y - a.Y);
                if (t >= 0 && t <= 1)
                {
                    double x = a.X + t * (b.X - a.X);
                    if (x >= xMin && x <= xMax)
                    {
                        PointF inter = new PointF((float)x, (float)yLim);
                        bool isEntering = b.Y > a.Y;
                        if (yLim == yMin) isEntering = b.Y > a.Y; // Sube -> entra
                        if (yLim == yMax) isEntering = b.Y < a.Y; // Baja -> entra
                        
                        list.Add(new Tuple<double, VertexNode>(t, new VertexNode(inter, true, isEntering)));
                    }
                }
            }
        }

        private void InsertarInterseccionEnVentana(List<VertexNode> window, VertexNode inter, double xMin, double xMax, double yMin, double yMax)
        {
            // Determinar en qué borde está la intersección y su posición relativa
            PointF pt = inter.Point;

            // Borde superior: y = yMax, x de xMin a xMax
            if (Math.Abs(pt.Y - yMax) < 0.001)
            {
                InsertarOrdenadoSuperior(window, inter, xMin, xMax);
            }
            // Borde derecho: x = xMax, y de yMax a yMin (bajando)
            else if (Math.Abs(pt.X - xMax) < 0.001)
            {
                InsertarOrdenadoDerecho(window, inter, yMin, yMax);
            }
            // Borde inferior: y = yMin, x de xMax a xMin (hacia izquierda)
            else if (Math.Abs(pt.Y - yMin) < 0.001)
            {
                InsertarOrdenadoInferior(window, inter, xMin, xMax);
            }
            // Borde izquierdo: x = xMin, y de yMin a yMax (subiendo)
            else if (Math.Abs(pt.X - xMin) < 0.001)
            {
                InsertarOrdenadoIzquierdo(window, inter, yMin, yMax);
            }
        }

        private void InsertarOrdenadoSuperior(List<VertexNode> window, VertexNode inter, double xMin, double xMax)
        {
            // Insertar entre Top-Left (idx 0) y Top-Right (idx 1) ordenado por X ascendente
            int idx = 1;
            while (idx < window.Count && Math.Abs(window[idx].Point.Y - yMax(window)) < 0.001 && window[idx].Point.X < inter.Point.X)
            {
                idx++;
            }
            window.Insert(idx, inter);
        }

        private void InsertarOrdenadoDerecho(List<VertexNode> window, VertexNode inter, double yMin, double yMax)
        {
            // Insertar después de Top-Right ordenado por Y descendente
            int idx = 0;
            // Encontrar el primer nodo en la derecha
            while (idx < window.Count && !(Math.Abs(window[idx].Point.X - xMax(window)) < 0.001)) idx++;
            while (idx < window.Count && Math.Abs(window[idx].Point.X - xMax(window)) < 0.001 && window[idx].Point.Y > inter.Point.Y)
            {
                idx++;
            }
            window.Insert(idx, inter);
        }

        private void InsertarOrdenadoInferior(List<VertexNode> window, VertexNode inter, double xMin, double xMax)
        {
            // Insertar después de Bottom-Right ordenado por X descendente
            int idx = 0;
            while (idx < window.Count && !(Math.Abs(window[idx].Point.Y - yMin(window)) < 0.001)) idx++;
            while (idx < window.Count && Math.Abs(window[idx].Point.Y - yMin(window)) < 0.001 && window[idx].Point.X > inter.Point.X)
            {
                idx++;
            }
            window.Insert(idx, inter);
        }

        private void InsertarOrdenadoIzquierdo(List<VertexNode> window, VertexNode inter, double yMin, double yMax)
        {
            // Insertar después de Bottom-Left ordenado por Y ascendente
            int idx = 0;
            while (idx < window.Count && !(Math.Abs(window[idx].Point.X - xMin(window)) < 0.001)) idx++;
            while (idx < window.Count && Math.Abs(window[idx].Point.X - xMin(window)) < 0.001 && window[idx].Point.Y < inter.Point.Y)
            {
                idx++;
            }
            window.Insert(idx, inter);
        }

        // Helpers de límites de la ventana
        private double xMin(List<VertexNode> window) { return Math.Min(window[0].Point.X, window[2].Point.X); }
        private double xMax(List<VertexNode> window) { return Math.Max(window[0].Point.X, window[2].Point.X); }
        private double yMin(List<VertexNode> window) { return Math.Min(window[0].Point.Y, window[2].Point.Y); }
        private double yMax(List<VertexNode> window) { return Math.Max(window[0].Point.Y, window[2].Point.Y); }

        private VertexNode EncontrarEnLista(List<VertexNode> list, PointF pt)
        {
            foreach (var node in list)
            {
                if (Math.Abs(node.Point.X - pt.X) < 0.01 && Math.Abs(node.Point.Y - pt.Y) < 0.01)
                    return node;
            }
            return null;
        }

        private void MarcarHomologoComoVisitado(List<VertexNode> list1, List<VertexNode> list2, VertexNode node)
        {
            VertexNode homo1 = EncontrarEnLista(list1, node.Point);
            if (homo1 != null) homo1.Visited = true;
            
            VertexNode homo2 = EncontrarEnLista(list2, node.Point);
            if (homo2 != null) homo2.Visited = true;
        }

        private List<PointF> GetPointsFromNodes(List<VertexNode> nodes)
        {
            var pts = new List<PointF>();
            foreach (var n in nodes)
            {
                pts.Add(n.Point);
            }
            return pts;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Weiler-Atherton (Recorte de Polígonos)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Permite recortar polígonos cóncavos y convexos arbitrarios:\r\n" +
                "1. Encuentra todas las intersecciones y las etiqueta como entrada o salida.\r\n" +
                "2. Inserta las intersecciones ordenadas en la lista del polígono y de la ventana.\r\n" +
                "3. Inicia en un nodo de entrada y recorre la lista del polígono sujeto.\r\n" +
                "4. En una intersección de salida, cambia a la lista de la ventana y la recorre en sentido horario.\r\n" +
                "5. Repite el cruce de listas hasta cerrar el ciclo y generar los polígonos recortados.";
        }
    }
}
