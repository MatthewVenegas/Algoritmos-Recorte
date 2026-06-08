using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Recorte
{
    public class AlgoritmoLiangBarsky
    {
        public List<PasoRecorte> CalcularRecorte(double x0, double y0, double x1, double y1, double xMin, double xMax, double yMin, double yMax)
        {
            var pasos = new List<PasoRecorte>();
            double dx = x1 - x0;
            double dy = y1 - y0;

            double u1 = 0.0;
            double u2 = 1.0;
            int stepNum = 1;

            // Paso 1: Estado Inicial
            pasos.Add(new PasoRecorte
            {
                NumeroPaso = stepNum++,
                X0 = x0,
                Y0 = y0,
                X1 = x1,
                Y1 = y1,
                Explicacion = $"Inicio del algoritmo Liang-Barsky.\r\nParámetros iniciales: u₁ = 0.0, u₂ = 1.0.\r\nΔx = {dx:F2}, Δy = {dy:F2}.",
                Aceptada = false,
                Terminado = false
            });

            double[] p = { -dx, dx, -dy, dy };
            double[] q = { x0 - xMin, xMax - x0, y0 - yMin, yMax - y0 };
            string[] nombresBorde = { "Izquierdo (xMin)", "Derecho (xMax)", "Abajo (yMin)", "Arriba (yMax)" };

            bool rechazado = false;

            for (int i = 0; i < 4; i++)
            {
                double pk = p[i];
                double qk = q[i];
                string borde = nombresBorde[i];

                double uOld1 = u1;
                double uOld2 = u2;

                string explicacionBorde = $"Analizando borde {borde}: p = {pk:F2}, q = {qk:F2}.\r\n";

                if (pk == 0) // Paralela al borde
                {
                    if (qk < 0)
                    {
                        rechazado = true;
                        explicacionBorde += "La línea es paralela y está completamente fuera de este borde. Rechazo trivial.";
                    }
                    else
                    {
                        explicacionBorde += "La línea es paralela y está en el lado visible de este borde.";
                    }
                }
                else
                {
                    double r = qk / pk;
                    if (pk < 0) // u1 (entra)
                    {
                        explicacionBorde += $"El vector entra por este borde. r = q/p = {r:F4}.\r\n";
                        if (r > u2)
                        {
                            rechazado = true;
                            explicacionBorde += $"Rechazo: r ({r:F4}) > u₂ ({u2:F4}), por lo que u₁ superaría a u₂.";
                        }
                        else
                        {
                            u1 = Math.Max(u1, r);
                            explicacionBorde += $"u₁ = Max(u₁ ({uOld1:F4}), r ({r:F4})) = {u1:F4}.";
                        }
                    }
                    else // pk > 0 -> u2 (sale)
                    {
                        explicacionBorde += $"El vector sale por este borde. r = q/p = {r:F4}.\r\n";
                        if (r < u1)
                        {
                            rechazado = true;
                            explicacionBorde += $"Rechazo: r ({r:F4}) < u₁ ({u1:F4}), por lo que u₂ sería menor que u₁.";
                        }
                        else
                        {
                            u2 = Math.Min(u2, r);
                            explicacionBorde += $"u₂ = Min(u₂ ({uOld2:F4}), r ({r:F4})) = {u2:F4}.";
                        }
                    }
                }

                // Calcular puntos parciales basados en u1 y u2 actuales
                double currX0 = x0 + u1 * dx;
                double currY0 = y0 + u1 * dy;
                double currX1 = x0 + u2 * dx;
                double currY1 = y0 + u2 * dy;

                var paso = new PasoRecorte
                {
                    NumeroPaso = stepNum++,
                    X0 = Math.Round(currX0, 2),
                    Y0 = Math.Round(currY0, 2),
                    X1 = Math.Round(currX1, 2),
                    Y1 = Math.Round(currY1, 2),
                    Explicacion = explicacionBorde,
                    Aceptada = false,
                    Terminado = rechazado
                };

                pasos.Add(paso);

                if (rechazado)
                    break;
            }

            if (!rechazado)
            {
                // Paso final: Mostrar resultado aceptado
                double finalX0 = x0 + u1 * dx;
                double finalY0 = y0 + u1 * dy;
                double finalX1 = x0 + u2 * dx;
                double finalY1 = y0 + u2 * dy;

                pasos.Add(new PasoRecorte
                {
                    NumeroPaso = stepNum,
                    X0 = Math.Round(finalX0, 2),
                    Y0 = Math.Round(finalY0, 2),
                    X1 = Math.Round(finalX1, 2),
                    Y1 = Math.Round(finalY1, 2),
                    Explicacion = $"Recorte finalizado y aceptado.\r\nLínea recortada desde ({finalX0:F2}, {finalY0:F2}) hasta ({finalX1:F2}, {finalY1:F2}).",
                    Aceptada = true,
                    Terminado = true
                });
            }

            return pasos;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo Liang-Barsky (Paramétrico)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "Utiliza la ecuación paramétrica de la línea:\r\n" +
                "x = x₀ + u·Δx,   y = y₀ + u·Δy  (0 ≤ u ≤ 1)\r\n\r\n" +
                "Plantea 4 desigualdades: u·p_k ≤ q_k, donde:\r\n" +
                "k=1 (Izquierda): p₁ = -Δx, q₁ = x₀ - xMin\r\n" +
                "k=2 (Derecha):   p₂ =  Δx, q₂ = xMax - x₀\r\n" +
                "k=3 (Abajo):     p₃ = -Δy, q₃ = y₀ - yMin\r\n" +
                "k=4 (Arriba):    p₄ =  Δy, q₄ = yMax - y₀\r\n\r\n" +
                "Reglas de actualización:\r\n" +
                "- Si p_k < 0: el vector entra. u₁ = Max(u₁, q_k/p_k)\r\n" +
                "- Si p_k > 0: el vector sale.  u₂ = Min(u₂, q_k/p_k)\r\n" +
                "- Si u₁ > u₂: la línea está completamente fuera (Rechazar).";
        }
    }
}
