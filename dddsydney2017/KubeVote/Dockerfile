FROM microsoft/aspnetcore:1.1.2
ENTRYPOINT ["dotnet", "KubeVote.dll"]
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source .

