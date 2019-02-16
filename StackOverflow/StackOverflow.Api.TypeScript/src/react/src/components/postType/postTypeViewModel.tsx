export default class PostTypeViewModel {
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
    <Hash>67571446408034340066d1830d2a68e1</Hash>
</Codenesium>*/