import Vue from "vue";
import Router from "vue-router";
import { RouteConfig } from "vue-router";

Vue.use(Router);

const routes: RouteConfig[] = [
    { path: "/", redirect: "/home" },
    { name: "home", path: "/home", component: require("../components/home/home.vue.html") },
    // { name: "people", path: "/people", component: require("./components/home/people.vue.html") },
    // { name: "edit", path: "/edit/:id", component: require("./components/home/edit.vue.html") }
];


export default new Router({
    mode: "history",
    routes: routes
});