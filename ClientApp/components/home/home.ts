import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";

import { IPersonViewModel } from "../../viewmodels/person";
import PeopleService from "../../services/people";

@Component({
    components:{
        "sfeir-card": require("../cardpanel/cardpanel.vue.html")
    }
})
export default class HomeComponent extends Vue {
    person : IPersonViewModel = {};

    beforeCreate(): void {
        // console.log("beforeCreate");
        PeopleService.getInstance().getRandom()
        .then(res => this.person = res)
        .catch(console.log);
    }

    created(): void {
        // console.log("created");
    }

    beforeMount(): void {
        // console.log("beforeMount");
    }

    mounted(): void {
        // console.log("mounted");
    }

    beforeUpdate(): void {
        // console.log("beforeUpdate");
    }

    updated(): void {
        // console.log("updated");
    }

    beforeDestroy(): void {
        // console.log("beforeDestroy");
    }

    destroyed(): void {
        // console.log("destroyed");
    }

    // tslint:disable-next-line:no-empty
    random(): void {
        PeopleService.getInstance().getRandom()
        .then(res => this.person = res)
        .catch(console.log);
    }
}
