using cp4_GeoMasterAPI.Interfaces;

namespace cp4_GeoMasterAPI.Entities
{
    public class Ciruclo : ICalculos2D
    {
        public double Raio {  get; set; }

        public double CalcularArea() => Math.PI * (Raio * Raio);
        public double CalcularPerimetro() => 2 * Math.PI * Raio;
    }
}
