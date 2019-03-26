import moment from 'moment';
import ProductCategoryViewModel from '../productCategory/productCategoryViewModel';

export default class ProductSubcategoryViewModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  productCategoryIDEntity: string;
  productCategoryIDNavigation?: ProductCategoryViewModel;
  productSubcategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.productCategoryIDEntity = '';
    this.productCategoryIDNavigation = undefined;
    this.productSubcategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    productSubcategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.productSubcategoryID = productSubcategoryID;
    this.rowguid = rowguid;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>42f9c97f5f23ca27b01e57d7a1c72982</Hash>
</Codenesium>*/