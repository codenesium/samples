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
    <Hash>f29c1c92c0fb96832d130ab6dafa3399</Hash>
</Codenesium>*/