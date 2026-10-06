# Still Alive port (mobile / iOS)

Fork of [Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge) with mobile input, 62 Hz timing, and unsigned iOS CI.

**You must own Mirror's Edge on Steam.** Do not commit EA game files to git.

## Quick start (PC)

1. Clone with **Git LFS** (see upstream README if LFS quota fails).
2. Open in **Unity 2022.3.5f1** (same as `ProjectSettings/ProjectVersion.txt`).
3. Open scene `Assets/Scenes/Cranes_Off.unity` and Play (keyboard + mouse).

## Retail game path (local only)

Set environment variable before opening Unity (optional, for future import tools):

```powershell
[System.Environment]::SetEnvironmentVariable('ME_RETAIL_PATH', 'C:\Program Files (x86)\Steam\steamapps\common\miris', 'User')
```

Or run:

```powershell
.\tools\Set-RetailGamePath.ps1 -Path 'C:\Program Files (x86)\Steam\steamapps\common\miris'
```

## Mobile controls (iOS / Android)

- Left side: virtual move / strafe  
- Right side: look (drag)  
- Top bar taps: interact, crouch, jump (regions — tune in `Input_Mobile.cs`)

Gameplay tick target: **62 FPS** (`StillAliveRuntimeBootstrap` + fixed timestep).

## iOS unsigned build (GitHub Actions)

1. Fork this repo on GitHub.
2. Add repository secrets (see [Game CI activation](https://game.ci/docs/github/activation)):
   - `UNITY_LICENSE` (or `UNITY_EMAIL` + `UNITY_PASSWORD` + `UNITY_SERIAL`)
3. Run workflow **Build iOS (unsigned)** on `main`.

Artifact: `StillAlive-iOS-unsigned` (`.ipa` or Xcode export depending on Unity version).

Local iOS builds require macOS + Xcode; Windows cannot produce IPAs.

## Authenticity roadmap

| Priority | Work |
|----------|------|
| Now | Cranes_Off parity vs retail (62 FPS, controller bugs from upstream README) |
| Next | Decompress retail `.u` → validate script vs `Assets/Source` ([MEPortingTools](https://github.com/Eideren/MEPortingTools)) |
| Then | Import more maps (T3D / Cartographer pipeline) |
| Later | Materials from `.upk` via UELib |

## Legal

Game logic port by Eideren; mobile/CI changes in this fork. Mirror's Edge is © EA / DICE. This is a fan project, not affiliated with EA.
