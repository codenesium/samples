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
    return String(this.gps_lat);
  }
}


/*<Codenesium>
    <Hash>d80dc08efb6cbb91e0e7cb611acfab14</Hash>
</Codenesium>*/