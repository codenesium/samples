import moment from 'moment';
import SpeciesViewModel from '../species/speciesViewModel';

export default class BreedViewModel {
  name: string;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesViewModel;

  constructor() {
    this.name = '';
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = new SpeciesViewModel();
  }

  setProperties(name: string, speciesId: number): void {
    this.name = name;
    this.speciesId = speciesId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>fadf38a15acddbc744e2e000c3e3968f</Hash>
</Codenesium>*/