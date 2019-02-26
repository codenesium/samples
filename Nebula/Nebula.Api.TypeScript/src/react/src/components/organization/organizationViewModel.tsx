import moment from 'moment'


export default class OrganizationViewModel {
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
    <Hash>c0de518c08048bbd93f51df70d682bb3</Hash>
</Codenesium>*/