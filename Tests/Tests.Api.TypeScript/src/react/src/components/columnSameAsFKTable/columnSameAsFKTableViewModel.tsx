import moment from 'moment';
import PersonViewModel from '../person/personViewModel';
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
    this.personNavigation = new PersonViewModel();
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = new PersonViewModel();
  }

  setProperties(id: number, person: number, personId: number): void {
    this.id = id;
    this.person = person;
    this.personId = personId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>47c479b2586c3253889046495667ba5b</Hash>
</Codenesium>*/