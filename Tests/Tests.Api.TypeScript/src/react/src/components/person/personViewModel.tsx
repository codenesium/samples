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
    return String(this.NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>acb42e51e9a2cbdcb3c0b5553c952884</Hash>
</Codenesium>*/