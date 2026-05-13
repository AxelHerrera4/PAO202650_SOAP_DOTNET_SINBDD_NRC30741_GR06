import { useState } from 'react'
import { CATEGORIAS } from '../ec.edu.monster.modelo/operaciones'
import { invokeSoap } from '../ec.edu.monster.modelo/soapCliente'

export function useConversorControlador() {
  const [isLoggedIn, setIsLoggedIn]   = useState(false)
  const [username,   setUsername]     = useState('')
  const [password,   setPassword]     = useState('')
  const [loginError, setLoginError]   = useState('')
  const [category,   setCategory]     = useState('longitud')
  const [opCode,     setOpCode]       = useState(CATEGORIAS.longitud[0].code)
  const [valor,      setValor]        = useState('')
  const [resultado,  setResultado]    = useState(null)
  const [unidadOrigen, setUnidadOrigen] = useState('')
  const [unidadDestino, setUnidadDestino] = useState('')

  const operations = CATEGORIAS[category] ?? CATEGORIAS.longitud

  const handleLogin = (e) => {
    e.preventDefault()
    if (username === 'monster' && password === 'monster9') {
      setIsLoggedIn(true)
      setLoginError('')
    } else {
      setLoginError('Credenciales inválidas')
    }
  }

  const handleLogout = () => setIsLoggedIn(false)

  const handleCategoryChange = (cat) => {
    setCategory(cat)
    setOpCode(CATEGORIAS[cat][0].code)
    setResultado(null)
    setUnidadOrigen('')
    setUnidadDestino('')
  }

  const handleValorChange = (raw) => {
    const v = raw.replace(',', '.')
    if (v === '' || /^-?\d*\.?\d*$/.test(v)) setValor(v)
  }

  const handleConvert = async () => {
    if (!valor) return
    const op = operations.find(o => o.code === opCode)
    if (!op) { setResultado('Error: operación inválida'); return }
    try {
      const r = await invokeSoap(op.method, op.param, valor)
      setResultado(r)
      setUnidadOrigen(`Origen: ${valor}`)
      setUnidadDestino(`Resultado: ${r}`)
    } catch {
      setResultado('Error de conexión')
    }
  }

  const handleLimpiar = () => {
    setValor('')
    setResultado(null)
    setUnidadOrigen('')
    setUnidadDestino('')
  }

  return {
    isLoggedIn,
    username, setUsername,
    password, setPassword,
    loginError,
    category, operations,
    opCode, setOpCode,
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
