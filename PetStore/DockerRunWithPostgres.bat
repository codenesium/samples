start http://192.168.99.100:8000/swagger/index.html
REM <UNCOMMENT TO EXPOSE CONTAINER WITH NGROK> ngrok http 192.168.99.100:8000
docker-compose -f docker-compose-postgres.yml up 
pause