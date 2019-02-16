export default class EventStatuViewModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(
    id: number,
    isDeleted: boolean,
    name: string,
    tenantId: number
  ): void {
    this.id = id;
    this.isDeleted = isDeleted;
    this.name = name;
    this.tenantId = tenantId;
  }
}


/*<Codenesium>
    <Hash>5d52e201aae41eb624f6123ecdb3c6d5</Hash>
</Codenesium>*/