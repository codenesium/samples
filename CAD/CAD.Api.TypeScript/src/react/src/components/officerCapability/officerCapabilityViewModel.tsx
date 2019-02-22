import moment from 'moment';

export default class OfficerCapabilityViewModel {
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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>7cc8b72f89bef0ee4b0f64054d843400</Hash>
</Codenesium>*/