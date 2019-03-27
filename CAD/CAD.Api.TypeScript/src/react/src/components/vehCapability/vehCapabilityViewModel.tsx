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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>ece1ea69652790da4198dafd28c015f8</Hash>
</Codenesium>*/