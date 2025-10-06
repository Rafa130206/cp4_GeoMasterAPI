namespace cp4_GeoMasterAPI.Validacoes
{

	public interface IContainmentRuleBase { }

	public interface IContainmentRule<in TOuter, in TInner> : IContainmentRuleBase
	{
		bool Contains(TOuter outerShape, TInner innerShape);
	}
}
