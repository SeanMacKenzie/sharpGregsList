// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import axios from 'axios'

var server = axios.create({
  baseURL: window.location.host.includes("localhost") ? '//localhost:5000' : '/',
  timeout: 2000,
  withCredentials: true
})

server.get('account/authenticate').then(x => console.log(x))

server.get('api/autos').then(res => {
  console.log(res)
}).catch(err => console.log(err))


Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
