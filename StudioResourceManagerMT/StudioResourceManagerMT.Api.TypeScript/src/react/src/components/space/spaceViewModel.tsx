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
    return String();
  }
}


/*<Codenesium>
    <Hash>72d2b6f03c404377bd496cc4d56a51e1</Hash>
</Codenesium>*/