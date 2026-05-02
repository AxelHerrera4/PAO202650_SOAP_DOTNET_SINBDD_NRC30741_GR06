#!/usr/bin/env bash
set -euo pipefail

# Script para crear la estructura del proyecto (ejecutar desde la raíz del repo)
dirs=(
  "01. UML/01. ERS"
  "01. UML/02. ECUD"
  "01. UML/03. DIAGRAMAS UML/01. CASOS_USO"
  "01. UML/03. DIAGRAMAS UML/02. ACTIVIDADES"
  "01. UML/03. DIAGRAMAS UML/03. SECUENCIA"
  "01. UML/03. DIAGRAMAS UML/04. CLASES"
  "01. UML/03. DIAGRAMAS UML/05. ARQUITECTURA"
  "02. MER/01. CONCEPTUAL"
  "02. MER/02. LOGICO"
  "02. MER/03. FISICO"
  "03. BDD/script/mysql/ddl"
  "03. BDD/script/mysql/dml"
  "04. CLICON"
  "04. CLIESC"
  "04. CLIMOV"
  "04. CLIWEB"
  "04. SERVIDOR"
  "05. DOCUMENTACION/DICCIONARIO_DATOS"
)

for d in "${dirs[@]}"; do
  mkdir -p "$d"
  : > "$d/.gitkeep"
done

cat > README.md <<'EOF'
# Conversor de Unidades - Grupo 6
NRC: 30741
EOF

echo "Estructura (y README.md) creada/actualizada."
