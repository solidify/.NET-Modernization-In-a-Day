
#use this file to deploy the CI_CD version of the HOL, the CI_CD version does not contain any VM components
#this is just a helper script noting major.
$resourceGroup= "rg-app-modernization"
$location = "West Europe"
$subscription = "5d9a229f-3bb4-46fb-9995-4d0625c98a34"
az login

# find the subscription id that you want to use

az account set --subscription $subscription

az deployment group create -g $resourceGroup --name "deploy_new_training" --template-file azure-deploy_CI_CD.json 