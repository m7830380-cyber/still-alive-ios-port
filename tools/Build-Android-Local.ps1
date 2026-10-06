param(
    [Parameter(Mandatory)]
    [string]$ProjectPath,
    [string]$UnityExe = "C:\Program Files\Unity\Hub\Editor\2022.3.5f1\Editor\Unity.exe"
)

if (-not (Test-Path -LiteralPath $UnityExe)) {
    throw "Unity not found at $UnityExe. Install 2022.3.5f1 + Android Build Support in Unity Hub."
}

$log = Join-Path $ProjectPath "build-android.log"
& $UnityExe -batchmode -quit -nographics -projectPath $ProjectPath `
    -executeMethod StillAliveBuild.BuildAndroidApk -logFile $log

if ($LASTEXITCODE -ne 0) {
    throw "Unity exited $LASTEXITCODE. See $log"
}

Write-Host "APK: $(Join-Path $ProjectPath 'build\Android\Android.apk')"
