import moment from 'moment';

export default class SpeciesViewModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>7c74b1178cfab6af6327db739f962896</Hash>
</Codenesium>*/