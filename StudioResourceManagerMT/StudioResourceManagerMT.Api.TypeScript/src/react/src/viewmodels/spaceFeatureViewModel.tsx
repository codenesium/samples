export default class SpaceFeatureViewModel {
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
    <Hash>904833c0e38d019eb786a281240eec43</Hash>
</Codenesium>*/