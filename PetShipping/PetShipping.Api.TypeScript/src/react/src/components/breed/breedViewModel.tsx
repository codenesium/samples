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
    this.speciesIdNavigation = new SpeciesViewModel();
  }

  setProperties(id: number, name: string, speciesId: number): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.speciesId = moment(speciesId, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>bc8801d78239c6422cf61b628c818380</Hash>
</Codenesium>*/