import moment from 'moment'
import SpeciesViewModel from '../species/speciesViewModel'
	

export default class BreedViewModel {
    id:number;
name:string;
speciesId:number;
speciesIdEntity : string;
speciesIdNavigation? : SpeciesViewModel;

    constructor() {
		this.id = 0;
this.name = '';
this.speciesId = 0;
this.speciesIdEntity = '';
this.speciesIdNavigation = new SpeciesViewModel();

    }

	setProperties(id : number,name : string,speciesId : number) : void
	{
		this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.speciesId = moment(speciesId,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>7b483a947c0ece749e6b7bc5f9b21760</Hash>
</Codenesium>*/