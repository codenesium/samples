import moment from 'moment'


export default class LocationViewModel {
    gpsLat:number;
gpsLong:number;
locationId:number;
locationName:string;

    constructor() {
		this.gpsLat = 0;
this.gpsLong = 0;
this.locationId = 0;
this.locationName = '';

    }

	setProperties(gpsLat : number,gpsLong : number,locationId : number,locationName : string) : void
	{
		this.gpsLat = gpsLat;
this.gpsLong = gpsLong;
this.locationId = locationId;
this.locationName = locationName;

	}

	toDisplay() : string
	{
		return String(this.gps_lat);
	}
};

/*<Codenesium>
    <Hash>e05bc5fb743b0c4f2863eb28b143eec8</Hash>
</Codenesium>*/