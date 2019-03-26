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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>613b99aa54b09d0a4247401da4974a8f</Hash>
</Codenesium>*/