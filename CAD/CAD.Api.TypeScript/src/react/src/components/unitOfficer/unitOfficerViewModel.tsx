import moment from 'moment';
import OfficerViewModel from '../officer/officerViewModel';
import UnitViewModel from '../unit/unitViewModel';

export default class UnitOfficerViewModel {
  id: number;
  officerId: number;
  officerIdEntity: string;
  officerIdNavigation?: OfficerViewModel;
  unitId: number;
  unitIdEntity: string;
  unitIdNavigation?: UnitViewModel;

  constructor() {
    this.id = 0;
    this.officerId = 0;
    this.officerIdEntity = '';
    this.officerIdNavigation = new OfficerViewModel();
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = new UnitViewModel();
  }

  setProperties(id: number, officerId: number, unitId: number): void {
    this.id = id;
    this.officerId = officerId;
    this.unitId = unitId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>480d314254decdbf140f09c693488fad</Hash>
</Codenesium>*/