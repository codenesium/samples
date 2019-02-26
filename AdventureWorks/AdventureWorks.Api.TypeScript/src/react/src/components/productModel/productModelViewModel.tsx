import moment from 'moment'


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
		this.catalogDescription = moment(catalogDescription,'YYYY-MM-DD');
this.instruction = moment(instruction,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.productModelID = moment(productModelID,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>a55c8f2e9df5eded609b4e4c9299ba95</Hash>
</Codenesium>*/