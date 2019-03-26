import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>5ed2b07dd2040bbc7563ce24a0fdc7ec</Hash>
</Codenesium>*/