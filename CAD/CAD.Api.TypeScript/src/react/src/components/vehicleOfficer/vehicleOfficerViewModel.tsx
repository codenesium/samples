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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>ddf42858d9c612f632e20df812fc4ed2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/