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
    return String(this.personId);
  }
}


/*<Codenesium>
    <Hash>b4ff224e8b903d948b82297a62063764</Hash>
</Codenesium>*/