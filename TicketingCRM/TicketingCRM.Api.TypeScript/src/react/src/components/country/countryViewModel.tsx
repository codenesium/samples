import moment from 'moment';

export default class CountryViewModel {
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
    <Hash>f65c1f21e3d16ef26777dbb164eb5e9f</Hash>
</Codenesium>*/