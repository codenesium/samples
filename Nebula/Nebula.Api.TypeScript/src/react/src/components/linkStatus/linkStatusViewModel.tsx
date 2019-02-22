import moment from 'moment';

export default class LinkStatusViewModel {
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
    return String();
  }
}


/*<Codenesium>
    <Hash>2dcbdb0c8c6d4e5c50586aac312a849e</Hash>
</Codenesium>*/