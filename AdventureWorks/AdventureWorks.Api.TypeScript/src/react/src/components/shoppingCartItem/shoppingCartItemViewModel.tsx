import moment from 'moment';

export default class ShoppingCartItemViewModel {
  dateCreated: any;
  modifiedDate: any;
  productID: number;
  quantity: number;
  shoppingCartID: string;
  shoppingCartItemID: number;

  constructor() {
    this.dateCreated = undefined;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.quantity = 0;
    this.shoppingCartID = '';
    this.shoppingCartItemID = 0;
  }

  setProperties(
    dateCreated: any,
    modifiedDate: any,
    productID: number,
    quantity: number,
    shoppingCartID: string,
    shoppingCartItemID: number
  ): void {
    this.dateCreated = moment(dateCreated, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productID = productID;
    this.quantity = quantity;
    this.shoppingCartID = shoppingCartID;
    this.shoppingCartItemID = shoppingCartItemID;
  }

  toDisplay(): string {
    return String(this.dateCreated);
  }
}


/*<Codenesium>
    <Hash>4787d5977545e90f955e80bb188344f4</Hash>
</Codenesium>*/