REM You have to set ConnectionStrings__ApplicationDbContext to your connection string in docker-compose-sqlserver.yml for this to work
docker-compose -f docker-compose-sqlserver.yml up 
start http://192.168.99.100:8000/swagger/index.html
REM <UNCOMMENT TO EXPOSE CONTAINER WITH NGROK> ngrok http 192.168.99.100:8000
pause