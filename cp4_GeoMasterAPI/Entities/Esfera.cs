using cp4_GeoMasterAPI.Interfaces;

namespace cp4_GeoMasterAPI.Entities
{
    public class Esfera : ICalculos3D
    {
        public double Raio { get; set; }

        public double CalcularVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
        public double CalcularAreaSuperficial() => 4 * Math.PI * Math.Pow(Raio, 2);
    }
}