import moment from 'moment'


export default class ProductCategoryViewModel {
    modifiedDate:any;
name:string;
productCategoryID:number;
rowguid:any;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.productCategoryID = 0;
this.rowguid = undefined;

    }

	setProperties(modifiedDate : any,name : string,productCategoryID : number,rowguid : any) : void
	{
		this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.productCategoryID = moment(productCategoryID,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>9122575754882c86e949d3f41bd57cd2</Hash>
</Codenesium>*/