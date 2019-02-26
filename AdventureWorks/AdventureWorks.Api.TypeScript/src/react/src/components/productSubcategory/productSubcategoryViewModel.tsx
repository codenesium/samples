import moment from 'moment'
import ProductCategoryViewModel from '../productCategory/productCategoryViewModel'
	

export default class ProductSubcategoryViewModel {
    modifiedDate:any;
name:string;
productCategoryID:number;
productCategoryIDEntity : string;
productCategoryIDNavigation? : ProductCategoryViewModel;
productSubcategoryID:number;
rowguid:any;

    constructor() {
		this.modifiedDate = undefined;
this.name = '';
this.productCategoryID = 0;
this.productCategoryIDEntity = '';
this.productCategoryIDNavigation = new ProductCategoryViewModel();
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
    <Hash>40d95b13353293a4a02b32ed00fe668e</Hash>
</Codenesium>*/