using System.Reflection;

namespace cp4_GeoMasterAPI.Validacoes
{
    public class ValidacaoContencaoService : IValidacaoContencaoService
    {
        private readonly IEnumerable<IContainmentRuleBase> _rules; // regras já instanciadas via DI

        public ValidacaoContencaoService(IEnumerable<IContainmentRuleBase> rules)
        {
            _rules = rules;
        }

        public bool EstaContida(object formaExterna, object formaInterna)
        {
            // Encontra uma regra cujo tipo genérico feche como (TOuter=tipoExterno, TInner=tipoInterno)
            var outerType = formaExterna?.GetType();
            var innerType = formaInterna?.GetType();

            if (outerType is null || innerType is null)
                throw new ArgumentException("Formas inválidas.");

            foreach (var rule in _rules)
            {
                var iface = rule.GetType().GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType &&
                                         i.GetGenericTypeDefinition() == typeof(IContainmentRule<,>));

                if (iface == null) continue;

                var args = iface.GetGenericArguments();
                if (args[0].IsAssignableFrom(outerType) &&
                    args[1].IsAssignableFrom(innerType))
                {
                    // invoca Contains dinamicamente
                    var method = iface.GetMethod("Contains")!;
                    Console.WriteLine($"[DEBUG] Usando regra: {rule.GetType().Name}");
                    return (bool)method.Invoke(rule, new[] { formaExterna, formaInterna })!;
                }
            }

            throw new NotSupportedException(
                $"Não há regra de contenção registrada para {outerType?.Name} ? {innerType?.Name}.");
        }
    }
}
