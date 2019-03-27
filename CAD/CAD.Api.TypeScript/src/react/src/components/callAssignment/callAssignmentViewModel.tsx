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
    this.callIdNavigation = undefined;
    this.id = 0;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = undefined;
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
    <Hash>edf8403e8e48a1227364913f164e2b95</Hash>
</Codenesium>*/