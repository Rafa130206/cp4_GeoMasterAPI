namespace cp4_GeoMasterAPI.Validacoes
{
	public interface IContainmentRule<in TOuter, in TInner>
	{
		bool Contains(TOuter outerShape, TInner innerShape);
	}
}
