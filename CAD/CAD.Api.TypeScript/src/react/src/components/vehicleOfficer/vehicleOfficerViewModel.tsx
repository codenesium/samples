import moment from 'moment';
import OfficerViewModel from '../officer/officerViewModel';
import VehicleViewModel from '../vehicle/vehicleViewModel';

export default class VehicleOfficerViewModel {
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerViewModel;
  vehicleId: number;
  vehicleIdEntity: string;
  vehicleIdNavigation?: VehicleViewModel;

  constructor() {
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = undefined;
  }

  setProperties(id: number, officerId: number, vehicleId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.vehicleId = vehicleId;
  }

  toDisplay(): string {
    return String(this.officerId);
  }
}


/*<Codenesium>
    <Hash>bf8fb741fe3f6a5002a8b6e3bf84aec1</Hash>
</Codenesium>*/