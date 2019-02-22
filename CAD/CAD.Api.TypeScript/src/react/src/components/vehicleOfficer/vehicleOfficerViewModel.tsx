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
    this.officerIdNavigation = new OfficerViewModel();
    this.vehicleId = 0;
    this.vehicleIdEntity = '';
    this.vehicleIdNavigation = new VehicleViewModel();
  }

  setProperties(id: number, officerId: number, vehicleId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.vehicleId = vehicleId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>d2a309f4c90dc17f49a7585380cfa1a0</Hash>
</Codenesium>*/