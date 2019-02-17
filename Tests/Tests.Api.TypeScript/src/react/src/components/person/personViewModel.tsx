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
    <Hash>ed6606b1e2bc568746d0916940ef3465</Hash>
</Codenesium>*/