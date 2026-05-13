export default {
  server: {
    proxy: {
      '/Service1.svc': {
        target: 'http://10.40.26.222:8080',
        changeOrigin: true,
      },
    },
  },
}