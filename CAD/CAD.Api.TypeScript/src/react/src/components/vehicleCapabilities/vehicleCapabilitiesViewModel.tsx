import moment from 'moment'
import VehicleCapabilityViewModel from '../vehicleCapability/vehicleCapabilityViewModel'
	import VehicleViewModel from '../vehicle/vehicleViewModel'
	

export default class VehicleCapabilitiesViewModel {
    vehicleCapabilityId:number;
vehicleCapabilityIdEntity : string;
vehicleCapabilityIdNavigation? : VehicleCapabilityViewModel;
vehicleId:number;
vehicleIdEntity : string;
vehicleIdNavigation? : VehicleViewModel;

    constructor() {
		this.vehicleCapabilityId = 0;
this.vehicleCapabilityIdEntity = '';
this.vehicleCapabilityIdNavigation = new VehicleCapabilityViewModel();
this.vehicleId = 0;
this.vehicleIdEntity = '';
this.vehicleIdNavigation = new VehicleViewModel();

    }

	setProperties(vehicleCapabilityId : number,vehicleId : number) : void
	{
		this.vehicleCapabilityId = vehicleCapabilityId;
this.vehicleId = vehicleId;

	}

	toDisplay() : string
	{
		return String(this.vehicleCapabilityId);
	}
};

/*<Codenesium>
    <Hash>0f36528fc148e3ad7ba931e53628fc82</Hash>
</Codenesium>*/