param(
    [Parameter(Mandatory)]
    [string]$Path
)

$resolved = (Resolve-Path -LiteralPath $Path).Path
[System.Environment]::SetEnvironmentVariable('ME_RETAIL_PATH', $resolved, 'User')
Write-Host "ME_RETAIL_PATH set to: $resolved (User scope). Restart Unity/terminal."
