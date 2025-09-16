using cp4_GeoMasterAPI.Entities;

namespace cp4_GeoMasterAPI.Validacoes.Rules
{
    public class RetanguloCirculoRule : IContainmentRule<Retangulo, Circulo>
    {
        public bool Contains(Retangulo outer, Circulo inner)
        {
            Console.WriteLine($"[DEBUG] Retângulo: {outer.Largura}x{outer.Altura}, Raio círculo: {inner.Raio}");
            double diametro = inner.Raio * 2;
            bool resultado = diametro <= outer.Largura && diametro <= outer.Altura;
            Console.WriteLine($"[DEBUG] Diametro {diametro}, Resultado {resultado}");
            return resultado;
        }

    }
}