using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmosDeDiscretizacion.Modelos
{
    public class PasoRecorte
    {
        public int NumeroPaso { get; set; }
        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }

        // Códigos de bits para cada extremo (ej. 0000, 1001)
        public int Codigo0 { get; set; }
        public int Codigo1 { get; set; }

        // Mensaje que explica qué decisión tomó el algoritmo en este paso
        public string Explicacion { get; set; }

        // Indica si la línea final fue aceptada (true) o completamente rechazada (false)
        public bool Aceptada { get; set; }
        public bool Terminado { get; set; }

        // Para polígonos: Lista de vértices del polígono en este paso
        public List<PointF> Vertices { get; set; }

        // Para polígonos: Borde de la ventana contra el cual se está recortando (ej. "Izquierdo", "Derecho", "Abajo", "Arriba")
        public string BordeClip { get; set; }
    }
}