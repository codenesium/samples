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
REM creating vue app
REM from https://cli.vuejs.org/
cd /D "%~dp0"
call npm i -g @vue/cli
call vue create application
xcopy src application /s /e /y /i
call vue ui
pause