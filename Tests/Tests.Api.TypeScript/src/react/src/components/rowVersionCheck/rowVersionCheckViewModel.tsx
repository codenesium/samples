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
		return String(NULL_STRING_PASSED_ToLowerCaseFirstLetter);
	}
};

/*<Codenesium>
    <Hash>35cddab18909cc96bc0640dd11920810</Hash>
</Codenesium>*/