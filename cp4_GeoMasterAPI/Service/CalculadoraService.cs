using cp4_GeoMasterAPI.Interfaces;

namespace cp4_GeoMasterAPI.Service
{
    public class CalculadoraService : ICalculadoraService
    {
        public double CalcularArea(object forma)
        {
            if (forma is ICalculos2D f2d)
                return f2d.CalcularArea();

            throw new NotSupportedException($"A forma {forma.GetType().Name} não suporta cálculo de área.");
        }

        public double CalcularPerimetro(object forma)
        {
            if (forma is ICalculos2D f2d)
                return f2d.CalcularPerimetro();

            throw new NotSupportedException($"A forma {forma.GetType().Name} não suporta cálculo de perímetro.");
        }

        public double CalcularVolume(object forma)
        {
            if (forma is ICalculos3D f3d)
                return f3d.CalcularVolume();

            throw new NotSupportedException($"A forma {forma.GetType().Name} não suporta cálculo de volume.");
        }

        public double CalcularAreaSuperficial(object forma)
        {
            if (forma is ICalculos3D f3d)
                return f3d.CalcularAreaSuperficial();

            throw new NotSupportedException($"A forma {forma.GetType().Name} não suporta cálculo de área superficial.");
        }
    }

}
