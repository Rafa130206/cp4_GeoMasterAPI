using cp4_GeoMasterAPI.Interfaces;

namespace cp4_GeoMasterAPI.Service
{
    public class CalculadoraService : ICalculadoraService
    {
        // ---- API pública exigida (DIP) ----
        public double CalcularArea(object forma) => Invoke(() => CalcularArea((dynamic)forma), nameof(CalcularArea), forma);
        public double CalcularPerimetro(object forma) => Invoke(() => CalcularPerimetro((dynamic)forma), nameof(CalcularPerimetro), forma);
        public double CalcularVolume(object forma) => Invoke(() => CalcularVolume((dynamic)forma), nameof(CalcularVolume), forma);
        public double CalcularAreaSuperficial(object forma) => Invoke(() => CalcularAreaSuperficial((dynamic)forma), nameof(CalcularAreaSuperficial), forma);

        // ---- Mecanismo central sem if/switch ----
        private static T Invoke<T>(Func<T> action, string operacao, object forma)
        {
            try { return action(); }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                throw new NotSupportedException(
                    $"A forma {forma?.GetType().Name ?? "<null>"} não suporta a operação {operacao}.");
            }
        }

        // ---- Sobrecargas-alvo (abrindo por extensao das interfaces) ----
        private double CalcularArea(ICalculos2D f) => f.CalcularArea();
        private double CalcularPerimetro(ICalculos2D f) => f.CalcularPerimetro();
        private double CalcularVolume(ICalculos3D f) => f.CalcularVolume();
        private double CalcularAreaSuperficial(ICalculos3D f) => f.CalcularAreaSuperficial();
    }
}
