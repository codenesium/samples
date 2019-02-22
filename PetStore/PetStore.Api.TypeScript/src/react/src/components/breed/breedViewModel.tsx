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
		this.id = id;
this.name = name;
this.speciesId = speciesId;

	}

	toDisplay() : string
	{
		return String(this.name);
	}
};

/*<Codenesium>
    <Hash>8877397a92ece5e4d811cc01ebb64220</Hash>
</Codenesium>*/