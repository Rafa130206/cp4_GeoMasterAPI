using cp4_GeoMasterAPI.Interfaces;

namespace cp4_GeoMasterAPI.Entities
{
    public class Retangulo : ICalculos2D
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        public double CalcularArea() => Largura * Altura;
        public double CalcularPerimetro() => 2 * (Largura + Altura);
    }
}