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
    <Hash>a42f4ded50d6c5a5f1e2f418ab60747f</Hash>
</Codenesium>*/