#!/usr/bin/env pwsh
Param()
$dirs = @(
  '01. UML\01. ERS'
  '01. UML\02. ECUD'
  '01. UML\03. DIAGRAMAS UML\01. CASOS_USO'
  '01. UML\03. DIAGRAMAS UML\02. ACTIVIDADES'
  '01. UML\03. DIAGRAMAS UML\03. SECUENCIA'
  '01. UML\03. DIAGRAMAS UML\04. CLASES'
  '01. UML\03. DIAGRAMAS UML\05. ARQUITECTURA'
  '02. MER\01. CONCEPTUAL'
  '02. MER\02. LOGICO'
  '02. MER\03. FISICO'
  '03. BDD\script\mysql\ddl'
  '03. BDD\script\mysql\dml'
  '04. CLICON'
  '04. CLIESC'
  '04. CLIMOV'
  '04. CLIWEB'
  '04. SERVIDOR'
  '05. DOCUMENTACION\DICCIONARIO_DATOS'
)

foreach ($d in $dirs) {
  New-Item -ItemType Directory -Force -Path $d | Out-Null
  New-Item -ItemType File -Force -Path (Join-Path $d '.gitkeep') | Out-Null
}

@'
# Conversor de Unidades - Grupo 6
NRC: 30741
'@ | Out-File -FilePath README.md -Encoding UTF8

Write-Host "Estructura (y README.md) creada/actualizada."
