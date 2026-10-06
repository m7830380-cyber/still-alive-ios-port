using UnityEngine;

namespace MEdge.Engine
{
	/// <summary>
	/// Mirror's Edge gameplay was tuned around ~62 Hz; Still Alive README warns higher FPS can break logic.
	/// </summary>
	public static class StillAliveRuntimeBootstrap
	{
		const int GameplayTargetFps = 62;
		const float GameplayFixedDelta = 1f / GameplayTargetFps;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void Configure()
		{
			Application.targetFrameRate = GameplayTargetFps;
			QualitySettings.vSyncCount = 0;
			Time.fixedDeltaTime = GameplayFixedDelta;
			Time.maximumDeltaTime = GameplayFixedDelta * 4f;

#if UNITY_IOS || UNITY_ANDROID
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
		}
	}
}
