import moment from 'moment';
import BreedViewModel from '../breed/breedViewModel';

export default class PetViewModel {
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedViewModel;
  clientId: number;
  id: number;
  name: string;
  weight: number;

  constructor() {
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.clientId = 0;
    this.id = 0;
    this.name = '';
    this.weight = 0;
  }

  setProperties(
    breedId: number,
    clientId: number,
    id: number,
    name: string,
    weight: number
  ): void {
    this.breedId = breedId;
    this.clientId = clientId;
    this.id = id;
    this.name = name;
    this.weight = weight;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>5e7dbabf97dbfa33f2b1dbfd8017794b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/