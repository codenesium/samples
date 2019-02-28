import moment from 'moment'


export default class VPersonViewModel {
    personId:number;
personName:string;

    constructor() {
		this.personId = 0;
this.personName = '';

    }

	setProperties(personId : number,personName : string) : void
	{
		this.personId = personId;
this.personName = personName;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>8d851701304744690380fb8113ab19aa</Hash>
</Codenesium>*/