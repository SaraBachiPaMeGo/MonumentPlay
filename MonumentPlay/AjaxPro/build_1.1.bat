del release\AjaxPro.dll

"%NET11%\csc.exe" %ARG% /out:"release\AjaxPro.dll" /target:library /define:"TRACE;%DEFINE%" /r:"System.dll" /r:"System.Data.dll" /r:"System.Drawing.dll" /r:"System.Web.dll" /r:"System.Web.Services.dll" /r:"System.Xml.dll" "AssemblyInfo.cs" "Attributes\*.cs" "Configuration\*.cs" "Handler\*.cs" "Handler\AjaxProcessors\*.cs" "Handler\Security\*.cs" "Interfaces\*.cs" "JSON\Converters\*.cs" "JSON\Interfaces\*.cs" "JSON\*.cs" "JSON\JavaScriptObjects\*.cs" "Managment\*.cs" "Security\*.cs" "Services\*.cs" "Utilities\*.cs" /res:prototype.js,AjaxPro.prototype.js /res:core.js,AjaxPro.core.js /res:ms.js,AjaxPro.ms.js
