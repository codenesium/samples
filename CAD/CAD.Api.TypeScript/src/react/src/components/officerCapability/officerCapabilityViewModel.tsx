import moment from 'moment';
import OfficerViewModel from '../officer/officerViewModel';

export default class OfficerCapabilityViewModel {
  capabilityId: number;
  capabilityIdEntity: string;
  capabilityIdNavigation?: OfficerCapabilityViewModel;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerViewModel;

  constructor() {
    this.capabilityId = 0;
    this.capabilityIdEntity = '';
    this.capabilityIdNavigation = undefined;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = undefined;
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
    <Hash>7ec229401630d22f7950a1d48505c6ac</Hash>
</Codenesium>*/