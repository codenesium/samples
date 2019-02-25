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
    this.departmentID = moment(departmentID, 'YYYY-MM-DD');
    this.groupName = moment(groupName, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>1139cc4348c3b26e6c531df2bd86aed9</Hash>
</Codenesium>*/