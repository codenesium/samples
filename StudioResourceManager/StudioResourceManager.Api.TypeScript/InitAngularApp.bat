@echo OFF
REM Check if node is installed
node -v 2> Nul
if "%errorlevel%" == "9009" (
    echo node is not installed. You must install it from https://nodejs.org/en/download/
	pause
    exit /B
) ELSE (
echo This script will install a starter project using NPM. It can take up to an hour to pull everything down. Please be patient.
)


REM creating angular app
REM from https://cli.angular.io/
cd /D "%~dp0"
call npm install -g @angular/cli
call ng new application
xcopy src application\src\api /s /e /y /i
cd application
call ng serve --open=true
pause