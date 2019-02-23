import moment from 'moment'


export default class IncludedColumnTestViewModel {
    id:number;
name:string;
name2:string;

    constructor() {
		this.id = 0;
this.name = '';
this.name2 = '';

    }

	setProperties(id : number,name : string,name2 : string) : void
	{
		this.id = id;
this.name = name;
this.name2 = name2;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>8b240c440c619d170771b9fc4427ce61</Hash>
</Codenesium>*/