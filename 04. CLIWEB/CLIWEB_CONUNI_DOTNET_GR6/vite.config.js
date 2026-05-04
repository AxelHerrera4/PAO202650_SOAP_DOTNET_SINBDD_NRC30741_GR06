export default {
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:62638',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, ''),
      },
    },
  },
}