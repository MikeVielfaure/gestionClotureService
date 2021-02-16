cls
echo desInstallation et lancement des services…
set "currentpath=%~dp0gestionClotureService.exe"
echo %currentpath%
cd %SystemRoot%\Microsoft.NET\Framework64\v4.0.30319
InstallUtil /u "%currentpath%"
@pause