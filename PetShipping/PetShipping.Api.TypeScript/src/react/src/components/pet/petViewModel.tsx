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
    return String();
  }
}


/*<Codenesium>
    <Hash>d997aa718e250ca9d45b777901b2d167</Hash>
</Codenesium>*/