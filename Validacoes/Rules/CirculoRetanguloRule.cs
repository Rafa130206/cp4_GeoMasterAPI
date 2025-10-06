using cp4_GeoMasterAPI.Entities;

namespace cp4_GeoMasterAPI.Validacoes.Rules
{
    public class CirculoRetanguloRule : IContainmentRule<Circulo, Retangulo>
        {
            public bool Contains( Circulo outer, Retangulo inner)
            {
            double diagonal = Math.Sqrt(inner.Largura * inner.Largura + inner.Altura * inner.Altura);
            return diagonal <= outer.Raio * 2;

            }
        }
    }