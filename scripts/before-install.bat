set FOLDER=%HOMEDRIVE%\temp\00010358

if exist %FOLDER% (
  rd /s /q "%FOLDER%"
)

mkdir %FOLDER%