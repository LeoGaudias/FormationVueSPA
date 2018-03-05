import Vue from "vue";

import VueMaterial from "vue-material";
import "vue-material/dist/vue-material.css";

Vue.use(VueMaterial);

import "./css/site.css";
import routes from "./routes/routes";

// tslint:disable-next-line:comment-format
// Vue.material.registerTheme("default", {
//     primary: "blue",
//     accent: "grey",
//     warn: "red"
// });

// tslint:disable-next-line:no-unused-expression
new Vue({
    el: "#app-root",
    router: routes,
    render: h => h(require("./components/app/app.vue.html"))
});
