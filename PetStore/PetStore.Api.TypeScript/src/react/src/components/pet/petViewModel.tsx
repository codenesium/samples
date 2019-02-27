import moment from 'moment'
import BreedViewModel from '../breed/breedViewModel'
	import PenViewModel from '../pen/penViewModel'
	

export default class PetViewModel {
    acquiredDate:any;
breedId:number;
breedIdEntity : string;
breedIdNavigation? : BreedViewModel;
description:string;
id:number;
penId:number;
penIdEntity : string;
penIdNavigation? : PenViewModel;
price:number;

    constructor() {
		this.acquiredDate = undefined;
this.breedId = 0;
this.breedIdEntity = '';
this.breedIdNavigation = new BreedViewModel();
this.description = '';
this.id = 0;
this.penId = 0;
this.penIdEntity = '';
this.penIdNavigation = new PenViewModel();
this.price = 0;

    }

	setProperties(acquiredDate : any,breedId : number,description : string,id : number,penId : number,price : number) : void
	{
		this.acquiredDate = acquiredDate;
this.breedId = breedId;
this.description = description;
this.id = id;
this.penId = penId;
this.price = price;

	}

	toDisplay() : string
	{
		return String(this.description);
	}
};

/*<Codenesium>
    <Hash>69a653e8c9f85f993ea3cb50baac609e</Hash>
</Codenesium>*/