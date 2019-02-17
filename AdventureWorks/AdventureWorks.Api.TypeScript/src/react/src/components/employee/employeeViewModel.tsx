export default class EmployeeViewModel {
  birthDate: any;
  businessEntityID: number;
  currentFlag: boolean;
  gender: string;
  hireDate: any;
  jobTitle: string;
  loginID: string;
  maritalStatu: string;
  modifiedDate: any;
  nationalIDNumber: string;
  organizationLevel: any;
  rowguid: any;
  salariedFlag: boolean;
  sickLeaveHour: number;
  vacationHour: number;

  constructor() {
    this.birthDate = undefined;
    this.businessEntityID = 0;
    this.currentFlag = false;
    this.gender = '';
    this.hireDate = undefined;
    this.jobTitle = '';
    this.loginID = '';
    this.maritalStatu = '';
    this.modifiedDate = undefined;
    this.nationalIDNumber = '';
    this.organizationLevel = undefined;
    this.rowguid = undefined;
    this.salariedFlag = false;
    this.sickLeaveHour = 0;
    this.vacationHour = 0;
  }

  setProperties(
    birthDate: any,
    businessEntityID: number,
    currentFlag: boolean,
    gender: string,
    hireDate: any,
    jobTitle: string,
    loginID: string,
    maritalStatu: string,
    modifiedDate: any,
    nationalIDNumber: string,
    organizationLevel: any,
    rowguid: any,
    salariedFlag: boolean,
    sickLeaveHour: number,
    vacationHour: number
  ): void {
    this.birthDate = birthDate;
    this.businessEntityID = businessEntityID;
    this.currentFlag = currentFlag;
    this.gender = gender;
    this.hireDate = hireDate;
    this.jobTitle = jobTitle;
    this.loginID = loginID;
    this.maritalStatu = maritalStatu;
    this.modifiedDate = modifiedDate;
    this.nationalIDNumber = nationalIDNumber;
    this.organizationLevel = organizationLevel;
    this.rowguid = rowguid;
    this.salariedFlag = salariedFlag;
    this.sickLeaveHour = sickLeaveHour;
    this.vacationHour = vacationHour;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>80ec79571e3b995a408e3d3b4cb6cbe9</Hash>
</Codenesium>*/