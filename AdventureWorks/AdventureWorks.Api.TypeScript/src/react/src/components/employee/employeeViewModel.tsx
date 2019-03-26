import moment from 'moment';

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
  organizationLevel: number;
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
    this.organizationLevel = 0;
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
    organizationLevel: number,
    rowguid: any,
    salariedFlag: boolean,
    sickLeaveHour: number,
    vacationHour: number
  ): void {
    this.birthDate = moment(birthDate, 'YYYY-MM-DD');
    this.businessEntityID = businessEntityID;
    this.currentFlag = currentFlag;
    this.gender = gender;
    this.hireDate = moment(hireDate, 'YYYY-MM-DD');
    this.jobTitle = jobTitle;
    this.loginID = loginID;
    this.maritalStatu = maritalStatu;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.nationalIDNumber = nationalIDNumber;
    this.organizationLevel = organizationLevel;
    this.rowguid = rowguid;
    this.salariedFlag = salariedFlag;
    this.sickLeaveHour = sickLeaveHour;
    this.vacationHour = vacationHour;
  }

  toDisplay(): string {
    return String(this.loginID);
  }
}


/*<Codenesium>
    <Hash>ed79ed3ae0c0efb8ad86ce7cc29da081</Hash>
</Codenesium>*/