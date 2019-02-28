import moment from 'moment'


export default class BucketViewModel {
    externalId:any;
id:number;
name:string;

    constructor() {
		this.externalId = undefined;
this.id = 0;
this.name = '';

    }

	setProperties(externalId : any,id : number,name : string) : void
	{
		this.externalId = externalId;
this.id = id;
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>03004650007ef256cc332b9598f3b943</Hash>
</Codenesium>*/