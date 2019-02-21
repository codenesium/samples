import moment from 'moment';

export default class VPersonViewModel {
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
    <Hash>26b71710ccbd1de6459be04b8a58d7d5</Hash>
</Codenesium>*/