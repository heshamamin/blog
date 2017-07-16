export NAME=cluster.heshamamin.com
export KOPS_STATE_STORE=s3://kopsconfig.heshamamin.com

kops create cluster --zones ap-southeast-2a ${NAME}
kops update cluster ${NAME} --yes

kops validate cluster

kubectl get nodes

#system components:
kubectl -n kube-system get pod
kubectl create -f https://rawgit.com/kubernetes/dashboard/master/src/deploy/kubernetes-dashboard.yaml

cd /mnt/d/Code/KubeVote/k8


while true;do curl LOCALHOST/Votes -d "";done;

https://api.qrserver.com/v1/create-qr-code/?size=500x500&data=LOCALHOST
