import moment from 'moment';
import OfficerCapabilityViewModel from '../officerCapability/officerCapabilityViewModel';
import OfficerViewModel from '../officer/officerViewModel';

export default class OfficerCapabilitiesViewModel {
  capabilityId: number;
  capabilityIdEntity: string;
  capabilityIdNavigation?: OfficerCapabilityViewModel;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerViewModel;

  constructor() {
    this.capabilityId = 0;
    this.capabilityIdEntity = '';
    this.capabilityIdNavigation = new OfficerCapabilityViewModel();
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = new OfficerViewModel();
  }

  setProperties(capabilityId: number, officerId: number): void {
    this.capabilityId = capabilityId;
    this.officerId = officerId;
  }

  toDisplay(): string {
    return String(this.capabilityId);
  }
}


/*<Codenesium>
    <Hash>68a57102e99b391c3a56264fc86548cb</Hash>
</Codenesium>*/