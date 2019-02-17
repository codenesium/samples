export default class OrganizationViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>641312349d65a516461c8ecb5f20acc6</Hash>
</Codenesium>*/