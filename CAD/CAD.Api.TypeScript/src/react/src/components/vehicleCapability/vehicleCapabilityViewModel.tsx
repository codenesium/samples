import moment from 'moment';

export default class VehicleCapabilityViewModel {
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
    <Hash>9e0e523c206206321f5df08b14784edd</Hash>
</Codenesium>*/