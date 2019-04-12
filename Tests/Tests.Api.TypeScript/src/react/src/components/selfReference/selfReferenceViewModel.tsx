import moment from 'moment';

export default class SelfReferenceViewModel {
  id: number;
  selfReferenceId: number;
  selfReferenceIdEntity: string;
  selfReferenceIdNavigation?: SelfReferenceViewModel;
  selfReferenceId2: number;
  selfReferenceId2Entity: string;
  selfReferenceId2Navigation?: SelfReferenceViewModel;

  constructor() {
    this.id = 0;
    this.selfReferenceId = 0;
    this.selfReferenceIdEntity = '';
    this.selfReferenceIdNavigation = undefined;
    this.selfReferenceId2 = 0;
    this.selfReferenceId2Entity = '';
    this.selfReferenceId2Navigation = undefined;
  }

  setProperties(
    id: number,
    selfReferenceId: number,
    selfReferenceId2: number
  ): void {
    this.id = id;
    this.selfReferenceId = selfReferenceId;
    this.selfReferenceId2 = selfReferenceId2;
  }

  toDisplay(): string {
    return String(this.NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>37806e09d92ac0c9f72566aebd652f53</Hash>
</Codenesium>*/