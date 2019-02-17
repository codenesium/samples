import SelfReferenceViewModel from '../selfReference/selfReferenceViewModel';
import SelfReferenceViewModel from '../selfReference/selfReferenceViewModel';

export default class SelfReferenceViewModel {
  id: number;
  selfReferenceId: any;
  selfReferenceIdEntity: string;
  selfReferenceIdNavigation?: SelfReferenceViewModel;
  selfReferenceId2: any;
  selfReferenceId2Entity: string;
  selfReferenceId2Navigation?: SelfReferenceViewModel;

  constructor() {
    this.id = 0;
    this.selfReferenceId = undefined;
    this.selfReferenceIdEntity = '';
    this.selfReferenceIdNavigation = undefined;
    this.selfReferenceId2 = undefined;
    this.selfReferenceId2Entity = '';
    this.selfReferenceId2Navigation = undefined;
  }

  setProperties(id: number, selfReferenceId: any, selfReferenceId2: any): void {
    this.id = id;
    this.selfReferenceId = selfReferenceId;
    this.selfReferenceId2 = selfReferenceId2;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>5290b269f739c86361b9ca022d143ffb</Hash>
</Codenesium>*/