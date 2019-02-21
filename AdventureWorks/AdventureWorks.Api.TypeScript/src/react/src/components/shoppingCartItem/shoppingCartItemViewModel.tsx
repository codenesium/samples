import moment from 'moment'


export default class ShoppingCartItemViewModel {
    dateCreated:any;
modifiedDate:any;
productID:number;
quantity:number;
shoppingCartID:string;
shoppingCartItemID:number;

    constructor() {
		this.dateCreated = undefined;
this.modifiedDate = undefined;
this.productID = 0;
this.quantity = 0;
this.shoppingCartID = '';
this.shoppingCartItemID = 0;

    }

	setProperties(dateCreated : any,modifiedDate : any,productID : number,quantity : number,shoppingCartID : string,shoppingCartItemID : number) : void
	{
		this.dateCreated = moment(dateCreated,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.productID = moment(productID,'YYYY-MM-DD');
this.quantity = moment(quantity,'YYYY-MM-DD');
this.shoppingCartID = moment(shoppingCartID,'YYYY-MM-DD');
this.shoppingCartItemID = moment(shoppingCartItemID,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>c5a041f9c601683d014c19946815d4b6</Hash>
</Codenesium>*/