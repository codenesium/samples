import moment from 'moment';
import VehicleCapabilityViewModel from '../vehicleCapability/vehicleCapabilityViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';

export default class VehicleRefCapabilityViewModel {
  id: number;
  vehicleCapabilityId: number;
  vehicleCapabilityIdEntity: string;
  vehicleCapabilityIdNavigation?: VehicleCapabilityViewModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleViewModel;

  constructor() {
    this.id = 0;
    this.vehicleCapabilityId = 0;
    this.vehicleCapabilityIdEntity = '';
    this.vehicleCapabilityIdNavigation = new VehicleCapabilityViewModel();
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = new VehicleViewModel();
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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>78850bcd66e0e9e41fb1e9265952ffd9</Hash>
</Codenesium>*/