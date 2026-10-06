# Still Alive — mobile overlay (Android-first, no Mac)

Layers touch input, timing, and CI on [Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge). **You do not need a Mac or paid runners for Android.**

## Get an APK (free GitHub Actions)

1. [Actions](https://github.com/m7830380-cyber/still-alive-ios-port/actions) → **Build Android APK (unsigned)** → Run workflow  
2. Download **StillAlive-Android-unsigned** → `Android.apk`

See **[BUILD-WITHOUT-MAC.md](BUILD-WITHOUT-MAC.md)** for Windows-only builds and why iOS is not on free CI.

## Local dev (Windows)

```powershell
git clone https://github.com/Eideren/Mirror-s-Edge.git
cd Mirror-s-Edge
git lfs pull
..\still-alive-ios-port\tools\Apply-Overlay.ps1 -OverlayRoot ..\still-alive-ios-port\overlay
```

Unity **2022.3.5f1** → `Assets/Scenes/Cranes_Off.unity`.

Retail Steam path (optional):

```powershell
.\tools\Set-RetailGamePath.ps1 -Path 'C:\Program Files (x86)\Steam\steamapps\common\miris'
```

## iOS

Not built on free GitHub Mac runners for this project (compiler OOM). **iOS IPA (info only)** workflow explains options. No paid `macos-14-xlarge` required unless you insist on cloud iOS builds.

## Credit

[Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge)
