export default class RowVersionCheckViewModel {
    id:number;
name:string;
rowVersion:any;

    constructor() {
		this.id = 0;
this.name = '';
this.rowVersion = undefined;

    }

	setProperties(id : number,name : string,rowVersion : any) : void
	{
		this.id = id;
this.name = name;
this.rowVersion = rowVersion;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>4ada0e598cac69238de743eafbacb6ec</Hash>
</Codenesium>*/