import moment from 'moment'


export default class PipelineStepStatusViewModel {
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
    <Hash>2842e3a070274cec351610df97c119d7</Hash>
</Codenesium>*/