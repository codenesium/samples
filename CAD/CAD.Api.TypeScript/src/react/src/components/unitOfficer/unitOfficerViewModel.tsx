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
    this.officerIdNavigation = undefined;
    this.unitId = 0;
    this.unitIdEntity = '';
    this.unitIdNavigation = undefined;
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
    <Hash>5f8d5d1049e8da1f108fe31583935c60</Hash>
</Codenesium>*/