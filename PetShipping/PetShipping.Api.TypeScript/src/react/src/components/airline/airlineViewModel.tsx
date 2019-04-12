import moment from 'moment';

export default class AirlineViewModel {
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
    <Hash>dbf30ed7d7c5bea87416c879d66b5e74</Hash>
</Codenesium>*/