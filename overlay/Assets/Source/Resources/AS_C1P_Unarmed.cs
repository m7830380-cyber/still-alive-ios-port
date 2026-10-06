// CI / mobile slim build: full anim set is ~96k lines and crashes Roslyn on cloud runners.
namespace MEdge.Source
{
	using Core;
	using Engine;
	using TdGame;

	public static partial class Asset
	{
		public static TdAnimSet Get_AS_C1P_Unarmed() => new TdAnimSet
		{
			PreviewSkelMeshName = (name)"CH_TKY_Crim_Fixer_1P.SK_UpperBody",
		};
	}
}
