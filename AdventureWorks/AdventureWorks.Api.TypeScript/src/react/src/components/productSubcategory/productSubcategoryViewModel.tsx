import moment from 'moment'


export default class ProductSubcategoryViewModel {
    modifiedDate:any;
name:string;
productCategoryID:number;
productSubcategoryID:number;
rowguid:any;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.productCategoryID = 0;
this.productSubcategoryID = 0;
this.rowguid = undefined;

    }

	setProperties(modifiedDate : any,name : string,productCategoryID : number,productSubcategoryID : number,rowguid : any) : void
	{
		this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.productCategoryID = moment(productCategoryID,'YYYY-MM-DD');
this.productSubcategoryID = moment(productSubcategoryID,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>f575be4ec6b442f8564593a40409e0b2</Hash>
</Codenesium>*/