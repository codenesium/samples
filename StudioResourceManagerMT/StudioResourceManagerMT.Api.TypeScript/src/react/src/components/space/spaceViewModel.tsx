import moment from 'moment';

export default class SpaceViewModel {
  description: string;
  id: number;
  name: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.name = '';
  }

  setProperties(description: string, id: number, name: string): void {
    this.description = description;
    this.id = id;
    this.name = name;
  }

  toDisplay(): string {
    return String(this.description);
  }
}


/*<Codenesium>
    <Hash>798b4b034cc942313cd57340eab627ff</Hash>
</Codenesium>*/