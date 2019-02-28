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
    this.breedIdNavigation = new BreedViewModel();
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
    <Hash>243b732372cf1c351ca88ea505887301</Hash>
</Codenesium>*/