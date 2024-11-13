## MUST CHANGE VERSION OF PACKAGE HERE
param (
    [string]$version = "1.0.0",
    [string]$url = "http://192.168.1.127:5000/v3/index.json"
)

$packageVersion = $version
$packageSuffix = ".nupkg"

# base command
$baseCommand = "dotnet nuget push -s $url "

# build command
$buildCommand = "dotnet build"

# get current path
$currentPath = (Get-Location).Path

$sourcePath = $currentPath + "\src\"

$debugPath = "\bin\Debug\"

$childPath = Get-ChildItem -Directory -Recurse -Path $sourcePath -Depth 0

# execute build command
Write-Host "Executing build command: " $buildCommand
Invoke-Expression $buildCommand

foreach ($folder in $childPath) {
    $childFolder = $sourcePath + $folder.Name + $debugPath
    $childPackage = $folder.Name + "." + $packageVersion + $packageSuffix
    # goto child folder
    Write-Host "Changing directory to: " $childFolder
    Set-Location -Path $childFolder
    
    # execute command
    Write-Host "Executing push command for folder: " $folder.Name
    $tempCommand = $baseCommand + $childPackage
    Write-Host "Command: " $tempCommand
    Invoke-Expression $tempCommand

    # go back to base folder
    Write-Host "Changing directory to: " $currentPath
    Set-Location -Path $currentPath
}