import moment from 'moment';
import ProductViewModel from '../product/productViewModel';
import ProductPhotoViewModel from '../productPhoto/productPhotoViewModel';

export default class ProductProductPhotoViewModel {
  modifiedDate: any;
  primary: boolean;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductViewModel;
  productPhotoID: number;
  productPhotoIDEntity: string;
  productPhotoIDNavigation?: ProductPhotoViewModel;

  constructor() {
    this.modifiedDate = undefined;
    this.primary = false;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.productPhotoID = 0;
    this.productPhotoIDEntity = '';
    this.productPhotoIDNavigation = undefined;
  }

  setProperties(
    modifiedDate: any,
    primary: boolean,
    productID: number,
    productPhotoID: number
  ): void {
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.primary = primary;
    this.productID = productID;
    this.productPhotoID = productPhotoID;
  }

  toDisplay(): string {
    return String(this.modifiedDate);
  }
}


/*<Codenesium>
    <Hash>3432d3f6a9335e71bcb4e984a04bd4ef</Hash>
</Codenesium>*/