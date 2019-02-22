start http://192.168.99.100
REM <UNCOMMENT TO EXPOSE CONTAINER WITH NGROK> ngrok http 192.168.99.100:80
docker-compose -f docker-compose-postgres.yml up 
pause