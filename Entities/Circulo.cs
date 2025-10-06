using cp4_GeoMasterAPI.Interfaces;

namespace cp4_GeoMasterAPI.Entities
{
    public class Circulo : ICalculos2D
    {
        
        public double Raio { get; set; }

        public double CalcularArea() => Math.PI * Math.Pow(Raio, 2);
        public double CalcularPerimetro() => 2 * Math.PI * Raio;
    }
}