export default class LinkTypeViewModel {
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
    <Hash>a530d5622a3d86a1771a20675e91ed40</Hash>
</Codenesium>*/