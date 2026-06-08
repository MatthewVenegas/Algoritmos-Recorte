using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Recorte
{
    public class AlgoritmoSubdivisionPuntoMedio
    {
        private const int ADENTRO = 0; // 0000
        private const int IZQUIERDA = 1; // 0001
        private const int DERECHA = 2; // 0010
        private const int ABAJO = 4; // 0100
        private const int ARRIBA = 8; // 1000

        private int CalcularCodigoRegion(double x, double y, double xMin, double xMax, double yMin, double yMax)
        {
            int codigo = ADENTRO;
            if (x < xMin) codigo |= IZQUIERDA;
            else if (x > xMax) codigo |= DERECHA;
            if (y < yMin) codigo |= ABAJO;
            else if (y > yMax) codigo |= ARRIBA;
            return codigo;
        }

        public List<PasoRecorte> CalcularRecorte(double x0, double y0, double x1, double y1, double xMin, double xMax, double yMin, double yMax)
        {
            var pasos = new List<PasoRecorte>();
            int pasoActual = 1;

            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoActual++,
                X0 = Math.Round(x0, 2),
                Y0 = Math.Round(y0, 2),
                X1 = Math.Round(x1, 2),
                Y1 = Math.Round(y1, 2),
                Explicacion = $"Inicio del algoritmo de Subdivisión de Punto Medio.\r\nLínea original: ({x0:F1}, {y0:F1}) a ({x1:F1}, {y1:F1}).",
                Terminado = false,
                Aceptada = false
            });

            int cod0 = CalcularCodigoRegion(x0, y0, xMin, xMax, yMin, yMax);
            int cod1 = CalcularCodigoRegion(x1, y1, xMin, xMax, yMin, yMax);

            if ((cod0 | cod1) == 0)
            {
                pasos.Add(new PasoRecorte
                {
                    NumeroPaso = pasoActual,
                    X0 = Math.Round(x0, 2),
                    Y0 = Math.Round(y0, 2),
                    X1 = Math.Round(x1, 2),
                    Y1 = Math.Round(y1, 2),
                    Explicacion = "Aceptación trivial. Ambos extremos están adentro de la ventana.",
                    Terminado = true,
                    Aceptada = true
                });
                return pasos;
            }

            if ((cod0 & cod1) != 0)
            {
                pasos.Add(new PasoRecorte
                {
                    NumeroPaso = pasoActual,
                    X0 = Math.Round(x0, 2),
                    Y0 = Math.Round(y0, 2),
                    X1 = Math.Round(x1, 2),
                    Y1 = Math.Round(y1, 2),
                    Explicacion = "Rechazo trivial. Ambos extremos están del mismo lado exterior.",
                    Terminado = true,
                    Aceptada = false
                });
                return pasos;
            }

            double newX0 = x0, newY0 = y0;
            if (cod0 != 0)
            {
                double ax = x0, ay = y0;
                double bx = x1, by = y1;
                
                // Búsqueda binaria para encontrar la primera intersección
                for (int iter = 0; iter < 12; iter++)
                {
                    double mx = (ax + bx) / 2.0;
                    double my = (ay + by) / 2.0;
                    int codM = CalcularCodigoRegion(mx, my, xMin, xMax, yMin, yMax);
                    
                    if ((CalcularCodigoRegion(ax, ay, xMin, xMax, yMin, yMax) & codM) != 0)
                    {
                        ax = mx; ay = my;
                    }
                    else
                    {
                        bx = mx; by = my;
                    }
                }
                newX0 = ax; newY0 = ay;
                pasos.Add(new PasoRecorte
                {
                    NumeroPaso = pasoActual++,
                    X0 = Math.Round(newX0, 2),
                    Y0 = Math.Round(newY0, 2),
                    X1 = Math.Round(x1, 2),
                    Y1 = Math.Round(y1, 2),
                    Explicacion = $"Intersección para P₀ aproximada en ({newX0:F2}, {newY0:F2}) tras subdividir.",
                    Terminado = false,
                    Aceptada = false
                });
            }

            double newX1 = x1, newY1 = y1;
            if (cod1 != 0)
            {
                double ax = x1, ay = y1;
                double bx = x0, by = y0;
                
                for (int iter = 0; iter < 12; iter++)
                {
                    double mx = (ax + bx) / 2.0;
                    double my = (ay + by) / 2.0;
                    int codM = CalcularCodigoRegion(mx, my, xMin, xMax, yMin, yMax);
                    
                    if ((CalcularCodigoRegion(ax, ay, xMin, xMax, yMin, yMax) & codM) != 0)
                    {
                        ax = mx; ay = my;
                    }
                    else
                    {
                        bx = mx; by = my;
                    }
                }
                newX1 = ax; newY1 = ay;
                pasos.Add(new PasoRecorte
                {
                    NumeroPaso = pasoActual++,
                    X0 = Math.Round(newX0, 2),
                    Y0 = Math.Round(newY0, 2),
                    X1 = Math.Round(newX1, 2),
                    Y1 = Math.Round(newY1, 2),
                    Explicacion = $"Intersección para P₁ aproximada en ({newX1:F2}, {newY1:F2}) tras subdividir.",
                    Terminado = false,
                    Aceptada = false
                });
            }

            int finalCod0 = CalcularCodigoRegion(newX0, newY0, xMin, xMax, yMin, yMax);
            int finalCod1 = CalcularCodigoRegion(newX1, newY1, xMin, xMax, yMin, yMax);
            bool finalAceptada = (finalCod0 | finalCod1) == 0;

            pasos.Add(new PasoRecorte
            {
                NumeroPaso = pasoActual,
                X0 = Math.Round(newX0, 2),
                Y0 = Math.Round(newY0, 2),
                X1 = Math.Round(newX1, 2),
                Y1 = Math.Round(newY1, 2),
                Explicacion = finalAceptada ? $"Recorte exitoso. Línea final aceptada." : "Línea final rechazada.",
                Terminado = true,
                Aceptada = finalAceptada
            });

            return pasos;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Subdivisión de Punto Medio\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Es un híbrido entre Cohen-Sutherland y búsqueda binaria:\r\n" +
                "1. Si OR = 0000 ➔ Aceptación Trivial.\r\n" +
                "2. Si AND ≠ 0000 ➔ Rechazo Trivial.\r\n" +
                "3. Si no, divide el segmento a la mitad (punto medio).\r\n" +
                "4. Si la mitad comparte código con un extremo, se descarta esa mitad y se repite la búsqueda binaria para encontrar la intersección exacta con los bordes de la ventana.";
        }
    }
}
