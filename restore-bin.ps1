$packagesFile = [System.IO.Path]::GetDirectoryName($$) + "\packages.config"
$packages = New-Object -TypeName System.IO.StreamReader -ArgumentList $packagesFile
$reader = [System.Xml.XmlReader]::Create($packages)

$packagesPath = "C:\dev\solutions\packages\"
$binPath = "C:\dev\org.net\Bin\"
while ($reader.ReadToFollowing("package")) {
	$path = $packagesPath
	$reader.MoveToAttribute("id")
	$path += $reader.Value
	$reader.MoveToAttribute("version")
	$path += "." + $reader.Value + "\"
	$reader.MoveToAttribute("targetFramework")
	$framework = $reader.Value
	
	$path += "lib\"
	
	$pathV1 = $path + $framework + "\"
	$pathV2 = $path + $framework.Substring(3) + "\"
	
	if ([System.IO.Directory]::Exists($pathV1)) {
		$src = "$($pathV1)*.dll"	
		copy $src $binPath
		$src = "$($pathV1)*.xml"	
		copy $src $binPath
	} 
	elseif ([System.IO.Directory]::Exists($pathV2)) {
		echo "$($pathV2)*.dll"
	}
}