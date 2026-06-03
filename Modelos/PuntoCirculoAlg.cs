namespace AlgoritmosDeDiscretizacion.Modelos
{
    /// <summary>Representa un punto calculado por un algoritmo de círculo (incluye simetría).</summary>
    public class PuntoCirculoAlg
    {
        public int Paso        { get; set; }
        public int X           { get; set; }
        public int Y           { get; set; }
        public int P           { get; set; }   // Valor del parámetro de decisión
        public string Decision  { get; set; }  // "E" = Este, "SE" = SurEste, etc.
        public string Octante   { get; set; }
    }
}
