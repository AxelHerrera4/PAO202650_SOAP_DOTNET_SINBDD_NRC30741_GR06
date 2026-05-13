function buildSoapEnvelope(method: string, paramName: string, valor: string): string {
  return `<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
<soap:Body>
<${method} xmlns="http://tempuri.org/">
<${paramName}>${valor}</${paramName}>
</${method}>
</soap:Body>
</soap:Envelope>`
}

export async function invokeSoap(
  wsUrl: string,
  method: string,
  paramName: string,
  valor: string,
): Promise<string> {
  const response = await fetch(wsUrl, {
    method: 'POST',
    headers: {
      'Content-Type': 'text/xml; charset=utf-8',
      'SOAPAction': `http://tempuri.org/IService1/${method}`,
    },
    body: buildSoapEnvelope(method, paramName, valor),
  })

  if (!response.ok) throw new Error(`HTTP Error: ${response.status}`)

  const data = await response.text()
  const resultTagName = `${method}Result`
  const pattern = new RegExp(`<${resultTagName}[^>]*>([\\s\\S]*?)</${resultTagName}>`, 'i')
  const match = data.match(pattern)

  if (match && match[1]) {
    const raw = match[1].trim()
    const num = parseFloat(raw)
    if (!isNaN(num)) return num.toFixed(2)
    throw new Error('Valor no numérico en respuesta')
  }

  throw new Error(`Etiqueta ${resultTagName} no encontrada en la respuesta`)
}
