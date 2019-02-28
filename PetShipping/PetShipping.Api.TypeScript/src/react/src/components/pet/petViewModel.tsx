import moment from 'moment'
import BreedViewModel from '../breed/breedViewModel'
	

export default class PetViewModel {
    breedId:number;
breedIdEntity : string;
breedIdNavigation? : BreedViewModel;
clientId:number;
id:number;
name:string;
weight:number;

    constructor() {
		this.breedId = 0;
this.breedIdEntity = '';
this.breedIdNavigation = new BreedViewModel();
this.clientId = 0;
this.id = 0;
this.name = '';
this.weight = 0;

    }

	setProperties(breedId : number,clientId : number,id : number,name : string,weight : number) : void
	{
		this.breedId = breedId;
this.clientId = clientId;
this.id = id;
this.name = name;
this.weight = weight;

	}

	toDisplay() : string
	{
		return String(this.breedId);
	}
};

/*<Codenesium>
    <Hash>8a013cfe2c5ef40fbf52fc26e9b7718d</Hash>
</Codenesium>*/