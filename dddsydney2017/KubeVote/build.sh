git pull
dotnet restore
dotnet publish
cp Dockerfile /home/ubuntu/code/KubeVote/bin/Debug/netcoreapp1.1/publish/
docker build /home/ubuntu/code/KubeVote/bin/Debug/netcoreapp1.1/publish/ -t kubevote
docker tag kubevote:latest 514374710223.dkr.ecr.ap-southeast-2.amazonaws.com/kubevote:latest
docker push 514374710223.dkr.ecr.ap-southeast-2.amazonaws.com/kubevote:latest