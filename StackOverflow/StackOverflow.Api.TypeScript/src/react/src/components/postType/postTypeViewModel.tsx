export default class PostTypeViewModel {
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
    <Hash>6aa071792fa320d4a932c28a028d91dd</Hash>
</Codenesium>*/