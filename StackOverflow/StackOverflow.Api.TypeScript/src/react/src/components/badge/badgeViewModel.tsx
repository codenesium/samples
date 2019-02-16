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
    <Hash>50a7404240c08b6c80e5331b9082cdf0</Hash>
</Codenesium>*/