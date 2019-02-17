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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>77338a350f01ebd2ade4968e179e6a46</Hash>
</Codenesium>*/