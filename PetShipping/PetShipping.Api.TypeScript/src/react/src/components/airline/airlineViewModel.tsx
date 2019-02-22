import moment from 'moment';

export default class AirlineViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>12375925056ecdb74514d9564cecea43</Hash>
</Codenesium>*/