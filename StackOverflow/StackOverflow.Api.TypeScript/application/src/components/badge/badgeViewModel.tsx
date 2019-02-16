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
		return String();
	}
};

/*<Codenesium>
    <Hash>fddddfff7d67e9ad98ed816fe6840e57</Hash>
</Codenesium>*/