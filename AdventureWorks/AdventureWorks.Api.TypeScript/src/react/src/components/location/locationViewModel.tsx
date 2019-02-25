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
    this.availability = moment(availability, 'YYYY-MM-DD');
    this.costRate = moment(costRate, 'YYYY-MM-DD');
    this.locationID = moment(locationID, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>07a3e02dd4878efe543715051b7dd786</Hash>
</Codenesium>*/