import moment from 'moment';

export default class VehCapabilityViewModel {
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
    <Hash>e465707873ec9e64829b20e72089c1ce</Hash>
</Codenesium>*/