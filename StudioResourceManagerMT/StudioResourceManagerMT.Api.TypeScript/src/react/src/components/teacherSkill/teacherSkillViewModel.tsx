import moment from 'moment'


export default class TeacherSkillViewModel {
    id:number;
name:string;

    constructor() {
		this.id = 0;
this.name = '';

    }

	setProperties(id : number,name : string) : void
	{
		this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>51c8b8a077916a80283f51dac602348c</Hash>
</Codenesium>*/