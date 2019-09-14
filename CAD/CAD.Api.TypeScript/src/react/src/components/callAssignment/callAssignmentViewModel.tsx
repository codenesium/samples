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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>8ef5bf9ad0d659d215db00d66b0799c2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/