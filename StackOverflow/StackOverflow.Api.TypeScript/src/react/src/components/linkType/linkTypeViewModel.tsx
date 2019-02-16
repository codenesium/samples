export default class LinkTypeViewModel {
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
    <Hash>d242c2b2bffe629bd2f6ac5bb20475bd</Hash>
</Codenesium>*/