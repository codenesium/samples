import moment from 'moment';

export default class LinkTypesViewModel {
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
    <Hash>efb1b6b236a69f6127b330173b784166</Hash>
</Codenesium>*/