#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public static class StillAliveBuild
{
    static readonly string[] Scenes = { "Assets/Scenes/Cranes_Off.unity" };

    public static void BuildIosUnsigned()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);
        EditorUserBuildSettings.iOSBuildConfigType = iOSBuildType.Release;

        PlayerSettings.iOS.appleDeveloperTeamID = "";
        PlayerSettings.iOS.appleEnableAutomaticSigning = false;

        var options = new BuildPlayerOptions
        {
            scenes = Scenes,
            locationPathName = "build/iOS",
            target = BuildTarget.iOS,
            options = BuildOptions.CompressWithLz4,
        };

        var report = BuildPipeline.BuildPlayer(options);
        if (report.summary.result != BuildResult.Succeeded)
            throw new System.Exception($"iOS build failed: {report.summary.result}");
    }
}
#endif
