import moment from 'moment';

export default class PersonViewModel {
  personId: number;
  personName: string;

  constructor() {
    this.personId = 0;
    this.personName = '';
  }

  setProperties(personId: number, personName: string): void {
    this.personId = personId;
    this.personName = personName;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>7325c5df07be3c1a21fcb7f2f45df6a5</Hash>
</Codenesium>*/