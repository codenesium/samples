import moment from 'moment';
import OffCapabilityViewModel from '../offCapability/offCapabilityViewModel';
import OfficerViewModel from '../officer/officerViewModel';

export default class OfficerCapabilitiesViewModel {
  capabilityId: number;
  capabilityIdEntity: string;
  capabilityIdNavigation?: OffCapabilityViewModel;
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerViewModel;

  constructor() {
    this.capabilityId = 0;
    this.capabilityIdEntity = '';
    this.capabilityIdNavigation = undefined;
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
  }

  setProperties(capabilityId: number, id: number, officerId: number): void {
    this.capabilityId = capabilityId;
    this.id = id;
    this.officerId = officerId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>2e2c8084639706d7e03d1b904bce79ff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/