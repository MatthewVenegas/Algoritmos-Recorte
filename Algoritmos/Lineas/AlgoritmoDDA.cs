using System;
using System.Collections.Generic;
using AlgoritmosDeDiscretizacion.Modelos;

namespace AlgoritmosDeDiscretizacion.Algoritmos.Lineas
{
    /// <summary>
    /// Algoritmo DDA (Digital Differential Analyzer).
    /// Calcula incrementos fraccionarios dividiendo Δx o Δy entre el mayor de los dos.
    /// Fórmula: xIncr = dx/pasos, yIncr = dy/pasos  donde pasos = max(|dx|,|dy|)
    /// </summary>
    public class AlgoritmoDDA
    {
        public List<PuntoLinea> CalcularPuntos(int x0, int y0, int x1, int y1)
        {
            var puntos = new List<PuntoLinea>();
            int dx = x1 - x0;
            int dy = y1 - y0;
            int pasos = Math.Max(Math.Abs(dx), Math.Abs(dy));

            if (pasos == 0)
            {
                puntos.Add(new PuntoLinea { Paso = 0, X = x0, Y = y0, XPixel = x0, YPixel = y0, Decision = "Punto único" });
                return puntos;
            }

            double xIncr = (double)dx / pasos;
            double yIncr = (double)dy / pasos;
            double x = x0;
            double y = y0;

            for (int i = 0; i <= pasos; i++)
            {
                puntos.Add(new PuntoLinea
                {
                    Paso   = i,
                    X      = Math.Round(x, 2),
                    Y      = Math.Round(y, 2),
                    XPixel = (int)Math.Round(x),
                    YPixel = (int)Math.Round(y),
                    Decision = $"x+={Math.Round(xIncr,2)}, y+={Math.Round(yIncr,2)}"
                });
                x += xIncr;
                y += yIncr;
            }
            return puntos;
        }

        public double CalcularPendiente(int x0, int y0, int x1, int y1)
        {
            if (x1 == x0) return double.NaN;
            return (double)(y1 - y0) / (x1 - x0);
        }

        public double CalcularIntercepto(int x0, int y0, double m)
        {
            return y0 - m * x0;
        }

        public string ObtenerExplicacion()
        {
            return
                "Algoritmo DDA (Digital Differential Analyzer)\r\n" +
                "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n" +
                "1. Calcular: dx = x1-x0,  dy = y1-y0\r\n" +
                "2. pasos = max(|dx|, |dy|)\r\n" +
                "3. xIncr = dx / pasos\r\n" +
                "   yIncr = dy / pasos\r\n" +
                "4. Inicio: x = x0, y = y0\r\n" +
                "5. Para k = 0..pasos:\r\n" +
                "      pixel(round(x), round(y))\r\n" +
                "      x += xIncr\r\n" +
                "      y += yIncr\r\n\r\n" +
                "⚡ Usa aritmética de punto flotante.\r\n" +
                "✔ Sencillo de implementar.\r\n" +
                "✘ Más lento que Bresenham por multiplicaciones.";
        }
    }
}
