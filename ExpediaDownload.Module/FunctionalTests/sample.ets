;#DropDB ExpediaDownloadEasyTest

#Application ExpediaDownload.Win
#Application ExpediaDownload.Web
#IfDef ExpediaDownload.Win

*Action About...
 
*Action OK

#EndIf

#IfDef ExpediaDownload.Web
!Action Navigation(My Details)
#EndIf
