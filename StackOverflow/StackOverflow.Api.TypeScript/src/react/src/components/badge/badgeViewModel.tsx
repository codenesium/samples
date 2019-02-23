import moment from 'moment'


export default class BadgeViewModel {
    date:any;
id:number;
name:string;
userId:number;

    constructor() {
		this.date = undefined;
this.id = 0;
this.name = '';
this.userId = 0;

    }

	setProperties(date : any,id : number,name : string,userId : number) : void
	{
		this.date = date;
this.id = id;
this.name = name;
this.userId = userId;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>a0945321001a028e89551660ae681d29</Hash>
</Codenesium>*/