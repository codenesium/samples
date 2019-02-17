export default class ProductModelViewModel {
    catalogDescription:string;
instruction:string;
modifiedDate:any;
name:string;
productModelID:number;
rowguid:any;

    constructor() {
		this.catalogDescription = '';
this.instruction = '';
this.modifiedDate = undefined;
this.name = '';
this.productModelID = 0;
this.rowguid = undefined;

    }

	setProperties(catalogDescription : string,instruction : string,modifiedDate : any,name : string,productModelID : number,rowguid : any) : void
	{
		this.catalogDescription = catalogDescription;
this.instruction = instruction;
this.modifiedDate = modifiedDate;
this.name = name;
this.productModelID = productModelID;
this.rowguid = rowguid;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>60c0cfe1c0a550b66d666c444c02732f</Hash>
</Codenesium>*/