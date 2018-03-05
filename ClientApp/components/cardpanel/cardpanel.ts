import Vue from "vue";
import { Component, Emit, Prop } from "vue-property-decorator";

import { IPersonViewModel } from "../../viewmodels/person";

@Component
export default class CardPanelComponent extends Vue {
    @Prop() person : IPersonViewModel = {};
    name: string = "sfeir-card";
    readonly defaultPhoto: string = "https://randomuser.me/api/portraits/lego/6.jpg";

    get photoUrl (): string  {
		if(this.person == null) {
			return this.defaultPhoto;
		} else {
			return this.person.photo || this.defaultPhoto;
		}
	}

    @Emit("delete") onDelete(): void  {
        // tslint:disable-next-line:no-unused-expression
        this.person;
    }

}