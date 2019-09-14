import moment from 'moment';

export default class LocationViewModel {
  gpsLat: number;
  gpsLong: number;
  locationId: number;
  locationName: string;

  constructor() {
    this.gpsLat = 0;
    this.gpsLong = 0;
    this.locationId = 0;
    this.locationName = '';
  }

  setProperties(
    gpsLat: number,
    gpsLong: number,
    locationId: number,
    locationName: string
  ): void {
    this.gpsLat = gpsLat;
    this.gpsLong = gpsLong;
    this.locationId = locationId;
    this.locationName = locationName;
  }

  toDisplay(): string {
    return String(this.locationName);
  }
}


/*<Codenesium>
    <Hash>e6430b600d15aa58639d6291dd7dae70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/