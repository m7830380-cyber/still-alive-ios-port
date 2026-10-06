param(
    [Parameter(Mandatory)]
    [string]$OverlayRoot,
    [string]$TargetRoot = (Get-Location).Path
)

$overlay = (Resolve-Path -LiteralPath $OverlayRoot).Path
$target = (Resolve-Path -LiteralPath $TargetRoot).Path

Get-ChildItem -LiteralPath $overlay -Recurse -File | ForEach-Object {
    $rel = $_.FullName.Substring($overlay.Length).TrimStart('\', '/')
    $dest = Join-Path $target $rel
    $dir = Split-Path -Parent $dest
    if (-not (Test-Path -LiteralPath $dir)) {
        New-Item -ItemType Directory -Force -Path $dir | Out-Null
    }
    Copy-Item -LiteralPath $_.FullName -Destination $dest -Force
    Write-Host "Applied $rel"
}

Write-Host "Overlay applied to $target"
