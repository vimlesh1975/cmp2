$lines = Get-Content "CasparMediaPlaybackSetup\CasparMediaPlaybackSetup.vdproj"
$newLines = @()
$inBlock = $false
$blockLines = @()
$isAmd64 = $false

foreach ($line in $lines) {
    if ($line -match '\{9F6F8455-1EF1-4B85-886A-4223BCC8E7F7\}:_') {
        if ($inBlock) { $newLines += $blockLines }
        $inBlock = $true
        $blockLines = @($line)
        $isAmd64 = $false
    } elseif ($inBlock) {
        $blockLines += $line
        if ($line -match 'processorArchitecture=AMD64') {
            $isAmd64 = $true
        }
        if ($line -match '^\s*\}$') {
            # End of block
            if ($isAmd64) {
                # Transform block
                $transformed = @()
                foreach ($bLine in $blockLines) {
                    if ($bLine -match '\{9F6F8455-1EF1-4B85-886A-4223BCC8E7F7\}:_') {
                        $transformed += $bLine -replace '\{9F6F8455-1EF1-4B85-886A-4223BCC8E7F7\}', '{1E2AD844-6B49-4325-98BD-3BC607D6D632}'
                    } elseif ($bLine -match '"AssemblyRegister"|"AssemblyIsInGAC"|"AssemblyAsmDisplayName"|"ScatterAssemblies"|^\s*\"_[A-Z0-9]+\"\s*$|^\s*\{\s*$|^\s*"Name"\s*=|^\s*"Attributes"\s*=|^\s*\}\s*$') {
                        # Skip these lines if they are part of the assembly metadata
                        # Wait, we need to be careful not to skip the closing brace of the main block
                        if ($bLine -match '^\s*\}\s*$') {
                            # Is it the closing brace of ScatterAssemblies or the main block?
                            # Since we just do line by line, it's risky to skip braces.
                        }
                    }
                }
            } else {
                $newLines += $blockLines
            }
            $inBlock = $false
            $blockLines = @()
        }
    } else {
        $newLines += $line
    }
}
