import Vue from 'vue'
import Router from 'vue-router'
import Vuex from 'vuex'
import Login from '@/components/Login'

Vue.use(Router)
Vue.use(vuex)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Login',
      component: Login
    }
  ]
})
