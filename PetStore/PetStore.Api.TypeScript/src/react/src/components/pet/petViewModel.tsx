import BreedViewModel from '../breed/breedViewModel';
import PenViewModel from '../pen/penViewModel';
import SpeciesViewModel from '../species/speciesViewModel';

export default class PetViewModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedViewModel;
  description: string;
  id: number;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenViewModel;
  price: number;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesViewModel;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.description = '';
    this.id = 0;
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = undefined;
    this.price = 0;
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = undefined;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    id: number,
    penId: number,
    price: number,
    speciesId: number
  ): void {
    this.acquiredDate = acquiredDate;
    this.breedId = breedId;
    this.description = description;
    this.id = id;
    this.penId = penId;
    this.price = price;
    this.speciesId = speciesId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>302baf7e674f9f8b28bcc97be4657f99</Hash>
</Codenesium>*/