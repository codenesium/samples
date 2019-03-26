import moment from 'moment';
import PersonViewModel from '../person/personViewModel';

export default class ColumnSameAsFKTableViewModel {
  id: number;
  person: number;
  personEntity: string;
  personNavigation?: PersonViewModel;
  personId: number;
  personIdEntity: string;
  personIdNavigation?: PersonViewModel;

  constructor() {
    this.id = 0;
    this.person = 0;
    this.personEntity = '';
    this.personNavigation = undefined;
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = undefined;
  }

  setProperties(id: number, person: number, personId: number): void {
    this.id = id;
    this.person = person;
    this.personId = personId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>4e9084f6ee80eea4c97c5274ad7dc614</Hash>
</Codenesium>*/