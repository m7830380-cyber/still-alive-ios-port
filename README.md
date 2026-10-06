# Still Alive — iOS / mobile overlay

This repo does **not** contain the full Still Alive project (Git LFS). It layers mobile/iOS changes on [Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge).

## Setup

```powershell
git clone https://github.com/Eideren/Mirror-s-Edge.git
cd Mirror-s-Edge
git lfs pull
..\still-alive-ios-port\tools\Apply-Overlay.ps1 -OverlayRoot ..\still-alive-ios-port\overlay
```

Open in **Unity 2022.3.5f1** → `Assets/Scenes/Cranes_Off.unity`.

## Retail Steam files (local)

```powershell
.\tools\Set-RetailGamePath.ps1 -Path 'C:\Program Files (x86)\Steam\steamapps\common\miris'
```

See `overlay/PORT.md` for iOS CI secrets and controls.

## GitHub Actions

Workflow in `overlay/.github/workflows/ios-unsigned.yml` expects a **combined** tree (use the apply script in CI or push a fork with overlay merged).

## Upstream

Credit and issues: [Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge). This overlay: mobile touch, 62 Hz tick, unsigned IPA build pipeline.
