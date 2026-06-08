using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Recorte
{
    public class AlgoritmoCohenSutherland
    {
        // Códigos de región (Bits)
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
            bool terminado = false;

            while (!terminado)
            {
                int cod0 = CalcularCodigoRegion(x0, y0, xMin, xMax, yMin, yMax);
                int cod1 = CalcularCodigoRegion(x1, y1, xMin, xMax, yMin, yMax);

                var paso = new PasoRecorte
                {
                    NumeroPaso = pasoActual++,
                    X0 = Math.Round(x0, 2),
                    Y0 = Math.Round(y0, 2),
                    X1 = Math.Round(x1, 2),
                    Y1 = Math.Round(y1, 2),
                    Codigo0 = cod0,
                    Codigo1 = cod1
                };

                // Caso 1: Aceptación trivial (ambos puntos dentro, OR == 0)
                if ((cod0 | cod1) == 0)
                {
                    terminado = true;
                    paso.Explicacion = $"Aceptación trivial. Ambos puntos (OR = 0) están dentro de la ventana.";
                    paso.Terminado = true;
                    paso.Aceptada = true;
                }
                // Caso 2: Rechazo trivial (ambos puntos comparten una región exterior, AND != 0)
                else if ((cod0 & cod1) != 0)
                {
                    terminado = true;
                    paso.Explicacion = $"Rechazo trivial. Ambos puntos (AND != 0) están fuera en el mismo lado.";
                    paso.Terminado = true;
                    paso.Aceptada = false;
                }
                // Caso 3: Intersección (Recortar)
                else
                {
                    double x = 0, y = 0;
                    // Elegimos un punto que esté fuera de la ventana
                    int codFuera = (cod0 != 0) ? cod0 : cod1;

                    // Encontrar la intersección usando fórmulas matemáticas
                    if ((codFuera & ARRIBA) != 0)
                    {
                        x = x0 + (x1 - x0) * (yMax - y0) / (y1 - y0);
                        y = yMax;
                    }
                    else if ((codFuera & ABAJO) != 0)
                    {
                        x = x0 + (x1 - x0) * (yMin - y0) / (y1 - y0);
                        y = yMin;
                    }
                    else if ((codFuera & DERECHA) != 0)
                    {
                        y = y0 + (y1 - y0) * (xMax - x0) / (x1 - x0);
                        x = xMax;
                    }
                    else if ((codFuera & IZQUIERDA) != 0)
                    {
                        y = y0 + (y1 - y0) * (xMin - x0) / (x1 - x0);
                        x = xMin;
                    }

                    paso.Explicacion = $"Intersección calculada en ({Math.Round(x, 2)}, {Math.Round(y, 2)}). Moviendo punto.";

                    // Reemplazamos el punto original por la intersección
                    if (codFuera == cod0)
                    {
                        x0 = x; y0 = y;
                    }
                    else
                    {
                        x1 = x; y1 = y;
                    }
                }
                pasos.Add(paso);
            }
            return pasos;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Cohen-Sutherland\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Divide el espacio en 9 regiones, asignando un código de 4 bits a cada punto:\r\n" +
                "Bit 1: Izquierda | Bit 2: Derecha | Bit 3: Abajo | Bit 4: Arriba\r\n\r\n" +
                "Reglas lógicas:\r\n" +
                "1. Si P1 OR P2 = 0000 ➔ Aceptación Trivial (adentro).\r\n" +
                "2. Si P1 AND P2 ≠ 0000 ➔ Rechazo Trivial (afuera en un mismo lado).\r\n" +
                "3. Sino ➔ Calcular intersección con un borde y repetir el proceso.";
        }
    }
}