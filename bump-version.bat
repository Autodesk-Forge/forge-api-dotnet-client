@echo off

set current_version=1.9.7
for /f "tokens=1-3 delims=." %%i in ("%current_version%") do (
    set "pre=%%i"
    set "number=%%j"
    set /a post=%%k+1
)
set new_version=%pre%.%number%.%post%
if not "%1" == "" set new_version=%1

echo Bump v%current_version% to v%new_version%

for /f "tokens=*" %%D in ('findstr -s -p -m -c:%current_version% *.cs *.bat *.nuspec') do (
    echo %%D
    powershell -Command "(gc %%D) -replace '%current_version%', '%new_version%' | Out-File -encoding ASCII %%D"
)
