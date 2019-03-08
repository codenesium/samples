import moment from 'moment';

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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>c042456deaca066e6fbc8b5f4f74d17f</Hash>
</Codenesium>*/