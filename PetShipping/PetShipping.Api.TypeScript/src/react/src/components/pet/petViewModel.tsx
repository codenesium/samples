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
		this.breedId = moment(breedId,'YYYY-MM-DD');
this.clientId = moment(clientId,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.weight = moment(weight,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>3ed4d052f161f7857863451bf2f7f7bc</Hash>
</Codenesium>*/