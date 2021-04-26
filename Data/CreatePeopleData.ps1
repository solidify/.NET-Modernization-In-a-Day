while($true)
{
    Invoke-WebRequest https://contoso-apim-mpqiztwvluois.azure-api.net/api/People -Headers @{'Accept' = 'application/json'; 'Ocp-Apim-Subscription-Key' = '726479de468343089a7417a61192d3fe'}
    $sleepinterval = get-random -Minimum 10 -Maximum 1000;
    Write-Host "Sleepinterval is " + $sleepinterval
    for ($i = 1; $i -le $sleepinterval; $i++ )
    {
        Write-Progress -Activity "Waiting for next run time" -Status "$i% Complete:" -SecondsRemaining $i;
        Start-Sleep -Seconds 1
    }    
    
}
