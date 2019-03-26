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
    return String(this.breedId);
  }
}


/*<Codenesium>
    <Hash>6ae95cda9921f13ca0534bc9895f174d</Hash>
</Codenesium>*/