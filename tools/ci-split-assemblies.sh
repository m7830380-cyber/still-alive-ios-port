#!/usr/bin/env bash
# Roslyn OOMs when compiling ~2400 Integration scripts in one assembly on 14 GB CI runners.
set -eu

GAME="${1:-game}"
INT="$GAME/Assets/Source/Integration"

rm -f "$INT/MEdge.Source.Integration.asmdef" "$INT/MEdge.Source.Integration.asmdef.meta"

write_asmdef() {
  local dir="$1"
  local name="$2"
  local refs="$3"
  mkdir -p "$dir"
  cat >"$dir/$name.asmdef" <<EOF
{
    "name": "$name",
    "rootNamespace": "MEdge",
    "references": [$refs],
    "includePlatforms": [],
    "excludePlatforms": [],
    "allowUnsafeCode": true,
    "overrideReferences": false,
    "precompiledReferences": [],
    "autoReferenced": true,
    "defineConstraints": [],
    "versionDefines": [],
    "noEngineReferences": false
}
EOF
}

write_asmdef "$INT/Stubs" "MEdge.Stubs.Rest" '"ReflectionAssembly"'
write_asmdef "$INT/Stubs/Engine" "MEdge.Stubs.Engine" '"ReflectionAssembly","MEdge.Stubs.Rest"'
write_asmdef "$INT/Stubs/TdGame" "MEdge.Stubs.TdGame" '"ReflectionAssembly","MEdge.Stubs.Rest","MEdge.Stubs.Engine"'

echo "Split stub assemblies; removed monolithic MEdge.Source.Integration.asmdef"
wc -c "$GAME/Assets/Source/Resources/AS_"*.cs 2>/dev/null || true
