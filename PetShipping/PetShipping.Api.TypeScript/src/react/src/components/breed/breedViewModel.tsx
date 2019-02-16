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
    return String();
  }
}


/*<Codenesium>
    <Hash>fae204d7f094d1c84576a25f5d974a26</Hash>
</Codenesium>*/