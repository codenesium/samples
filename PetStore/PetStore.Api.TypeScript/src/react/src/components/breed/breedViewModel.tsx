import moment from 'moment';
import SpeciesViewModel from '../species/speciesViewModel';

export default class BreedViewModel {
  id: number;
  name: string;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesViewModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = undefined;
  }

  setProperties(id: number, name: string, speciesId: number): void {
    this.id = id;
    this.name = name;
    this.speciesId = speciesId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>b4c1c41dedd3a70cc6de11568f63408e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/