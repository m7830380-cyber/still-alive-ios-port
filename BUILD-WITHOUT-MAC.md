# Build without a Mac

Apple **requires macOS + Xcode** to produce a real `.ipa`. You cannot compile iOS on Windows alone.

## What you can do from Windows

### 1. Android APK (no Mac) — recommended

GitHub Actions → **Build Android APK (unsigned)** → download `StillAlive-Android-unsigned`.

Install on Android with “unknown sources” / sideloading.

### 2. iOS IPA (no Mac on your desk)

Use **GitHub Actions** → **Build iOS (unsigned)** on our repo. That runs on Apple’s cloud Macs.

We replaced two giant animation `.cs` files (~1MB each) with **slim stubs** in the overlay so Unity’s compiler does not crash in CI. Movement may look wrong until full anim data is split or moved out of C#.

If iOS still fails, enable **GitHub billing** and switch the workflow to `macos-14-xlarge` (more RAM).

### 3. Local Windows (Unity Hub)

1. Clone [Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge) with Git LFS.
2. Apply overlay:

   ```powershell
   .\tools\Apply-Overlay.ps1 -OverlayRoot .\overlay -TargetRoot C:\path\to\Mirror-s-Edge
   ```

3. Install **Unity 2022.3.5f1** + **Android Build Support**.
4. Build:

   ```powershell
   & "C:\Program Files\Unity\Hub\Editor\2022.3.5f1\Editor\Unity.exe" `
     -batchmode -quit -nographics `
     -projectPath "C:\path\to\Mirror-s-Edge" `
     -executeMethod StillAliveBuild.BuildAndroidApk `
     -logFile build.log
   ```

   Output: `build\Android\StillAlive.apk`

iOS export from Windows Editor is **not supported** by Unity.

## Why we “separated” animation code

`AS_C1P_Unarmed.cs` and `AS_F3P_Unarmed.cs` are ~100k lines each. Roslyn dies with `OutOfMemoryException` / “array dimensions exceeded” on GitHub runners. The overlay stubs keep the same API but drop baked animation data for CI/mobile until a proper asset pipeline exists.
