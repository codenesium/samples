import moment from 'moment'


export default class SpaceViewModel {
    description:string;
id:number;
name:string;

    constructor() {
		this.description = '';
this.id = 0;
this.name = '';

    }

	setProperties(description : string,id : number,name : string) : void
	{
		this.description = description;
this.id = id;
this.name = name;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>86a1a99b48cb0c761353c45d1071918d</Hash>
</Codenesium>*/