import moment from 'moment'


export default class SpaceFeatureViewModel {
    id:number;
name:string;

    constructor() {
		this.id = 0;
this.name = '';

    }

	setProperties(id : number,name : string) : void
	{
		this.id = moment(id,'YYYY-MM-DD');
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>a1bee6e75636aeae29488ddb954ec1aa</Hash>
</Codenesium>*/