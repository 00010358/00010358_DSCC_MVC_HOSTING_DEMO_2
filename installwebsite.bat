%SystemRoot%\sysnative\WindowsPowerShell\v1.0\powershell.exe -command "Set-ExecutionPolicy Unrestricted -Force"

IF NOT EXIST c:\inetpub\wwwroot\00010358 mkdir c:\inetpub\wwwroot\00010358

cd c:\temp

%SystemRoot%\sysnative\WindowsPowerShell\v1.0\powershell.exe -command ".\installwebsite.ps1"