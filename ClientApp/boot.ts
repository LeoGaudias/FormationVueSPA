import "./css/site.css";
import Vue from "vue";

import routes from "./routes/routes";

// tslint:disable-next-line:no-unused-expression
new Vue({
    el: "#app-root",
    router: routes,
    render: h => h(require("./components/app/app.vue.html"))
});
