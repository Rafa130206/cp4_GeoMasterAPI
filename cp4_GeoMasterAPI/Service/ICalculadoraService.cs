namespace cp4_GeoMasterAPI.Service
{
    public interface ICalculadoraService
    {
        double CalcularArea(object forma);
        double CalcularPerimetro(object forma);
        double CalcularVolume(object forma);
        double CalcularAreaSuperficial(object forma);
    }
}
