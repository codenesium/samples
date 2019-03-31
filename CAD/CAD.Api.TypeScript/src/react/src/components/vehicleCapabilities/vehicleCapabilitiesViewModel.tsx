import moment from 'moment';
import VehCapabilityViewModel from '../vehCapability/vehCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';

export default class VehicleCapabilitiesViewModel {
  id: number;
  vehicleCapabilityId: number;
  vehicleCapabilityIdEntity: string;
  vehicleCapabilityIdNavigation?: VehCapabilityViewModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleViewModel;

  constructor() {
    this.id = 0;
    this.vehicleCapabilityId = 0;
    this.vehicleCapabilityIdEntity = '';
    this.vehicleCapabilityIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(
    id: number,
    vehicleCapabilityId: number,
    vehicleId: number
  ): void {
    this.id = id;
    this.vehicleCapabilityId = vehicleCapabilityId;
    this.vehicleId = vehicleId;
  }

  toDisplay(): string {
    return String(this.vehicleCapabilityId);
  }
}


/*<Codenesium>
    <Hash>102adb2a620f992972524f395927cdef</Hash>
</Codenesium>*/