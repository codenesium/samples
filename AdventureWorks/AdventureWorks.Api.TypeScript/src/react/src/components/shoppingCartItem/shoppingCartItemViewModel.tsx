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
}


/*<Codenesium>
    <Hash>8ce26e84ae34225984b5e036b9939610</Hash>
</Codenesium>*/