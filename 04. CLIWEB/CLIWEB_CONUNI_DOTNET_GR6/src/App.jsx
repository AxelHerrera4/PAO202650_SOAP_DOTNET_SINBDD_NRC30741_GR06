import './App.css'
import { useConversorControlador } from './ec.edu.monster.controlador/useConversorControlador'
import { LoginVista }    from './ec.edu.monster.vista/LoginVista'
import { ConversorVista } from './ec.edu.monster.vista/ConversorVista'

function App() {
  const ctrl = useConversorControlador()

  if (!ctrl.isLoggedIn) {
    return (
      <LoginVista
        username={ctrl.username}
        password={ctrl.password}
        loginError={ctrl.loginError}
        setUsername={ctrl.setUsername}
        setPassword={ctrl.setPassword}
        onLogin={ctrl.handleLogin}
      />
    )
  }

  return (
    <ConversorVista
      category={ctrl.category}
      operations={ctrl.operations}
      opCode={ctrl.opCode}
      valor={ctrl.valor}
      resultado={ctrl.resultado}
      unidadOrigen={ctrl.unidadOrigen}
      unidadDestino={ctrl.unidadDestino}
      setOpCode={ctrl.setOpCode}
      onCategoryChange={ctrl.handleCategoryChange}
      onValorChange={ctrl.handleValorChange}
      onConvert={ctrl.handleConvert}
      onLimpiar={ctrl.handleLimpiar}
      onLogout={ctrl.handleLogout}
    />
  )
}

export default App
