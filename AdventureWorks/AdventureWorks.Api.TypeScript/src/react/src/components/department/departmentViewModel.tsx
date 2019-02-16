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
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>f32253cc52a435931a21b559f06c0338</Hash>
</Codenesium>*/