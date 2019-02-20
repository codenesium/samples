export default class PostTypeViewModel {
    id:number;
rwType:string;

    constructor() {
		this.id = 0;
this.rwType = '';

    }

	setProperties(id : number,rwType : string) : void
	{
		this.id = id;
this.rwType = rwType;

	}

	toDisplay() : string
	{
		return String(this.rwType);
	}
};

/*<Codenesium>
    <Hash>3775a467f0a7b9312af759980dd92c28</Hash>
</Codenesium>*/