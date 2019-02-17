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
    this.dateCreated = dateCreated;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.shoppingCartID = shoppingCartID;
    this.shoppingCartItemID = shoppingCartItemID;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>c6bdabc690a118c58c65135b457da877</Hash>
</Codenesium>*/