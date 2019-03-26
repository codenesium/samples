import moment from 'moment';

export default class DepartmentViewModel {
  departmentID: number;
  groupName: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.departmentID = 0;
    this.groupName = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    departmentID: number,
    groupName: string,
    modifiedDate: any,
    name: string
  ): void {
    this.departmentID = departmentID;
    this.groupName = groupName;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>a73b537877292b668a167e905529b75d</Hash>
</Codenesium>*/