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
    return String(this.capabilityId);
  }
}


/*<Codenesium>
    <Hash>8110cf38032a8562fe191976bffcaef5</Hash>
</Codenesium>*/