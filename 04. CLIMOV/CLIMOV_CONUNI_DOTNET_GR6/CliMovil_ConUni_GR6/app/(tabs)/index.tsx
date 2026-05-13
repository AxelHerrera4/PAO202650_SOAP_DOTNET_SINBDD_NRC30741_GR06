import React from 'react'
import { useConversorControlador } from '../../ec.edu.monster.controlador/useConversorControlador'
import { LoginVista }     from '../../ec.edu.monster.vista/LoginVista'
import { ConversorVista } from '../../ec.edu.monster.vista/ConversorVista'

export default function App() {
  const ctrl = useConversorControlador()

  if (!ctrl.isLoggedIn) {
    return (
      <LoginVista
        username={ctrl.username}
        password={ctrl.password}
        wsUrl={ctrl.wsUrl}
        setUsername={ctrl.setUsername}
        setPassword={ctrl.setPassword}
        setWsUrl={ctrl.setWsUrl}
        onLogin={ctrl.handleLogin}
      />
    )
  }

  return (
    <ConversorVista
      category={ctrl.category}
      operations={ctrl.operations}
      operation={ctrl.operation}
      valor={ctrl.valor}
      resultado={ctrl.resultado}
      unidadOrigen={ctrl.unidadOrigen}
      unidadDestino={ctrl.unidadDestino}
      setOperation={ctrl.setOperation}
      onCategoryChange={ctrl.handleCategoryChange}
      onValorChange={ctrl.handleValorChange}
      onConvert={ctrl.handleConvert}
      onLimpiar={ctrl.handleLimpiar}
      onLogout={ctrl.handleLogout}
    />
  )
}
