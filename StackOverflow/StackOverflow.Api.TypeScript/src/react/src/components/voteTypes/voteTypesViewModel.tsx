import moment from 'moment';

export default class VoteTypesViewModel {
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
    <Hash>285ea54c11118aaf6bf3865aa97c2a34</Hash>
</Codenesium>*/