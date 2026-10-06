# Build without a Mac (and without paid CI)

## Money and runners — what you actually need

| Goal | Mac at home? | Paid GitHub runner? |
|------|----------------|---------------------|
| **Android APK** | No | **No** — uses free **Linux** runners |
| **Windows play / dev** | No | No |
| **iPhone .ipa** | Yes, *somewhere* (see below) | Only if you pay for bigger Mac runners; **not required** for Android |

GitHub’s **macos-14** runner is free within your account limits, but this project **runs out of compiler memory** there. That is **not** the same as “you must buy macos-14-xlarge.” For this repo, **skip iOS in CI** unless you have access to a Mac or paid larger runners.

## Recommended: Android APK (free)

1. Repo: [still-alive-ios-port](https://github.com/m7830380-cyber/still-alive-ios-port)
2. **Actions** → **Build Android APK (unsigned)** → **Run workflow**
3. When it finishes (~10–15 min), download **StillAlive-Android-unsigned**
4. Install on an Android phone (allow installs from unknown sources / sideload)

Uses **Ubuntu + Unity Docker** — no Apple hardware, no paid runner tier.

## Windows only (no GitHub)

1. Clone [Eideren/Mirror-s-Edge](https://github.com/Eideren/Mirror-s-Edge) with Git LFS.
2. Apply overlay:

   ```powershell
   .\tools\Apply-Overlay.ps1 -OverlayRoot .\overlay -TargetRoot C:\path\to\Mirror-s-Edge
   ```

3. Unity Hub: **2022.3.5f1** + **Android Build Support** (Personal license is fine).
4. Build:

   ```powershell
   .\tools\Build-Android-Local.ps1 -ProjectPath C:\path\to\Mirror-s-Edge
   ```

   APK: `build\Android\Android.apk`

You can also open `Assets/Scenes/Cranes_Off.unity` and press Play on PC.

## iPhone / iOS — honest limits

- Unity **cannot** export iOS from Windows.
- A real **.ipa** needs **macOS + Xcode** at least once (export + sign or sideload tooling).
- **Free GitHub Mac CI** for this codebase currently **fails** (too much C# for the compiler on a standard runner). We stubbed giant animation files; the rest of Still Alive is still huge.
- **You do not need a paid runner** if you are okay **not** shipping iOS from this repo.

Ways to get on iPhone **without paying GitHub**:

- Use **any** Mac you can borrow (even once): build in Unity → Xcode → device.
- Use **Android** instead (same overlay, free CI).
- Wait for a slimmer mobile port (smaller assemblies / asset pipeline) — not done yet.

The workflow **iOS IPA (info only)** in Actions only prints this; it does not spend Mac minutes.

Archived full iOS pipeline: `.github/workflows/ios-unsigned.yml.archive` (rename to `.yml` if you have Mac CI that can compile the project).

## Animation stubs (why mobile builds differ from desktop Still Alive)

`AS_C1P_Unarmed.cs` / `AS_F3P_Unarmed.cs` are ~100k lines each and crash Roslyn in CI. The overlay replaces them with tiny stubs so **Android** can compile. Movement/animations on mobile may be wrong until anim data is moved out of giant C# files.
