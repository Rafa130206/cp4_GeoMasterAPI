using cp4_GeoMasterAPI.Entities;

namespace cp4_GeoMasterAPI.Validacoes.Rules
{
    public class RetanguloRetanguloRule : IContainmentRule<Retangulo, Retangulo>
    {
        public bool Contains(Retangulo outer, Retangulo inner)
        {
            return inner.Largura <= outer.Largura && inner.Altura <= outer.Altura;
        }
    }
}
