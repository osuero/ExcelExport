param($installPath, $toolsPath, $package, $project)
try{
	$globalasax = $project.ProjectItems.Item("Global.asax")
	$globalasaxCs = $globalasax.ProjectItems.Item("Global.asax.cs")
	$globalasaxCs.Open()
	$globalasaxCs.Document.Activate()
	$Selection = $globalasaxCs.Document.Selection
	$Selection.StartOfDocument()
	if($Selection.FindText("namespace")){
		$Selection.StartOfLine()
		$Selection.LineUp()
		$Selection.Insert("using MvcPdfWriter.Core;`r`n")
	}
	if($Selection.FindText("Application_Start")){
		      $Selection.FindText("}")
		      $Selection.StartOfLine()
			  $Selection.LineUp()
			  $Selection.Insert("`r`n`t`t`tViewEngines.Engines.Add(new PdfViewEngine());`r`n")
	}
}
catch{
 Write-Host "Unable to add PdfViewEngine entry"
}