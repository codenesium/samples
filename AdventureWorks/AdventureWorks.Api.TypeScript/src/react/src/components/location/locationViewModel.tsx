export default class LocationViewModel {
  availability: number;
  costRate: number;
  locationID: number;
  modifiedDate: any;
  name: string;

  constructor() {
    this.availability = 0;
    this.costRate = 0;
    this.locationID = 0;
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    availability: number,
    costRate: number,
    locationID: number,
    modifiedDate: any,
    name: string
  ): void {
    this.availability = availability;
    this.costRate = costRate;
    this.locationID = locationID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>51cc94803bdb84955bb05ba3d39019e8</Hash>
</Codenesium>*/