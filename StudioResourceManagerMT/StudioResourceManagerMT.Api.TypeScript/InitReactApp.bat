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
REM creating react app
REM from https://github.com/facebook/create-react-app
cd /D "%~dp0"
xcopy src\react application /s /e /y /i
cd application
call npm install
call npm start
pause