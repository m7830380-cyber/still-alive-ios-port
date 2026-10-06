// CI / mobile slim build: full anim set is ~80k lines and crashes Roslyn on cloud runners.
namespace MEdge.Source
{
	using Core;
	using Engine;
	using TdGame;

	public static partial class Asset
	{
		public static TdAnimSet Get_AS_F3P_Unarmed() => new TdAnimSet
		{
			PreviewSkelMeshName = (name)"CH_TKY_Crim_Fixer_3P.SK_Body",
		};
	}
}
