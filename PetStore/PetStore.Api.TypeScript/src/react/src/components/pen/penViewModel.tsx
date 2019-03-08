import moment from 'moment';

export default class PenViewModel {
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
    <Hash>753fa2dab83e6e6ae8a47d4b2fb55edc</Hash>
</Codenesium>*/