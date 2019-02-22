import moment from 'moment';
import CallViewModel from '../call/callViewModel';
import UnitViewModel from '../unit/unitViewModel';

export default class CallAssignmentViewModel {
  callId: number;
  callIdEntity: string;
  callIdNavigation?: CallViewModel;
  id: number;
  unitId: number;
  unitIdEntity: string;
  unitIdNavigation?: UnitViewModel;

  constructor() {
    this.callId = 0;
    this.callIdEntity = '';
    this.callIdNavigation = new CallViewModel();
    this.id = 0;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = new UnitViewModel();
  }

  setProperties(callId: number, id: number, unitId: number): void {
    this.callId = callId;
    this.id = id;
    this.unitId = unitId;
  }

  toDisplay(): string {
    return String(this.callId);
  }
}


/*<Codenesium>
    <Hash>bbebac4903fc27d2ea7a83a200b22d3f</Hash>
</Codenesium>*/