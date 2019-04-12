start http://192.168.99.100
SET REACT_APP_API_URL=http://192.168.99.100
docker-compose -f docker-compose-sqlserver.yml up 
REM <UNCOMMENT TO EXPOSE CONTAINER WITH NGROK> ngrok http 192.168.99.100:80
pause