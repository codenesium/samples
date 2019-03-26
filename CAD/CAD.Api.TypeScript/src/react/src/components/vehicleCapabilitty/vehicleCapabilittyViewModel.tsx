import moment from 'moment';
import VehicleCapabilityViewModel from '../vehicleCapability/vehicleCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';

export default class VehicleCapabilittyViewModel {
  vehicleCapabilityId: number;
  vehicleCapabilityIdEntity: string;
  vehicleCapabilityIdNavigation?: VehicleCapabilityViewModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleViewModel;

  constructor() {
    this.vehicleCapabilityId = 0;
    this.vehicleCapabilityIdEntity = '';
    this.vehicleCapabilityIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(vehicleCapabilityId: number, vehicleId: number): void {
    this.vehicleCapabilityId = vehicleCapabilityId;
    this.vehicleId = vehicleId;
  }

  toDisplay(): string {
    return String(this.vehicleCapabilityId);
  }
}


/*<Codenesium>
    <Hash>994b81493295c7fcc485b7a2fe20f0ab</Hash>
</Codenesium>*/