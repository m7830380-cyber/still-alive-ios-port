#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public static class StillAliveBuild
{
    static readonly string[] Scenes = { "Assets/Scenes/Cranes_Off.unity" };

    public static void BuildIosUnsigned() => BuildMobile(BuildTarget.iOS, "build/iOS");

    public static void BuildAndroidApk() => BuildMobile(BuildTarget.Android, "build/Android/StillAlive.apk");

    static void BuildMobile(BuildTarget target, string outputPath)
    {
        var group = BuildPipeline.GetBuildTargetGroup(target);
        EditorUserBuildSettings.SwitchActiveBuildTarget(group, target);

        if (target == BuildTarget.iOS)
        {
            EditorUserBuildSettings.iOSBuildConfigType = iOSBuildType.Release;
            PlayerSettings.iOS.appleDeveloperTeamID = "";
            PlayerSettings.iOS.appleEnableAutomaticSigning = false;
        }

        if (target == BuildTarget.Android)
        {
            PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel24;
            EditorUserBuildSettings.buildAppBundle = false;
        }

        var options = new BuildPlayerOptions
        {
            scenes = Scenes,
            locationPathName = outputPath,
            target = target,
            options = BuildOptions.CompressWithLz4,
        };

        var report = BuildPipeline.BuildPlayer(options);
        if (report.summary.result != BuildResult.Succeeded)
            throw new System.Exception($"{target} build failed: {report.summary.result}");
    }
}
#endif
