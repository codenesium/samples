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
    return String();
  }
}


/*<Codenesium>
    <Hash>4ce925d144175d1c234767e8a2a8770c</Hash>
</Codenesium>*/