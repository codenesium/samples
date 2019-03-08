import moment from 'moment';

export default class PostTypesViewModel {
  id: number;
  rwType: string;

  constructor() {
    this.id = 0;
    this.rwType = '';
  }

  setProperties(id: number, rwType: string): void {
    this.id = id;
    this.rwType = rwType;
  }

  toDisplay(): string {
    return String(this.rwType);
  }
}


/*<Codenesium>
    <Hash>a88543661f62fe0b156e93b50bdc5355</Hash>
</Codenesium>*/