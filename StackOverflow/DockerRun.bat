docker build -t aspnetapp .
docker run  -p 8000:8000  --add-host="localhost:10.0.2.2" --rm -e "ASPNETCORE_URLS=http://+:8000" -e "ConnectionStrings__ApplicationDbContext=" --name stackoverflow aspnetapp
start http://192.168.99.100:8000/swagger/index.html
REM <UNCOMMENT TO EXPOSE CONTAINER WITH NGROK> start ngrok http  192.168.99.100:8000
pause