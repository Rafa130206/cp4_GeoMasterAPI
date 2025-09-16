using cp4_GeoMasterAPI.Entities;

namespace cp4_GeoMasterAPI.Validacoes.Rules
{
    public class RetanguloCirculoRule : IContainmentRule<Retangulo, Circulo>
    {
        public bool Contains(Retangulo outer, Circulo inner)
        {
            return inner.Raio * 2 <= outer.Largura && inner.Raio * 2 <= outer.Altura;
        }
    }
}