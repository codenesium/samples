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
    return String(this.personId);
  }
}


/*<Codenesium>
    <Hash>79294abc85bd2d910ca613e3463d203d</Hash>
</Codenesium>*/