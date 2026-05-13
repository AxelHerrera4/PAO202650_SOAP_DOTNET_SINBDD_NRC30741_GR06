import { WS_URL } from './operaciones'

function buildSoapEnvelope(method, paramName, valor) {
  return `<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <${method} xmlns="http://tempuri.org/">
      <${paramName}>${valor}</${paramName}>
    </${method}>
  </soap:Body>
</soap:Envelope>`
}

export async function invokeSoap(method, paramName, valor) {
  const xml = buildSoapEnvelope(method, paramName, valor)
  const res = await fetch(WS_URL, {
    method: 'POST',
    headers: {
      'Content-Type': 'text/xml',
      'SOAPAction': `http://tempuri.org/IService1/${method}`,
    },
    body: xml,
  })

  if (!res.ok) throw new Error(`HTTP Error: ${res.status}`)

  const text = await res.text()
  const m = text.match(/>([^<]+)<\/\w+Result>/)
  if (m) return m[1]

  const m2 = text.match(/>([-+]?[0-9]*\.?[0-9]+)<\//)
  if (m2) return m2[1]

  throw new Error('Error al parsear respuesta del WS')
}
