using cp4_GeoMasterAPI.Entities;

namespace cp4_GeoMasterAPI.Validacoes.Rules
{
    public class CirculoCirculoRule : IContainmentRule<Circulo, Circulo>
    {
        public bool Contains(Circulo outer, Circulo inner)
        {
            return inner.Raio <= outer.Raio;
        }
    }
}