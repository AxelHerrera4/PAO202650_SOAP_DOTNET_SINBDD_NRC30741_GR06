import { useState, useMemo, useEffect } from 'react'
import { Alert } from 'react-native'
import { CATEGORIAS, DEFAULT_WS_URL, type Categoria } from '../ec.edu.monster.modelo/operaciones'
import { invokeSoap } from '../ec.edu.monster.modelo/soapCliente'

export function useConversorControlador() {
  const [isLoggedIn,    setIsLoggedIn]    = useState(false)
  const [username,      setUsername]      = useState('')
  const [password,      setPassword]      = useState('')
  const [wsUrl,         setWsUrl]         = useState(DEFAULT_WS_URL)
  const [category,      setCategory]      = useState<Categoria>('Temperatura')
  const [operation,     setOperation]     = useState('')
  const [valor,         setValor]         = useState('')
  const [resultado,     setResultado]     = useState('...')
  const [unidadOrigen,  setUnidadOrigen]  = useState('')
  const [unidadDestino, setUnidadDestino] = useState('')

  const operations = useMemo(() => CATEGORIAS[category], [category])

  useEffect(() => {
    if (operations.length > 0) setOperation(operations[0].code)
  }, [operations])

  const handleLogin = () => {
    if (username === 'monster' && password === 'monster9') {
      setIsLoggedIn(true)
      setUsername('')
      setPassword('')
    } else {
      Alert.alert('Error', 'Credenciales incorrectas')
    }
  }

  const handleLogout = () => {
    setIsLoggedIn(false)
    setValor('')
    setResultado('...')
  }

  const handleCategoryChange = (cat: Categoria) => {
    setCategory(cat)
    setResultado('...')
    setUnidadOrigen('')
    setUnidadDestino('')
  }

  const handleValorChange = (raw: string) => {
    const normalized = raw.replace(',', '.')
    if (normalized === '' || /^-?\d*\.?\d*$/.test(normalized)) setValor(normalized)
  }

  const handleConvert = async () => {
    if (!valor) { Alert.alert('Aviso', 'Ingresa un valor'); return }
    const op = operations.find(o => o.code === operation)
    if (!op)   { Alert.alert('Error', 'Conversión no disponible'); return }
    try {
      const result = await invokeSoap(wsUrl, op.method, op.param, valor)
      setResultado(result)
      setUnidadOrigen(`Origen: ${valor}`)
      setUnidadDestino(`Destino: ${result}`)
    } catch (e: any) {
      Alert.alert('Error de Conexión', e?.message ?? 'No se pudo conectar al servidor')
    }
  }

  const handleLimpiar = () => {
    setValor('')
    setResultado('...')
    setUnidadOrigen('')
    setUnidadDestino('')
  }

  return {
    isLoggedIn,
    username, setUsername,
    password, setPassword,
    wsUrl, setWsUrl,
    category, operations,
    operation, setOperation,
    valor,
    resultado,
    unidadOrigen,
    unidadDestino,
    handleLogin,
    handleLogout,
    handleCategoryChange,
    handleValorChange,
    handleConvert,
    handleLimpiar,
  }
}
