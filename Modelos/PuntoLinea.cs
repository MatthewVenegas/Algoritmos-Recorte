namespace AlgoritmosDeDiscretizacion.Modelos
{
    /// <summary>Representa un punto generado por un algoritmo de línea.</summary>
    public class PuntoLinea
    {
        public int Paso    { get; set; }
        public double X    { get; set; }
        public double Y    { get; set; }
        public int XPixel  { get; set; }
        public int YPixel  { get; set; }
        public string Decision { get; set; }
    }
}
