import React from 'react'
import { StyleSheet, Text, View, TextInput, TouchableOpacity, ScrollView } from 'react-native'

interface Props {
  username:    string
  password:    string
  wsUrl:       string
  setUsername: (v: string) => void
  setPassword: (v: string) => void
  setWsUrl:    (v: string) => void
  onLogin:     () => void
}

export function LoginVista({ username, password, wsUrl, setUsername, setPassword, setWsUrl, onLogin }: Props) {
  return (
    <ScrollView contentContainerStyle={styles.container}>
      <View style={styles.heroSection}>
        <Text style={styles.title}>ConUni</Text>
        <Text style={styles.subtitle}>Conversor Universal (.NET)</Text>
      </View>

      <View style={styles.loginCard}>
        <Text style={styles.loginTitle}>Iniciar Sesión</Text>

        <Text style={styles.label}>URL del Servidor:</Text>
        <TextInput
          style={styles.input}
          placeholder="http://192.168.1.12:8080/Service1.svc"
          value={wsUrl}
          onChangeText={setWsUrl}
        />
        <TextInput
          style={styles.input}
          placeholder="Usuario"
          value={username}
          onChangeText={setUsername}
        />
        <TextInput
          style={styles.input}
          placeholder="Contraseña"
          secureTextEntry
          value={password}
          onChangeText={setPassword}
        />
        <TouchableOpacity style={styles.loginButton} onPress={onLogin}>
          <Text style={styles.buttonText}>ACCEDER</Text>
        </TouchableOpacity>
      </View>
    </ScrollView>
  )
}

const styles = StyleSheet.create({
  container:   { flexGrow: 1, backgroundColor: '#0f172a', alignItems: 'center', paddingVertical: 50, paddingHorizontal: 20 },
  heroSection: { alignItems: 'center', marginBottom: 30 },
  title:       { fontSize: 42, color: '#60a5fa', fontWeight: 'bold' },
  subtitle:    { fontSize: 18, color: '#bfdbfe', marginBottom: 20 },
  loginCard:   { width: '100%', backgroundColor: '#f8fafc', padding: 25, borderRadius: 15 },
  loginTitle:  { fontSize: 22, fontWeight: 'bold', marginBottom: 20, textAlign: 'center' },
  label:       { fontWeight: 'bold', color: '#475569', marginBottom: 5 },
  input:       { backgroundColor: '#e2e8f0', padding: 15, borderRadius: 10, fontSize: 16, marginBottom: 15, color: '#1e293b' },
  loginButton: { backgroundColor: '#2563eb', padding: 15, borderRadius: 10, alignItems: 'center' },
  buttonText:  { color: '#fff', fontWeight: 'bold', fontSize: 16 },
})
