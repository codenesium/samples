export default class PostHistoryTypeViewModel {
  id: number;
  type: string;

  constructor() {
    this.id = 0;
    this.type = '';
  }

  setProperties(id: number, type: string): void {
    this.id = id;
    this.type = type;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>355c49415da296060d774ca6c18fb468</Hash>
</Codenesium>*/