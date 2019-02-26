import moment from 'moment'


export default class PipelineStatusViewModel {
    id:number;
name:string;

    constructor() {
		this.id = 0;
this.name = '';

    }

	setProperties(id : number,name : string) : void
	{
		this.id = id;
this.name = name;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>dd97a3dde005bd2355fd8a2e361300b0</Hash>
</Codenesium>*/