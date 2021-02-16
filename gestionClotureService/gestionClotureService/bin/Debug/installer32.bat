cls

echo Installation et lancement des services…
set "currentpath=%~dp0gestionClotureService.exe"
echo %currentpath%
cd %SystemRoot%\Microsoft.NET\Framework\v4.0.30319
InstallUtil  "%currentpath%"
sc start gestionClotureService
@pause