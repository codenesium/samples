export class AWBuildVersionClientRequestModel {
  database_Version: string;
  modifiedDate: any;
  systemInformationID: number;
  versionDate: any;

  constructor() {
    this.database_Version = '';
    this.modifiedDate = undefined;
    this.systemInformationID = 0;
    this.versionDate = undefined;
  }

  setProperties(
    database_Version: string,
    modifiedDate: any,
    systemInformationID: number,
    versionDate: any
  ): void {
    this.database_Version = database_Version;
    this.modifiedDate = modifiedDate;
    this.systemInformationID = systemInformationID;
    this.versionDate = versionDate;
  }
}

export class AWBuildVersionClientResponseModel {
  database_Version: string;
  modifiedDate: any;
  systemInformationID: number;
  versionDate: any;

  constructor() {
    this.database_Version = '';
    this.modifiedDate = undefined;
    this.systemInformationID = 0;
    this.versionDate = undefined;
  }

  setProperties(
    database_Version: string,
    modifiedDate: any,
    systemInformationID: number,
    versionDate: any
  ): void {
    this.database_Version = database_Version;
    this.modifiedDate = modifiedDate;
    this.systemInformationID = systemInformationID;
    this.versionDate = versionDate;
  }
}
export class DatabaseLogClientRequestModel {
  databaseLogID: number;
  databaseUser: string;
  reservedEvent: string;
  reservedObject: string;
  postTime: any;
  schema: string;
  tsql: string;
  xmlEvent: string;

  constructor() {
    this.databaseLogID = 0;
    this.databaseUser = '';
    this.reservedEvent = '';
    this.reservedObject = '';
    this.postTime = undefined;
    this.schema = '';
    this.tsql = '';
    this.xmlEvent = '';
  }

  setProperties(
    databaseLogID: number,
    databaseUser: string,
    reservedEvent: string,
    reservedObject: string,
    postTime: any,
    schema: string,
    tsql: string,
    xmlEvent: string
  ): void {
    this.databaseLogID = databaseLogID;
    this.databaseUser = databaseUser;
    this.reservedEvent = reservedEvent;
    this.reservedObject = reservedObject;
    this.postTime = postTime;
    this.schema = schema;
    this.tsql = tsql;
    this.xmlEvent = xmlEvent;
  }
}

export class DatabaseLogClientResponseModel {
  databaseLogID: number;
  databaseUser: string;
  reservedEvent: string;
  reservedObject: string;
  postTime: any;
  schema: string;
  tsql: string;
  xmlEvent: string;

  constructor() {
    this.databaseLogID = 0;
    this.databaseUser = '';
    this.reservedEvent = '';
    this.reservedObject = '';
    this.postTime = undefined;
    this.schema = '';
    this.tsql = '';
    this.xmlEvent = '';
  }

  setProperties(
    databaseLogID: number,
    databaseUser: string,
    reservedEvent: string,
    reservedObject: string,
    postTime: any,
    schema: string,
    tsql: string,
    xmlEvent: string
  ): void {
    this.databaseLogID = databaseLogID;
    this.databaseUser = databaseUser;
    this.reservedEvent = reservedEvent;
    this.reservedObject = reservedObject;
    this.postTime = postTime;
    this.schema = schema;
    this.tsql = tsql;
    this.xmlEvent = xmlEvent;
  }
}
export class ErrorLogClientRequestModel {
  errorLine: number;
  errorLogID: number;
  errorMessage: string;
  errorNumber: number;
  errorProcedure: string;
  errorSeverity: number;
  errorState: number;
  errorTime: any;
  userName: string;

  constructor() {
    this.errorLine = 0;
    this.errorLogID = 0;
    this.errorMessage = '';
    this.errorNumber = 0;
    this.errorProcedure = '';
    this.errorSeverity = 0;
    this.errorState = 0;
    this.errorTime = undefined;
    this.userName = '';
  }

  setProperties(
    errorLine: number,
    errorLogID: number,
    errorMessage: string,
    errorNumber: number,
    errorProcedure: string,
    errorSeverity: number,
    errorState: number,
    errorTime: any,
    userName: string
  ): void {
    this.errorLine = errorLine;
    this.errorLogID = errorLogID;
    this.errorMessage = errorMessage;
    this.errorNumber = errorNumber;
    this.errorProcedure = errorProcedure;
    this.errorSeverity = errorSeverity;
    this.errorState = errorState;
    this.errorTime = errorTime;
    this.userName = userName;
  }
}

export class ErrorLogClientResponseModel {
  errorLine: number;
  errorLogID: number;
  errorMessage: string;
  errorNumber: number;
  errorProcedure: string;
  errorSeverity: number;
  errorState: number;
  errorTime: any;
  userName: string;

  constructor() {
    this.errorLine = 0;
    this.errorLogID = 0;
    this.errorMessage = '';
    this.errorNumber = 0;
    this.errorProcedure = '';
    this.errorSeverity = 0;
    this.errorState = 0;
    this.errorTime = undefined;
    this.userName = '';
  }

  setProperties(
    errorLine: number,
    errorLogID: number,
    errorMessage: string,
    errorNumber: number,
    errorProcedure: string,
    errorSeverity: number,
    errorState: number,
    errorTime: any,
    userName: string
  ): void {
    this.errorLine = errorLine;
    this.errorLogID = errorLogID;
    this.errorMessage = errorMessage;
    this.errorNumber = errorNumber;
    this.errorProcedure = errorProcedure;
    this.errorSeverity = errorSeverity;
    this.errorState = errorState;
    this.errorTime = errorTime;
    this.userName = userName;
  }
}
export class DepartmentClientRequestModel {
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

export class DepartmentClientResponseModel {
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
export class EmployeeClientRequestModel {
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
}

export class EmployeeClientResponseModel {
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
}
export class JobCandidateClientRequestModel {
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: EmployeeClientResponseModel;
  jobCandidateID: number;
  modifiedDate: any;
  resume: string;

  constructor() {
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.jobCandidateID = 0;
    this.modifiedDate = undefined;
    this.resume = '';
  }

  setProperties(
    businessEntityID: number,
    jobCandidateID: number,
    modifiedDate: any,
    resume: string
  ): void {
    this.businessEntityID = businessEntityID;
    this.jobCandidateID = jobCandidateID;
    this.modifiedDate = modifiedDate;
    this.resume = resume;
  }
}

export class JobCandidateClientResponseModel {
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: EmployeeClientResponseModel;
  jobCandidateID: number;
  modifiedDate: any;
  resume: string;

  constructor() {
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.jobCandidateID = 0;
    this.modifiedDate = undefined;
    this.resume = '';
  }

  setProperties(
    businessEntityID: number,
    jobCandidateID: number,
    modifiedDate: any,
    resume: string
  ): void {
    this.businessEntityID = businessEntityID;
    this.jobCandidateID = jobCandidateID;
    this.modifiedDate = modifiedDate;
    this.resume = resume;
  }
}
export class ShiftClientRequestModel {
  endTime: any;
  modifiedDate: any;
  name: string;
  shiftID: number;
  startTime: any;

  constructor() {
    this.endTime = undefined;
    this.modifiedDate = undefined;
    this.name = '';
    this.shiftID = 0;
    this.startTime = undefined;
  }

  setProperties(
    endTime: any,
    modifiedDate: any,
    name: string,
    shiftID: number,
    startTime: any
  ): void {
    this.endTime = endTime;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.shiftID = shiftID;
    this.startTime = startTime;
  }
}

export class ShiftClientResponseModel {
  endTime: any;
  modifiedDate: any;
  name: string;
  shiftID: number;
  startTime: any;

  constructor() {
    this.endTime = undefined;
    this.modifiedDate = undefined;
    this.name = '';
    this.shiftID = 0;
    this.startTime = undefined;
  }

  setProperties(
    endTime: any,
    modifiedDate: any,
    name: string,
    shiftID: number,
    startTime: any
  ): void {
    this.endTime = endTime;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.shiftID = shiftID;
    this.startTime = startTime;
  }
}
export class AddressClientRequestModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  modifiedDate: any;
  postalCode: string;
  rowguid: any;
  stateProvinceID: number;
  stateProvinceIDEntity: string;
  stateProvinceIDNavigation?: StateProvinceClientResponseModel;

  constructor() {
    this.addressID = 0;
    this.addressLine1 = '';
    this.addressLine2 = '';
    this.city = '';
    this.modifiedDate = undefined;
    this.postalCode = '';
    this.rowguid = undefined;
    this.stateProvinceID = 0;
    this.stateProvinceIDEntity = '';
    this.stateProvinceIDNavigation = undefined;
  }

  setProperties(
    addressID: number,
    addressLine1: string,
    addressLine2: string,
    city: string,
    modifiedDate: any,
    postalCode: string,
    rowguid: any,
    stateProvinceID: number
  ): void {
    this.addressID = addressID;
    this.addressLine1 = addressLine1;
    this.addressLine2 = addressLine2;
    this.city = city;
    this.modifiedDate = modifiedDate;
    this.postalCode = postalCode;
    this.rowguid = rowguid;
    this.stateProvinceID = stateProvinceID;
  }
}

export class AddressClientResponseModel {
  addressID: number;
  addressLine1: string;
  addressLine2: string;
  city: string;
  modifiedDate: any;
  postalCode: string;
  rowguid: any;
  stateProvinceID: number;
  stateProvinceIDEntity: string;
  stateProvinceIDNavigation?: StateProvinceClientResponseModel;

  constructor() {
    this.addressID = 0;
    this.addressLine1 = '';
    this.addressLine2 = '';
    this.city = '';
    this.modifiedDate = undefined;
    this.postalCode = '';
    this.rowguid = undefined;
    this.stateProvinceID = 0;
    this.stateProvinceIDEntity = '';
    this.stateProvinceIDNavigation = undefined;
  }

  setProperties(
    addressID: number,
    addressLine1: string,
    addressLine2: string,
    city: string,
    modifiedDate: any,
    postalCode: string,
    rowguid: any,
    stateProvinceID: number
  ): void {
    this.addressID = addressID;
    this.addressLine1 = addressLine1;
    this.addressLine2 = addressLine2;
    this.city = city;
    this.modifiedDate = modifiedDate;
    this.postalCode = postalCode;
    this.rowguid = rowguid;
    this.stateProvinceID = stateProvinceID;
  }
}
export class AddressTypeClientRequestModel {
  addressTypeID: number;
  modifiedDate: any;
  name: string;
  rowguid: any;

  constructor() {
    this.addressTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
  }

  setProperties(
    addressTypeID: number,
    modifiedDate: any,
    name: string,
    rowguid: any
  ): void {
    this.addressTypeID = addressTypeID;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
  }
}

export class AddressTypeClientResponseModel {
  addressTypeID: number;
  modifiedDate: any;
  name: string;
  rowguid: any;

  constructor() {
    this.addressTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
  }

  setProperties(
    addressTypeID: number,
    modifiedDate: any,
    name: string,
    rowguid: any
  ): void {
    this.addressTypeID = addressTypeID;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
  }
}
export class BusinessEntityClientRequestModel {
  businessEntityID: number;
  modifiedDate: any;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    rowguid: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
  }
}

export class BusinessEntityClientResponseModel {
  businessEntityID: number;
  modifiedDate: any;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    rowguid: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
  }
}
export class ContactTypeClientRequestModel {
  contactTypeID: number;
  modifiedDate: any;
  name: string;

  constructor() {
    this.contactTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(contactTypeID: number, modifiedDate: any, name: string): void {
    this.contactTypeID = contactTypeID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}

export class ContactTypeClientResponseModel {
  contactTypeID: number;
  modifiedDate: any;
  name: string;

  constructor() {
    this.contactTypeID = 0;
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(contactTypeID: number, modifiedDate: any, name: string): void {
    this.contactTypeID = contactTypeID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}
export class CountryRegionClientRequestModel {
  countryRegionCode: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.countryRegionCode = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    countryRegionCode: string,
    modifiedDate: any,
    name: string
  ): void {
    this.countryRegionCode = countryRegionCode;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}

export class CountryRegionClientResponseModel {
  countryRegionCode: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.countryRegionCode = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    countryRegionCode: string,
    modifiedDate: any,
    name: string
  ): void {
    this.countryRegionCode = countryRegionCode;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}
export class PasswordClientRequestModel {
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: PersonClientResponseModel;
  modifiedDate: any;
  passwordHash: string;
  passwordSalt: string;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.modifiedDate = undefined;
    this.passwordHash = '';
    this.passwordSalt = '';
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    passwordHash: string,
    passwordSalt: string,
    rowguid: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.modifiedDate = modifiedDate;
    this.passwordHash = passwordHash;
    this.passwordSalt = passwordSalt;
    this.rowguid = rowguid;
  }
}

export class PasswordClientResponseModel {
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: PersonClientResponseModel;
  modifiedDate: any;
  passwordHash: string;
  passwordSalt: string;
  rowguid: any;

  constructor() {
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.modifiedDate = undefined;
    this.passwordHash = '';
    this.passwordSalt = '';
    this.rowguid = undefined;
  }

  setProperties(
    businessEntityID: number,
    modifiedDate: any,
    passwordHash: string,
    passwordSalt: string,
    rowguid: any
  ): void {
    this.businessEntityID = businessEntityID;
    this.modifiedDate = modifiedDate;
    this.passwordHash = passwordHash;
    this.passwordSalt = passwordSalt;
    this.rowguid = rowguid;
  }
}
export class PersonClientRequestModel {
  additionalContactInfo: string;
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: BusinessEntityClientResponseModel;
  demographic: string;
  emailPromotion: number;
  firstName: string;
  lastName: string;
  middleName: string;
  modifiedDate: any;
  nameStyle: boolean;
  personType: string;
  rowguid: any;
  suffix: string;
  title: string;

  constructor() {
    this.additionalContactInfo = '';
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.demographic = '';
    this.emailPromotion = 0;
    this.firstName = '';
    this.lastName = '';
    this.middleName = '';
    this.modifiedDate = undefined;
    this.nameStyle = false;
    this.personType = '';
    this.rowguid = undefined;
    this.suffix = '';
    this.title = '';
  }

  setProperties(
    additionalContactInfo: string,
    businessEntityID: number,
    demographic: string,
    emailPromotion: number,
    firstName: string,
    lastName: string,
    middleName: string,
    modifiedDate: any,
    nameStyle: boolean,
    personType: string,
    rowguid: any,
    suffix: string,
    title: string
  ): void {
    this.additionalContactInfo = additionalContactInfo;
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.emailPromotion = emailPromotion;
    this.firstName = firstName;
    this.lastName = lastName;
    this.middleName = middleName;
    this.modifiedDate = modifiedDate;
    this.nameStyle = nameStyle;
    this.personType = personType;
    this.rowguid = rowguid;
    this.suffix = suffix;
    this.title = title;
  }
}

export class PersonClientResponseModel {
  additionalContactInfo: string;
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: BusinessEntityClientResponseModel;
  demographic: string;
  emailPromotion: number;
  firstName: string;
  lastName: string;
  middleName: string;
  modifiedDate: any;
  nameStyle: boolean;
  personType: string;
  rowguid: any;
  suffix: string;
  title: string;

  constructor() {
    this.additionalContactInfo = '';
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.demographic = '';
    this.emailPromotion = 0;
    this.firstName = '';
    this.lastName = '';
    this.middleName = '';
    this.modifiedDate = undefined;
    this.nameStyle = false;
    this.personType = '';
    this.rowguid = undefined;
    this.suffix = '';
    this.title = '';
  }

  setProperties(
    additionalContactInfo: string,
    businessEntityID: number,
    demographic: string,
    emailPromotion: number,
    firstName: string,
    lastName: string,
    middleName: string,
    modifiedDate: any,
    nameStyle: boolean,
    personType: string,
    rowguid: any,
    suffix: string,
    title: string
  ): void {
    this.additionalContactInfo = additionalContactInfo;
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.emailPromotion = emailPromotion;
    this.firstName = firstName;
    this.lastName = lastName;
    this.middleName = middleName;
    this.modifiedDate = modifiedDate;
    this.nameStyle = nameStyle;
    this.personType = personType;
    this.rowguid = rowguid;
    this.suffix = suffix;
    this.title = title;
  }
}
export class PhoneNumberTypeClientRequestModel {
  modifiedDate: any;
  name: string;
  phoneNumberTypeID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.phoneNumberTypeID = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    phoneNumberTypeID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.phoneNumberTypeID = phoneNumberTypeID;
  }
}

export class PhoneNumberTypeClientResponseModel {
  modifiedDate: any;
  name: string;
  phoneNumberTypeID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.phoneNumberTypeID = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    phoneNumberTypeID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.phoneNumberTypeID = phoneNumberTypeID;
  }
}
export class StateProvinceClientRequestModel {
  countryRegionCode: string;
  countryRegionCodeEntity: string;
  countryRegionCodeNavigation?: CountryRegionClientResponseModel;
  isOnlyStateProvinceFlag: boolean;
  modifiedDate: any;
  name: string;
  rowguid: any;
  stateProvinceCode: string;
  stateProvinceID: number;
  territoryID: number;

  constructor() {
    this.countryRegionCode = '';
    this.countryRegionCodeEntity = '';
    this.countryRegionCodeNavigation = undefined;
    this.isOnlyStateProvinceFlag = false;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.stateProvinceCode = '';
    this.stateProvinceID = 0;
    this.territoryID = 0;
  }

  setProperties(
    countryRegionCode: string,
    isOnlyStateProvinceFlag: boolean,
    modifiedDate: any,
    name: string,
    rowguid: any,
    stateProvinceCode: string,
    stateProvinceID: number,
    territoryID: number
  ): void {
    this.countryRegionCode = countryRegionCode;
    this.isOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.stateProvinceCode = stateProvinceCode;
    this.stateProvinceID = stateProvinceID;
    this.territoryID = territoryID;
  }
}

export class StateProvinceClientResponseModel {
  countryRegionCode: string;
  countryRegionCodeEntity: string;
  countryRegionCodeNavigation?: CountryRegionClientResponseModel;
  isOnlyStateProvinceFlag: boolean;
  modifiedDate: any;
  name: string;
  rowguid: any;
  stateProvinceCode: string;
  stateProvinceID: number;
  territoryID: number;

  constructor() {
    this.countryRegionCode = '';
    this.countryRegionCodeEntity = '';
    this.countryRegionCodeNavigation = undefined;
    this.isOnlyStateProvinceFlag = false;
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.stateProvinceCode = '';
    this.stateProvinceID = 0;
    this.territoryID = 0;
  }

  setProperties(
    countryRegionCode: string,
    isOnlyStateProvinceFlag: boolean,
    modifiedDate: any,
    name: string,
    rowguid: any,
    stateProvinceCode: string,
    stateProvinceID: number,
    territoryID: number
  ): void {
    this.countryRegionCode = countryRegionCode;
    this.isOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.stateProvinceCode = stateProvinceCode;
    this.stateProvinceID = stateProvinceID;
    this.territoryID = territoryID;
  }
}
export class BillOfMaterialClientRequestModel {
  billOfMaterialsID: number;
  bOMLevel: number;
  componentID: number;
  componentIDEntity: string;
  componentIDNavigation?: ProductClientResponseModel;
  endDate: any;
  modifiedDate: any;
  perAssemblyQty: number;
  productAssemblyID: number;
  productAssemblyIDEntity: string;
  productAssemblyIDNavigation?: ProductClientResponseModel;
  startDate: any;
  unitMeasureCode: string;
  unitMeasureCodeEntity: string;
  unitMeasureCodeNavigation?: UnitMeasureClientResponseModel;

  constructor() {
    this.billOfMaterialsID = 0;
    this.bOMLevel = 0;
    this.componentID = 0;
    this.componentIDEntity = '';
    this.componentIDNavigation = undefined;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.perAssemblyQty = 0;
    this.productAssemblyID = 0;
    this.productAssemblyIDEntity = '';
    this.productAssemblyIDNavigation = undefined;
    this.startDate = undefined;
    this.unitMeasureCode = '';
    this.unitMeasureCodeEntity = '';
    this.unitMeasureCodeNavigation = undefined;
  }

  setProperties(
    billOfMaterialsID: number,
    bOMLevel: number,
    componentID: number,
    endDate: any,
    modifiedDate: any,
    perAssemblyQty: number,
    productAssemblyID: number,
    startDate: any,
    unitMeasureCode: string
  ): void {
    this.billOfMaterialsID = billOfMaterialsID;
    this.bOMLevel = bOMLevel;
    this.componentID = componentID;
    this.endDate = endDate;
    this.modifiedDate = modifiedDate;
    this.perAssemblyQty = perAssemblyQty;
    this.productAssemblyID = productAssemblyID;
    this.startDate = startDate;
    this.unitMeasureCode = unitMeasureCode;
  }
}

export class BillOfMaterialClientResponseModel {
  billOfMaterialsID: number;
  bOMLevel: number;
  componentID: number;
  componentIDEntity: string;
  componentIDNavigation?: ProductClientResponseModel;
  endDate: any;
  modifiedDate: any;
  perAssemblyQty: number;
  productAssemblyID: number;
  productAssemblyIDEntity: string;
  productAssemblyIDNavigation?: ProductClientResponseModel;
  startDate: any;
  unitMeasureCode: string;
  unitMeasureCodeEntity: string;
  unitMeasureCodeNavigation?: UnitMeasureClientResponseModel;

  constructor() {
    this.billOfMaterialsID = 0;
    this.bOMLevel = 0;
    this.componentID = 0;
    this.componentIDEntity = '';
    this.componentIDNavigation = undefined;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.perAssemblyQty = 0;
    this.productAssemblyID = 0;
    this.productAssemblyIDEntity = '';
    this.productAssemblyIDNavigation = undefined;
    this.startDate = undefined;
    this.unitMeasureCode = '';
    this.unitMeasureCodeEntity = '';
    this.unitMeasureCodeNavigation = undefined;
  }

  setProperties(
    billOfMaterialsID: number,
    bOMLevel: number,
    componentID: number,
    endDate: any,
    modifiedDate: any,
    perAssemblyQty: number,
    productAssemblyID: number,
    startDate: any,
    unitMeasureCode: string
  ): void {
    this.billOfMaterialsID = billOfMaterialsID;
    this.bOMLevel = bOMLevel;
    this.componentID = componentID;
    this.endDate = endDate;
    this.modifiedDate = modifiedDate;
    this.perAssemblyQty = perAssemblyQty;
    this.productAssemblyID = productAssemblyID;
    this.startDate = startDate;
    this.unitMeasureCode = unitMeasureCode;
  }
}
export class CultureClientRequestModel {
  cultureID: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.cultureID = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(cultureID: string, modifiedDate: any, name: string): void {
    this.cultureID = cultureID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}

export class CultureClientResponseModel {
  cultureID: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.cultureID = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(cultureID: string, modifiedDate: any, name: string): void {
    this.cultureID = cultureID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}
export class DocumentClientRequestModel {
  changeNumber: number;
  document1: any;
  documentLevel: number;
  documentSummary: string;
  fileExtension: string;
  fileName: string;
  folderFlag: boolean;
  modifiedDate: any;
  owner: number;
  revision: string;
  rowguid: any;
  status: number;
  title: string;

  constructor() {
    this.changeNumber = 0;
    this.document1 = undefined;
    this.documentLevel = 0;
    this.documentSummary = '';
    this.fileExtension = '';
    this.fileName = '';
    this.folderFlag = false;
    this.modifiedDate = undefined;
    this.owner = 0;
    this.revision = '';
    this.rowguid = undefined;
    this.status = 0;
    this.title = '';
  }

  setProperties(
    changeNumber: number,
    document1: any,
    documentLevel: number,
    documentSummary: string,
    fileExtension: string,
    fileName: string,
    folderFlag: boolean,
    modifiedDate: any,
    owner: number,
    revision: string,
    rowguid: any,
    status: number,
    title: string
  ): void {
    this.changeNumber = changeNumber;
    this.document1 = document1;
    this.documentLevel = documentLevel;
    this.documentSummary = documentSummary;
    this.fileExtension = fileExtension;
    this.fileName = fileName;
    this.folderFlag = folderFlag;
    this.modifiedDate = modifiedDate;
    this.owner = owner;
    this.revision = revision;
    this.rowguid = rowguid;
    this.status = status;
    this.title = title;
  }
}

export class DocumentClientResponseModel {
  changeNumber: number;
  document1: any;
  documentLevel: number;
  documentSummary: string;
  fileExtension: string;
  fileName: string;
  folderFlag: boolean;
  modifiedDate: any;
  owner: number;
  revision: string;
  rowguid: any;
  status: number;
  title: string;

  constructor() {
    this.changeNumber = 0;
    this.document1 = undefined;
    this.documentLevel = 0;
    this.documentSummary = '';
    this.fileExtension = '';
    this.fileName = '';
    this.folderFlag = false;
    this.modifiedDate = undefined;
    this.owner = 0;
    this.revision = '';
    this.rowguid = undefined;
    this.status = 0;
    this.title = '';
  }

  setProperties(
    changeNumber: number,
    document1: any,
    documentLevel: number,
    documentSummary: string,
    fileExtension: string,
    fileName: string,
    folderFlag: boolean,
    modifiedDate: any,
    owner: number,
    revision: string,
    rowguid: any,
    status: number,
    title: string
  ): void {
    this.changeNumber = changeNumber;
    this.document1 = document1;
    this.documentLevel = documentLevel;
    this.documentSummary = documentSummary;
    this.fileExtension = fileExtension;
    this.fileName = fileName;
    this.folderFlag = folderFlag;
    this.modifiedDate = modifiedDate;
    this.owner = owner;
    this.revision = revision;
    this.rowguid = rowguid;
    this.status = status;
    this.title = title;
  }
}
export class IllustrationClientRequestModel {
  diagram: string;
  illustrationID: number;
  modifiedDate: any;

  constructor() {
    this.diagram = '';
    this.illustrationID = 0;
    this.modifiedDate = undefined;
  }

  setProperties(
    diagram: string,
    illustrationID: number,
    modifiedDate: any
  ): void {
    this.diagram = diagram;
    this.illustrationID = illustrationID;
    this.modifiedDate = modifiedDate;
  }
}

export class IllustrationClientResponseModel {
  diagram: string;
  illustrationID: number;
  modifiedDate: any;

  constructor() {
    this.diagram = '';
    this.illustrationID = 0;
    this.modifiedDate = undefined;
  }

  setProperties(
    diagram: string,
    illustrationID: number,
    modifiedDate: any
  ): void {
    this.diagram = diagram;
    this.illustrationID = illustrationID;
    this.modifiedDate = modifiedDate;
  }
}
export class LocationClientRequestModel {
  availability: number;
  costRate: number;
  locationID: number;
  modifiedDate: any;
  name: string;

  constructor() {
    this.availability = 0;
    this.costRate = 0;
    this.locationID = 0;
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    availability: number,
    costRate: number,
    locationID: number,
    modifiedDate: any,
    name: string
  ): void {
    this.availability = availability;
    this.costRate = costRate;
    this.locationID = locationID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}

export class LocationClientResponseModel {
  availability: number;
  costRate: number;
  locationID: number;
  modifiedDate: any;
  name: string;

  constructor() {
    this.availability = 0;
    this.costRate = 0;
    this.locationID = 0;
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(
    availability: number,
    costRate: number,
    locationID: number,
    modifiedDate: any,
    name: string
  ): void {
    this.availability = availability;
    this.costRate = costRate;
    this.locationID = locationID;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}
export class ProductClientRequestModel {
  reservedClass: string;
  color: string;
  daysToManufacture: number;
  discontinuedDate: any;
  finishedGoodsFlag: boolean;
  listPrice: number;
  makeFlag: boolean;
  modifiedDate: any;
  name: string;
  productID: number;
  productLine: string;
  productModelID: number;
  productModelIDEntity: string;
  productModelIDNavigation?: ProductModelClientResponseModel;
  productNumber: string;
  productSubcategoryID: number;
  productSubcategoryIDEntity: string;
  productSubcategoryIDNavigation?: ProductSubcategoryClientResponseModel;
  reorderPoint: number;
  rowguid: any;
  safetyStockLevel: number;
  sellEndDate: any;
  sellStartDate: any;
  size: string;
  sizeUnitMeasureCode: string;
  sizeUnitMeasureCodeEntity: string;
  sizeUnitMeasureCodeNavigation?: UnitMeasureClientResponseModel;
  standardCost: number;
  style: string;
  weight: number;
  weightUnitMeasureCode: string;
  weightUnitMeasureCodeEntity: string;
  weightUnitMeasureCodeNavigation?: UnitMeasureClientResponseModel;

  constructor() {
    this.reservedClass = '';
    this.color = '';
    this.daysToManufacture = 0;
    this.discontinuedDate = undefined;
    this.finishedGoodsFlag = false;
    this.listPrice = 0;
    this.makeFlag = false;
    this.modifiedDate = undefined;
    this.name = '';
    this.productID = 0;
    this.productLine = '';
    this.productModelID = 0;
    this.productModelIDEntity = '';
    this.productModelIDNavigation = undefined;
    this.productNumber = '';
    this.productSubcategoryID = 0;
    this.productSubcategoryIDEntity = '';
    this.productSubcategoryIDNavigation = undefined;
    this.reorderPoint = 0;
    this.rowguid = undefined;
    this.safetyStockLevel = 0;
    this.sellEndDate = undefined;
    this.sellStartDate = undefined;
    this.size = '';
    this.sizeUnitMeasureCode = '';
    this.sizeUnitMeasureCodeEntity = '';
    this.sizeUnitMeasureCodeNavigation = undefined;
    this.standardCost = 0;
    this.style = '';
    this.weight = 0;
    this.weightUnitMeasureCode = '';
    this.weightUnitMeasureCodeEntity = '';
    this.weightUnitMeasureCodeNavigation = undefined;
  }

  setProperties(
    reservedClass: string,
    color: string,
    daysToManufacture: number,
    discontinuedDate: any,
    finishedGoodsFlag: boolean,
    listPrice: number,
    makeFlag: boolean,
    modifiedDate: any,
    name: string,
    productID: number,
    productLine: string,
    productModelID: number,
    productNumber: string,
    productSubcategoryID: number,
    reorderPoint: number,
    rowguid: any,
    safetyStockLevel: number,
    sellEndDate: any,
    sellStartDate: any,
    size: string,
    sizeUnitMeasureCode: string,
    standardCost: number,
    style: string,
    weight: number,
    weightUnitMeasureCode: string
  ): void {
    this.reservedClass = reservedClass;
    this.color = color;
    this.daysToManufacture = daysToManufacture;
    this.discontinuedDate = discontinuedDate;
    this.finishedGoodsFlag = finishedGoodsFlag;
    this.listPrice = listPrice;
    this.makeFlag = makeFlag;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productID = productID;
    this.productLine = productLine;
    this.productModelID = productModelID;
    this.productNumber = productNumber;
    this.productSubcategoryID = productSubcategoryID;
    this.reorderPoint = reorderPoint;
    this.rowguid = rowguid;
    this.safetyStockLevel = safetyStockLevel;
    this.sellEndDate = sellEndDate;
    this.sellStartDate = sellStartDate;
    this.size = size;
    this.sizeUnitMeasureCode = sizeUnitMeasureCode;
    this.standardCost = standardCost;
    this.style = style;
    this.weight = weight;
    this.weightUnitMeasureCode = weightUnitMeasureCode;
  }
}

export class ProductClientResponseModel {
  reservedClass: string;
  color: string;
  daysToManufacture: number;
  discontinuedDate: any;
  finishedGoodsFlag: boolean;
  listPrice: number;
  makeFlag: boolean;
  modifiedDate: any;
  name: string;
  productID: number;
  productLine: string;
  productModelID: number;
  productModelIDEntity: string;
  productModelIDNavigation?: ProductModelClientResponseModel;
  productNumber: string;
  productSubcategoryID: number;
  productSubcategoryIDEntity: string;
  productSubcategoryIDNavigation?: ProductSubcategoryClientResponseModel;
  reorderPoint: number;
  rowguid: any;
  safetyStockLevel: number;
  sellEndDate: any;
  sellStartDate: any;
  size: string;
  sizeUnitMeasureCode: string;
  sizeUnitMeasureCodeEntity: string;
  sizeUnitMeasureCodeNavigation?: UnitMeasureClientResponseModel;
  standardCost: number;
  style: string;
  weight: number;
  weightUnitMeasureCode: string;
  weightUnitMeasureCodeEntity: string;
  weightUnitMeasureCodeNavigation?: UnitMeasureClientResponseModel;

  constructor() {
    this.reservedClass = '';
    this.color = '';
    this.daysToManufacture = 0;
    this.discontinuedDate = undefined;
    this.finishedGoodsFlag = false;
    this.listPrice = 0;
    this.makeFlag = false;
    this.modifiedDate = undefined;
    this.name = '';
    this.productID = 0;
    this.productLine = '';
    this.productModelID = 0;
    this.productModelIDEntity = '';
    this.productModelIDNavigation = undefined;
    this.productNumber = '';
    this.productSubcategoryID = 0;
    this.productSubcategoryIDEntity = '';
    this.productSubcategoryIDNavigation = undefined;
    this.reorderPoint = 0;
    this.rowguid = undefined;
    this.safetyStockLevel = 0;
    this.sellEndDate = undefined;
    this.sellStartDate = undefined;
    this.size = '';
    this.sizeUnitMeasureCode = '';
    this.sizeUnitMeasureCodeEntity = '';
    this.sizeUnitMeasureCodeNavigation = undefined;
    this.standardCost = 0;
    this.style = '';
    this.weight = 0;
    this.weightUnitMeasureCode = '';
    this.weightUnitMeasureCodeEntity = '';
    this.weightUnitMeasureCodeNavigation = undefined;
  }

  setProperties(
    reservedClass: string,
    color: string,
    daysToManufacture: number,
    discontinuedDate: any,
    finishedGoodsFlag: boolean,
    listPrice: number,
    makeFlag: boolean,
    modifiedDate: any,
    name: string,
    productID: number,
    productLine: string,
    productModelID: number,
    productNumber: string,
    productSubcategoryID: number,
    reorderPoint: number,
    rowguid: any,
    safetyStockLevel: number,
    sellEndDate: any,
    sellStartDate: any,
    size: string,
    sizeUnitMeasureCode: string,
    standardCost: number,
    style: string,
    weight: number,
    weightUnitMeasureCode: string
  ): void {
    this.reservedClass = reservedClass;
    this.color = color;
    this.daysToManufacture = daysToManufacture;
    this.discontinuedDate = discontinuedDate;
    this.finishedGoodsFlag = finishedGoodsFlag;
    this.listPrice = listPrice;
    this.makeFlag = makeFlag;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productID = productID;
    this.productLine = productLine;
    this.productModelID = productModelID;
    this.productNumber = productNumber;
    this.productSubcategoryID = productSubcategoryID;
    this.reorderPoint = reorderPoint;
    this.rowguid = rowguid;
    this.safetyStockLevel = safetyStockLevel;
    this.sellEndDate = sellEndDate;
    this.sellStartDate = sellStartDate;
    this.size = size;
    this.sizeUnitMeasureCode = sizeUnitMeasureCode;
    this.standardCost = standardCost;
    this.style = style;
    this.weight = weight;
    this.weightUnitMeasureCode = weightUnitMeasureCode;
  }
}
export class ProductCategoryClientRequestModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.rowguid = rowguid;
  }
}

export class ProductCategoryClientResponseModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.rowguid = rowguid;
  }
}
export class ProductDescriptionClientRequestModel {
  description: string;
  modifiedDate: any;
  productDescriptionID: number;
  rowguid: any;

  constructor() {
    this.description = '';
    this.modifiedDate = undefined;
    this.productDescriptionID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    description: string,
    modifiedDate: any,
    productDescriptionID: number,
    rowguid: any
  ): void {
    this.description = description;
    this.modifiedDate = modifiedDate;
    this.productDescriptionID = productDescriptionID;
    this.rowguid = rowguid;
  }
}

export class ProductDescriptionClientResponseModel {
  description: string;
  modifiedDate: any;
  productDescriptionID: number;
  rowguid: any;

  constructor() {
    this.description = '';
    this.modifiedDate = undefined;
    this.productDescriptionID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    description: string,
    modifiedDate: any,
    productDescriptionID: number,
    rowguid: any
  ): void {
    this.description = description;
    this.modifiedDate = modifiedDate;
    this.productDescriptionID = productDescriptionID;
    this.rowguid = rowguid;
  }
}
export class ProductModelClientRequestModel {
  catalogDescription: string;
  instruction: string;
  modifiedDate: any;
  name: string;
  productModelID: number;
  rowguid: any;

  constructor() {
    this.catalogDescription = '';
    this.instruction = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.productModelID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    catalogDescription: string,
    instruction: string,
    modifiedDate: any,
    name: string,
    productModelID: number,
    rowguid: any
  ): void {
    this.catalogDescription = catalogDescription;
    this.instruction = instruction;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productModelID = productModelID;
    this.rowguid = rowguid;
  }
}

export class ProductModelClientResponseModel {
  catalogDescription: string;
  instruction: string;
  modifiedDate: any;
  name: string;
  productModelID: number;
  rowguid: any;

  constructor() {
    this.catalogDescription = '';
    this.instruction = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.productModelID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    catalogDescription: string,
    instruction: string,
    modifiedDate: any,
    name: string,
    productModelID: number,
    rowguid: any
  ): void {
    this.catalogDescription = catalogDescription;
    this.instruction = instruction;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productModelID = productModelID;
    this.rowguid = rowguid;
  }
}
export class ProductPhotoClientRequestModel {
  largePhoto: any;
  largePhotoFileName: string;
  modifiedDate: any;
  productPhotoID: number;
  thumbNailPhoto: any;
  thumbnailPhotoFileName: string;

  constructor() {
    this.largePhoto = undefined;
    this.largePhotoFileName = '';
    this.modifiedDate = undefined;
    this.productPhotoID = 0;
    this.thumbNailPhoto = undefined;
    this.thumbnailPhotoFileName = '';
  }

  setProperties(
    largePhoto: any,
    largePhotoFileName: string,
    modifiedDate: any,
    productPhotoID: number,
    thumbNailPhoto: any,
    thumbnailPhotoFileName: string
  ): void {
    this.largePhoto = largePhoto;
    this.largePhotoFileName = largePhotoFileName;
    this.modifiedDate = modifiedDate;
    this.productPhotoID = productPhotoID;
    this.thumbNailPhoto = thumbNailPhoto;
    this.thumbnailPhotoFileName = thumbnailPhotoFileName;
  }
}

export class ProductPhotoClientResponseModel {
  largePhoto: any;
  largePhotoFileName: string;
  modifiedDate: any;
  productPhotoID: number;
  thumbNailPhoto: any;
  thumbnailPhotoFileName: string;

  constructor() {
    this.largePhoto = undefined;
    this.largePhotoFileName = '';
    this.modifiedDate = undefined;
    this.productPhotoID = 0;
    this.thumbNailPhoto = undefined;
    this.thumbnailPhotoFileName = '';
  }

  setProperties(
    largePhoto: any,
    largePhotoFileName: string,
    modifiedDate: any,
    productPhotoID: number,
    thumbNailPhoto: any,
    thumbnailPhotoFileName: string
  ): void {
    this.largePhoto = largePhoto;
    this.largePhotoFileName = largePhotoFileName;
    this.modifiedDate = modifiedDate;
    this.productPhotoID = productPhotoID;
    this.thumbNailPhoto = thumbNailPhoto;
    this.thumbnailPhotoFileName = thumbnailPhotoFileName;
  }
}
export class ProductProductPhotoClientRequestModel {
  modifiedDate: any;
  primary: boolean;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  productPhotoID: number;
  productPhotoIDEntity: string;
  productPhotoIDNavigation?: ProductPhotoClientResponseModel;

  constructor() {
    this.modifiedDate = undefined;
    this.primary = false;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.productPhotoID = 0;
    this.productPhotoIDEntity = '';
    this.productPhotoIDNavigation = undefined;
  }

  setProperties(
    modifiedDate: any,
    primary: boolean,
    productID: number,
    productPhotoID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.primary = primary;
    this.productID = productID;
    this.productPhotoID = productPhotoID;
  }
}

export class ProductProductPhotoClientResponseModel {
  modifiedDate: any;
  primary: boolean;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  productPhotoID: number;
  productPhotoIDEntity: string;
  productPhotoIDNavigation?: ProductPhotoClientResponseModel;

  constructor() {
    this.modifiedDate = undefined;
    this.primary = false;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.productPhotoID = 0;
    this.productPhotoIDEntity = '';
    this.productPhotoIDNavigation = undefined;
  }

  setProperties(
    modifiedDate: any,
    primary: boolean,
    productID: number,
    productPhotoID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.primary = primary;
    this.productID = productID;
    this.productPhotoID = productPhotoID;
  }
}
export class ProductReviewClientRequestModel {
  comment: string;
  emailAddress: string;
  modifiedDate: any;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  productReviewID: number;
  rating: number;
  reviewDate: any;
  reviewerName: string;

  constructor() {
    this.comment = '';
    this.emailAddress = '';
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.productReviewID = 0;
    this.rating = 0;
    this.reviewDate = undefined;
    this.reviewerName = '';
  }

  setProperties(
    comment: string,
    emailAddress: string,
    modifiedDate: any,
    productID: number,
    productReviewID: number,
    rating: number,
    reviewDate: any,
    reviewerName: string
  ): void {
    this.comment = comment;
    this.emailAddress = emailAddress;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.productReviewID = productReviewID;
    this.rating = rating;
    this.reviewDate = reviewDate;
    this.reviewerName = reviewerName;
  }
}

export class ProductReviewClientResponseModel {
  comment: string;
  emailAddress: string;
  modifiedDate: any;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  productReviewID: number;
  rating: number;
  reviewDate: any;
  reviewerName: string;

  constructor() {
    this.comment = '';
    this.emailAddress = '';
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.productReviewID = 0;
    this.rating = 0;
    this.reviewDate = undefined;
    this.reviewerName = '';
  }

  setProperties(
    comment: string,
    emailAddress: string,
    modifiedDate: any,
    productID: number,
    productReviewID: number,
    rating: number,
    reviewDate: any,
    reviewerName: string
  ): void {
    this.comment = comment;
    this.emailAddress = emailAddress;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.productReviewID = productReviewID;
    this.rating = rating;
    this.reviewDate = reviewDate;
    this.reviewerName = reviewerName;
  }
}
export class ProductSubcategoryClientRequestModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  productCategoryIDEntity: string;
  productCategoryIDNavigation?: ProductCategoryClientResponseModel;
  productSubcategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.productCategoryIDEntity = '';
    this.productCategoryIDNavigation = undefined;
    this.productSubcategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    productSubcategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.productSubcategoryID = productSubcategoryID;
    this.rowguid = rowguid;
  }
}

export class ProductSubcategoryClientResponseModel {
  modifiedDate: any;
  name: string;
  productCategoryID: number;
  productCategoryIDEntity: string;
  productCategoryIDNavigation?: ProductCategoryClientResponseModel;
  productSubcategoryID: number;
  rowguid: any;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.productCategoryID = 0;
    this.productCategoryIDEntity = '';
    this.productCategoryIDNavigation = undefined;
    this.productSubcategoryID = 0;
    this.rowguid = undefined;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    productCategoryID: number,
    productSubcategoryID: number,
    rowguid: any
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productCategoryID = productCategoryID;
    this.productSubcategoryID = productSubcategoryID;
    this.rowguid = rowguid;
  }
}
export class ScrapReasonClientRequestModel {
  modifiedDate: any;
  name: string;
  scrapReasonID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.scrapReasonID = 0;
  }

  setProperties(modifiedDate: any, name: string, scrapReasonID: number): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.scrapReasonID = scrapReasonID;
  }
}

export class ScrapReasonClientResponseModel {
  modifiedDate: any;
  name: string;
  scrapReasonID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.scrapReasonID = 0;
  }

  setProperties(modifiedDate: any, name: string, scrapReasonID: number): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.scrapReasonID = scrapReasonID;
  }
}
export class TransactionHistoryClientRequestModel {
  actualCost: number;
  modifiedDate: any;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  quantity: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: any;
  transactionID: number;
  transactionType: string;

  constructor() {
    this.actualCost = 0;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.quantity = 0;
    this.referenceOrderID = 0;
    this.referenceOrderLineID = 0;
    this.transactionDate = undefined;
    this.transactionID = 0;
    this.transactionType = '';
  }

  setProperties(
    actualCost: number,
    modifiedDate: any,
    productID: number,
    quantity: number,
    referenceOrderID: number,
    referenceOrderLineID: number,
    transactionDate: any,
    transactionID: number,
    transactionType: string
  ): void {
    this.actualCost = actualCost;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.referenceOrderID = referenceOrderID;
    this.referenceOrderLineID = referenceOrderLineID;
    this.transactionDate = transactionDate;
    this.transactionID = transactionID;
    this.transactionType = transactionType;
  }
}

export class TransactionHistoryClientResponseModel {
  actualCost: number;
  modifiedDate: any;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  quantity: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: any;
  transactionID: number;
  transactionType: string;

  constructor() {
    this.actualCost = 0;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.quantity = 0;
    this.referenceOrderID = 0;
    this.referenceOrderLineID = 0;
    this.transactionDate = undefined;
    this.transactionID = 0;
    this.transactionType = '';
  }

  setProperties(
    actualCost: number,
    modifiedDate: any,
    productID: number,
    quantity: number,
    referenceOrderID: number,
    referenceOrderLineID: number,
    transactionDate: any,
    transactionID: number,
    transactionType: string
  ): void {
    this.actualCost = actualCost;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.referenceOrderID = referenceOrderID;
    this.referenceOrderLineID = referenceOrderLineID;
    this.transactionDate = transactionDate;
    this.transactionID = transactionID;
    this.transactionType = transactionType;
  }
}
export class TransactionHistoryArchiveClientRequestModel {
  actualCost: number;
  modifiedDate: any;
  productID: number;
  quantity: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: any;
  transactionID: number;
  transactionType: string;

  constructor() {
    this.actualCost = 0;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.quantity = 0;
    this.referenceOrderID = 0;
    this.referenceOrderLineID = 0;
    this.transactionDate = undefined;
    this.transactionID = 0;
    this.transactionType = '';
  }

  setProperties(
    actualCost: number,
    modifiedDate: any,
    productID: number,
    quantity: number,
    referenceOrderID: number,
    referenceOrderLineID: number,
    transactionDate: any,
    transactionID: number,
    transactionType: string
  ): void {
    this.actualCost = actualCost;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.referenceOrderID = referenceOrderID;
    this.referenceOrderLineID = referenceOrderLineID;
    this.transactionDate = transactionDate;
    this.transactionID = transactionID;
    this.transactionType = transactionType;
  }
}

export class TransactionHistoryArchiveClientResponseModel {
  actualCost: number;
  modifiedDate: any;
  productID: number;
  quantity: number;
  referenceOrderID: number;
  referenceOrderLineID: number;
  transactionDate: any;
  transactionID: number;
  transactionType: string;

  constructor() {
    this.actualCost = 0;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.quantity = 0;
    this.referenceOrderID = 0;
    this.referenceOrderLineID = 0;
    this.transactionDate = undefined;
    this.transactionID = 0;
    this.transactionType = '';
  }

  setProperties(
    actualCost: number,
    modifiedDate: any,
    productID: number,
    quantity: number,
    referenceOrderID: number,
    referenceOrderLineID: number,
    transactionDate: any,
    transactionID: number,
    transactionType: string
  ): void {
    this.actualCost = actualCost;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.referenceOrderID = referenceOrderID;
    this.referenceOrderLineID = referenceOrderLineID;
    this.transactionDate = transactionDate;
    this.transactionID = transactionID;
    this.transactionType = transactionType;
  }
}
export class UnitMeasureClientRequestModel {
  modifiedDate: any;
  name: string;
  unitMeasureCode: string;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.unitMeasureCode = '';
  }

  setProperties(
    modifiedDate: any,
    name: string,
    unitMeasureCode: string
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.unitMeasureCode = unitMeasureCode;
  }
}

export class UnitMeasureClientResponseModel {
  modifiedDate: any;
  name: string;
  unitMeasureCode: string;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.unitMeasureCode = '';
  }

  setProperties(
    modifiedDate: any,
    name: string,
    unitMeasureCode: string
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.unitMeasureCode = unitMeasureCode;
  }
}
export class WorkOrderClientRequestModel {
  dueDate: any;
  endDate: any;
  modifiedDate: any;
  orderQty: number;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  scrappedQty: number;
  scrapReasonID: number;
  scrapReasonIDEntity: string;
  scrapReasonIDNavigation?: ScrapReasonClientResponseModel;
  startDate: any;
  stockedQty: number;
  workOrderID: number;

  constructor() {
    this.dueDate = undefined;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.orderQty = 0;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.scrappedQty = 0;
    this.scrapReasonID = 0;
    this.scrapReasonIDEntity = '';
    this.scrapReasonIDNavigation = undefined;
    this.startDate = undefined;
    this.stockedQty = 0;
    this.workOrderID = 0;
  }

  setProperties(
    dueDate: any,
    endDate: any,
    modifiedDate: any,
    orderQty: number,
    productID: number,
    scrappedQty: number,
    scrapReasonID: number,
    startDate: any,
    stockedQty: number,
    workOrderID: number
  ): void {
    this.dueDate = dueDate;
    this.endDate = endDate;
    this.modifiedDate = modifiedDate;
    this.orderQty = orderQty;
    this.productID = productID;
    this.scrappedQty = scrappedQty;
    this.scrapReasonID = scrapReasonID;
    this.startDate = startDate;
    this.stockedQty = stockedQty;
    this.workOrderID = workOrderID;
  }
}

export class WorkOrderClientResponseModel {
  dueDate: any;
  endDate: any;
  modifiedDate: any;
  orderQty: number;
  productID: number;
  productIDEntity: string;
  productIDNavigation?: ProductClientResponseModel;
  scrappedQty: number;
  scrapReasonID: number;
  scrapReasonIDEntity: string;
  scrapReasonIDNavigation?: ScrapReasonClientResponseModel;
  startDate: any;
  stockedQty: number;
  workOrderID: number;

  constructor() {
    this.dueDate = undefined;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.orderQty = 0;
    this.productID = 0;
    this.productIDEntity = '';
    this.productIDNavigation = undefined;
    this.scrappedQty = 0;
    this.scrapReasonID = 0;
    this.scrapReasonIDEntity = '';
    this.scrapReasonIDNavigation = undefined;
    this.startDate = undefined;
    this.stockedQty = 0;
    this.workOrderID = 0;
  }

  setProperties(
    dueDate: any,
    endDate: any,
    modifiedDate: any,
    orderQty: number,
    productID: number,
    scrappedQty: number,
    scrapReasonID: number,
    startDate: any,
    stockedQty: number,
    workOrderID: number
  ): void {
    this.dueDate = dueDate;
    this.endDate = endDate;
    this.modifiedDate = modifiedDate;
    this.orderQty = orderQty;
    this.productID = productID;
    this.scrappedQty = scrappedQty;
    this.scrapReasonID = scrapReasonID;
    this.startDate = startDate;
    this.stockedQty = stockedQty;
    this.workOrderID = workOrderID;
  }
}
export class PurchaseOrderHeaderClientRequestModel {
  employeeID: number;
  freight: number;
  modifiedDate: any;
  orderDate: any;
  purchaseOrderID: number;
  revisionNumber: number;
  shipDate: any;
  shipMethodID: number;
  shipMethodIDEntity: string;
  shipMethodIDNavigation?: ShipMethodClientResponseModel;
  status: number;
  subTotal: number;
  taxAmt: number;
  totalDue: number;
  vendorID: number;
  vendorIDEntity: string;
  vendorIDNavigation?: VendorClientResponseModel;

  constructor() {
    this.employeeID = 0;
    this.freight = 0;
    this.modifiedDate = undefined;
    this.orderDate = undefined;
    this.purchaseOrderID = 0;
    this.revisionNumber = 0;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipMethodIDEntity = '';
    this.shipMethodIDNavigation = undefined;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.totalDue = 0;
    this.vendorID = 0;
    this.vendorIDEntity = '';
    this.vendorIDNavigation = undefined;
  }

  setProperties(
    employeeID: number,
    freight: number,
    modifiedDate: any,
    orderDate: any,
    purchaseOrderID: number,
    revisionNumber: number,
    shipDate: any,
    shipMethodID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    totalDue: number,
    vendorID: number
  ): void {
    this.employeeID = employeeID;
    this.freight = freight;
    this.modifiedDate = modifiedDate;
    this.orderDate = orderDate;
    this.purchaseOrderID = purchaseOrderID;
    this.revisionNumber = revisionNumber;
    this.shipDate = shipDate;
    this.shipMethodID = shipMethodID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.totalDue = totalDue;
    this.vendorID = vendorID;
  }
}

export class PurchaseOrderHeaderClientResponseModel {
  employeeID: number;
  freight: number;
  modifiedDate: any;
  orderDate: any;
  purchaseOrderID: number;
  revisionNumber: number;
  shipDate: any;
  shipMethodID: number;
  shipMethodIDEntity: string;
  shipMethodIDNavigation?: ShipMethodClientResponseModel;
  status: number;
  subTotal: number;
  taxAmt: number;
  totalDue: number;
  vendorID: number;
  vendorIDEntity: string;
  vendorIDNavigation?: VendorClientResponseModel;

  constructor() {
    this.employeeID = 0;
    this.freight = 0;
    this.modifiedDate = undefined;
    this.orderDate = undefined;
    this.purchaseOrderID = 0;
    this.revisionNumber = 0;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipMethodIDEntity = '';
    this.shipMethodIDNavigation = undefined;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.totalDue = 0;
    this.vendorID = 0;
    this.vendorIDEntity = '';
    this.vendorIDNavigation = undefined;
  }

  setProperties(
    employeeID: number,
    freight: number,
    modifiedDate: any,
    orderDate: any,
    purchaseOrderID: number,
    revisionNumber: number,
    shipDate: any,
    shipMethodID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    totalDue: number,
    vendorID: number
  ): void {
    this.employeeID = employeeID;
    this.freight = freight;
    this.modifiedDate = modifiedDate;
    this.orderDate = orderDate;
    this.purchaseOrderID = purchaseOrderID;
    this.revisionNumber = revisionNumber;
    this.shipDate = shipDate;
    this.shipMethodID = shipMethodID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.totalDue = totalDue;
    this.vendorID = vendorID;
  }
}
export class ShipMethodClientRequestModel {
  modifiedDate: any;
  name: string;
  rowguid: any;
  shipBase: number;
  shipMethodID: number;
  shipRate: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.shipBase = 0;
    this.shipMethodID = 0;
    this.shipRate = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    rowguid: any,
    shipBase: number,
    shipMethodID: number,
    shipRate: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.shipBase = shipBase;
    this.shipMethodID = shipMethodID;
    this.shipRate = shipRate;
  }
}

export class ShipMethodClientResponseModel {
  modifiedDate: any;
  name: string;
  rowguid: any;
  shipBase: number;
  shipMethodID: number;
  shipRate: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.shipBase = 0;
    this.shipMethodID = 0;
    this.shipRate = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    rowguid: any,
    shipBase: number,
    shipMethodID: number,
    shipRate: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.shipBase = shipBase;
    this.shipMethodID = shipMethodID;
    this.shipRate = shipRate;
  }
}
export class VendorClientRequestModel {
  accountNumber: string;
  activeFlag: boolean;
  businessEntityID: number;
  creditRating: number;
  modifiedDate: any;
  name: string;
  preferredVendorStatu: boolean;
  purchasingWebServiceURL: string;

  constructor() {
    this.accountNumber = '';
    this.activeFlag = false;
    this.businessEntityID = 0;
    this.creditRating = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.preferredVendorStatu = false;
    this.purchasingWebServiceURL = '';
  }

  setProperties(
    accountNumber: string,
    activeFlag: boolean,
    businessEntityID: number,
    creditRating: number,
    modifiedDate: any,
    name: string,
    preferredVendorStatu: boolean,
    purchasingWebServiceURL: string
  ): void {
    this.accountNumber = accountNumber;
    this.activeFlag = activeFlag;
    this.businessEntityID = businessEntityID;
    this.creditRating = creditRating;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.preferredVendorStatu = preferredVendorStatu;
    this.purchasingWebServiceURL = purchasingWebServiceURL;
  }
}

export class VendorClientResponseModel {
  accountNumber: string;
  activeFlag: boolean;
  businessEntityID: number;
  creditRating: number;
  modifiedDate: any;
  name: string;
  preferredVendorStatu: boolean;
  purchasingWebServiceURL: string;

  constructor() {
    this.accountNumber = '';
    this.activeFlag = false;
    this.businessEntityID = 0;
    this.creditRating = 0;
    this.modifiedDate = undefined;
    this.name = '';
    this.preferredVendorStatu = false;
    this.purchasingWebServiceURL = '';
  }

  setProperties(
    accountNumber: string,
    activeFlag: boolean,
    businessEntityID: number,
    creditRating: number,
    modifiedDate: any,
    name: string,
    preferredVendorStatu: boolean,
    purchasingWebServiceURL: string
  ): void {
    this.accountNumber = accountNumber;
    this.activeFlag = activeFlag;
    this.businessEntityID = businessEntityID;
    this.creditRating = creditRating;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.preferredVendorStatu = preferredVendorStatu;
    this.purchasingWebServiceURL = purchasingWebServiceURL;
  }
}
export class CreditCardClientRequestModel {
  cardNumber: string;
  cardType: string;
  creditCardID: number;
  expMonth: number;
  expYear: number;
  modifiedDate: any;

  constructor() {
    this.cardNumber = '';
    this.cardType = '';
    this.creditCardID = 0;
    this.expMonth = 0;
    this.expYear = 0;
    this.modifiedDate = undefined;
  }

  setProperties(
    cardNumber: string,
    cardType: string,
    creditCardID: number,
    expMonth: number,
    expYear: number,
    modifiedDate: any
  ): void {
    this.cardNumber = cardNumber;
    this.cardType = cardType;
    this.creditCardID = creditCardID;
    this.expMonth = expMonth;
    this.expYear = expYear;
    this.modifiedDate = modifiedDate;
  }
}

export class CreditCardClientResponseModel {
  cardNumber: string;
  cardType: string;
  creditCardID: number;
  expMonth: number;
  expYear: number;
  modifiedDate: any;

  constructor() {
    this.cardNumber = '';
    this.cardType = '';
    this.creditCardID = 0;
    this.expMonth = 0;
    this.expYear = 0;
    this.modifiedDate = undefined;
  }

  setProperties(
    cardNumber: string,
    cardType: string,
    creditCardID: number,
    expMonth: number,
    expYear: number,
    modifiedDate: any
  ): void {
    this.cardNumber = cardNumber;
    this.cardType = cardType;
    this.creditCardID = creditCardID;
    this.expMonth = expMonth;
    this.expYear = expYear;
    this.modifiedDate = modifiedDate;
  }
}
export class CurrencyClientRequestModel {
  currencyCode: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.currencyCode = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(currencyCode: string, modifiedDate: any, name: string): void {
    this.currencyCode = currencyCode;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}

export class CurrencyClientResponseModel {
  currencyCode: string;
  modifiedDate: any;
  name: string;

  constructor() {
    this.currencyCode = '';
    this.modifiedDate = undefined;
    this.name = '';
  }

  setProperties(currencyCode: string, modifiedDate: any, name: string): void {
    this.currencyCode = currencyCode;
    this.modifiedDate = modifiedDate;
    this.name = name;
  }
}
export class CurrencyRateClientRequestModel {
  averageRate: number;
  currencyRateDate: any;
  currencyRateID: number;
  endOfDayRate: number;
  fromCurrencyCode: string;
  fromCurrencyCodeEntity: string;
  fromCurrencyCodeNavigation?: CurrencyClientResponseModel;
  modifiedDate: any;
  toCurrencyCode: string;
  toCurrencyCodeEntity: string;
  toCurrencyCodeNavigation?: CurrencyClientResponseModel;

  constructor() {
    this.averageRate = 0;
    this.currencyRateDate = undefined;
    this.currencyRateID = 0;
    this.endOfDayRate = 0;
    this.fromCurrencyCode = '';
    this.fromCurrencyCodeEntity = '';
    this.fromCurrencyCodeNavigation = undefined;
    this.modifiedDate = undefined;
    this.toCurrencyCode = '';
    this.toCurrencyCodeEntity = '';
    this.toCurrencyCodeNavigation = undefined;
  }

  setProperties(
    averageRate: number,
    currencyRateDate: any,
    currencyRateID: number,
    endOfDayRate: number,
    fromCurrencyCode: string,
    modifiedDate: any,
    toCurrencyCode: string
  ): void {
    this.averageRate = averageRate;
    this.currencyRateDate = currencyRateDate;
    this.currencyRateID = currencyRateID;
    this.endOfDayRate = endOfDayRate;
    this.fromCurrencyCode = fromCurrencyCode;
    this.modifiedDate = modifiedDate;
    this.toCurrencyCode = toCurrencyCode;
  }
}

export class CurrencyRateClientResponseModel {
  averageRate: number;
  currencyRateDate: any;
  currencyRateID: number;
  endOfDayRate: number;
  fromCurrencyCode: string;
  fromCurrencyCodeEntity: string;
  fromCurrencyCodeNavigation?: CurrencyClientResponseModel;
  modifiedDate: any;
  toCurrencyCode: string;
  toCurrencyCodeEntity: string;
  toCurrencyCodeNavigation?: CurrencyClientResponseModel;

  constructor() {
    this.averageRate = 0;
    this.currencyRateDate = undefined;
    this.currencyRateID = 0;
    this.endOfDayRate = 0;
    this.fromCurrencyCode = '';
    this.fromCurrencyCodeEntity = '';
    this.fromCurrencyCodeNavigation = undefined;
    this.modifiedDate = undefined;
    this.toCurrencyCode = '';
    this.toCurrencyCodeEntity = '';
    this.toCurrencyCodeNavigation = undefined;
  }

  setProperties(
    averageRate: number,
    currencyRateDate: any,
    currencyRateID: number,
    endOfDayRate: number,
    fromCurrencyCode: string,
    modifiedDate: any,
    toCurrencyCode: string
  ): void {
    this.averageRate = averageRate;
    this.currencyRateDate = currencyRateDate;
    this.currencyRateID = currencyRateID;
    this.endOfDayRate = endOfDayRate;
    this.fromCurrencyCode = fromCurrencyCode;
    this.modifiedDate = modifiedDate;
    this.toCurrencyCode = toCurrencyCode;
  }
}
export class CustomerClientRequestModel {
  accountNumber: string;
  customerID: number;
  modifiedDate: any;
  personID: number;
  rowguid: any;
  storeID: number;
  storeIDEntity: string;
  storeIDNavigation?: StoreClientResponseModel;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryClientResponseModel;

  constructor() {
    this.accountNumber = '';
    this.customerID = 0;
    this.modifiedDate = undefined;
    this.personID = 0;
    this.rowguid = undefined;
    this.storeID = 0;
    this.storeIDEntity = '';
    this.storeIDNavigation = undefined;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
  }

  setProperties(
    accountNumber: string,
    customerID: number,
    modifiedDate: any,
    personID: number,
    rowguid: any,
    storeID: number,
    territoryID: number
  ): void {
    this.accountNumber = accountNumber;
    this.customerID = customerID;
    this.modifiedDate = modifiedDate;
    this.personID = personID;
    this.rowguid = rowguid;
    this.storeID = storeID;
    this.territoryID = territoryID;
  }
}

export class CustomerClientResponseModel {
  accountNumber: string;
  customerID: number;
  modifiedDate: any;
  personID: number;
  rowguid: any;
  storeID: number;
  storeIDEntity: string;
  storeIDNavigation?: StoreClientResponseModel;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryClientResponseModel;

  constructor() {
    this.accountNumber = '';
    this.customerID = 0;
    this.modifiedDate = undefined;
    this.personID = 0;
    this.rowguid = undefined;
    this.storeID = 0;
    this.storeIDEntity = '';
    this.storeIDNavigation = undefined;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
  }

  setProperties(
    accountNumber: string,
    customerID: number,
    modifiedDate: any,
    personID: number,
    rowguid: any,
    storeID: number,
    territoryID: number
  ): void {
    this.accountNumber = accountNumber;
    this.customerID = customerID;
    this.modifiedDate = modifiedDate;
    this.personID = personID;
    this.rowguid = rowguid;
    this.storeID = storeID;
    this.territoryID = territoryID;
  }
}
export class SalesOrderHeaderClientRequestModel {
  accountNumber: string;
  billToAddressID: number;
  comment: string;
  creditCardApprovalCode: string;
  creditCardID: number;
  creditCardIDEntity: string;
  creditCardIDNavigation?: CreditCardClientResponseModel;
  currencyRateID: number;
  currencyRateIDEntity: string;
  currencyRateIDNavigation?: CurrencyRateClientResponseModel;
  customerID: number;
  customerIDEntity: string;
  customerIDNavigation?: CustomerClientResponseModel;
  dueDate: any;
  freight: number;
  modifiedDate: any;
  onlineOrderFlag: boolean;
  orderDate: any;
  purchaseOrderNumber: string;
  revisionNumber: number;
  rowguid: any;
  salesOrderID: number;
  salesOrderNumber: string;
  salesPersonID: number;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonClientResponseModel;
  shipDate: any;
  shipMethodID: number;
  shipToAddressID: number;
  status: number;
  subTotal: number;
  taxAmt: number;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryClientResponseModel;
  totalDue: number;

  constructor() {
    this.accountNumber = '';
    this.billToAddressID = 0;
    this.comment = '';
    this.creditCardApprovalCode = '';
    this.creditCardID = 0;
    this.creditCardIDEntity = '';
    this.creditCardIDNavigation = undefined;
    this.currencyRateID = 0;
    this.currencyRateIDEntity = '';
    this.currencyRateIDNavigation = undefined;
    this.customerID = 0;
    this.customerIDEntity = '';
    this.customerIDNavigation = undefined;
    this.dueDate = undefined;
    this.freight = 0;
    this.modifiedDate = undefined;
    this.onlineOrderFlag = false;
    this.orderDate = undefined;
    this.purchaseOrderNumber = '';
    this.revisionNumber = 0;
    this.rowguid = undefined;
    this.salesOrderID = 0;
    this.salesOrderNumber = '';
    this.salesPersonID = 0;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipToAddressID = 0;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
    this.totalDue = 0;
  }

  setProperties(
    accountNumber: string,
    billToAddressID: number,
    comment: string,
    creditCardApprovalCode: string,
    creditCardID: number,
    currencyRateID: number,
    customerID: number,
    dueDate: any,
    freight: number,
    modifiedDate: any,
    onlineOrderFlag: boolean,
    orderDate: any,
    purchaseOrderNumber: string,
    revisionNumber: number,
    rowguid: any,
    salesOrderID: number,
    salesOrderNumber: string,
    salesPersonID: number,
    shipDate: any,
    shipMethodID: number,
    shipToAddressID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    territoryID: number,
    totalDue: number
  ): void {
    this.accountNumber = accountNumber;
    this.billToAddressID = billToAddressID;
    this.comment = comment;
    this.creditCardApprovalCode = creditCardApprovalCode;
    this.creditCardID = creditCardID;
    this.currencyRateID = currencyRateID;
    this.customerID = customerID;
    this.dueDate = dueDate;
    this.freight = freight;
    this.modifiedDate = modifiedDate;
    this.onlineOrderFlag = onlineOrderFlag;
    this.orderDate = orderDate;
    this.purchaseOrderNumber = purchaseOrderNumber;
    this.revisionNumber = revisionNumber;
    this.rowguid = rowguid;
    this.salesOrderID = salesOrderID;
    this.salesOrderNumber = salesOrderNumber;
    this.salesPersonID = salesPersonID;
    this.shipDate = shipDate;
    this.shipMethodID = shipMethodID;
    this.shipToAddressID = shipToAddressID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.territoryID = territoryID;
    this.totalDue = totalDue;
  }
}

export class SalesOrderHeaderClientResponseModel {
  accountNumber: string;
  billToAddressID: number;
  comment: string;
  creditCardApprovalCode: string;
  creditCardID: number;
  creditCardIDEntity: string;
  creditCardIDNavigation?: CreditCardClientResponseModel;
  currencyRateID: number;
  currencyRateIDEntity: string;
  currencyRateIDNavigation?: CurrencyRateClientResponseModel;
  customerID: number;
  customerIDEntity: string;
  customerIDNavigation?: CustomerClientResponseModel;
  dueDate: any;
  freight: number;
  modifiedDate: any;
  onlineOrderFlag: boolean;
  orderDate: any;
  purchaseOrderNumber: string;
  revisionNumber: number;
  rowguid: any;
  salesOrderID: number;
  salesOrderNumber: string;
  salesPersonID: number;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonClientResponseModel;
  shipDate: any;
  shipMethodID: number;
  shipToAddressID: number;
  status: number;
  subTotal: number;
  taxAmt: number;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryClientResponseModel;
  totalDue: number;

  constructor() {
    this.accountNumber = '';
    this.billToAddressID = 0;
    this.comment = '';
    this.creditCardApprovalCode = '';
    this.creditCardID = 0;
    this.creditCardIDEntity = '';
    this.creditCardIDNavigation = undefined;
    this.currencyRateID = 0;
    this.currencyRateIDEntity = '';
    this.currencyRateIDNavigation = undefined;
    this.customerID = 0;
    this.customerIDEntity = '';
    this.customerIDNavigation = undefined;
    this.dueDate = undefined;
    this.freight = 0;
    this.modifiedDate = undefined;
    this.onlineOrderFlag = false;
    this.orderDate = undefined;
    this.purchaseOrderNumber = '';
    this.revisionNumber = 0;
    this.rowguid = undefined;
    this.salesOrderID = 0;
    this.salesOrderNumber = '';
    this.salesPersonID = 0;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
    this.shipDate = undefined;
    this.shipMethodID = 0;
    this.shipToAddressID = 0;
    this.status = 0;
    this.subTotal = 0;
    this.taxAmt = 0;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
    this.totalDue = 0;
  }

  setProperties(
    accountNumber: string,
    billToAddressID: number,
    comment: string,
    creditCardApprovalCode: string,
    creditCardID: number,
    currencyRateID: number,
    customerID: number,
    dueDate: any,
    freight: number,
    modifiedDate: any,
    onlineOrderFlag: boolean,
    orderDate: any,
    purchaseOrderNumber: string,
    revisionNumber: number,
    rowguid: any,
    salesOrderID: number,
    salesOrderNumber: string,
    salesPersonID: number,
    shipDate: any,
    shipMethodID: number,
    shipToAddressID: number,
    status: number,
    subTotal: number,
    taxAmt: number,
    territoryID: number,
    totalDue: number
  ): void {
    this.accountNumber = accountNumber;
    this.billToAddressID = billToAddressID;
    this.comment = comment;
    this.creditCardApprovalCode = creditCardApprovalCode;
    this.creditCardID = creditCardID;
    this.currencyRateID = currencyRateID;
    this.customerID = customerID;
    this.dueDate = dueDate;
    this.freight = freight;
    this.modifiedDate = modifiedDate;
    this.onlineOrderFlag = onlineOrderFlag;
    this.orderDate = orderDate;
    this.purchaseOrderNumber = purchaseOrderNumber;
    this.revisionNumber = revisionNumber;
    this.rowguid = rowguid;
    this.salesOrderID = salesOrderID;
    this.salesOrderNumber = salesOrderNumber;
    this.salesPersonID = salesPersonID;
    this.shipDate = shipDate;
    this.shipMethodID = shipMethodID;
    this.shipToAddressID = shipToAddressID;
    this.status = status;
    this.subTotal = subTotal;
    this.taxAmt = taxAmt;
    this.territoryID = territoryID;
    this.totalDue = totalDue;
  }
}
export class SalesPersonClientRequestModel {
  bonus: number;
  businessEntityID: number;
  commissionPct: number;
  modifiedDate: any;
  rowguid: any;
  salesLastYear: number;
  salesQuota: number;
  salesYTD: number;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryClientResponseModel;

  constructor() {
    this.bonus = 0;
    this.businessEntityID = 0;
    this.commissionPct = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesQuota = 0;
    this.salesYTD = 0;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
  }

  setProperties(
    bonus: number,
    businessEntityID: number,
    commissionPct: number,
    modifiedDate: any,
    rowguid: any,
    salesLastYear: number,
    salesQuota: number,
    salesYTD: number,
    territoryID: number
  ): void {
    this.bonus = bonus;
    this.businessEntityID = businessEntityID;
    this.commissionPct = commissionPct;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesQuota = salesQuota;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }
}

export class SalesPersonClientResponseModel {
  bonus: number;
  businessEntityID: number;
  commissionPct: number;
  modifiedDate: any;
  rowguid: any;
  salesLastYear: number;
  salesQuota: number;
  salesYTD: number;
  territoryID: number;
  territoryIDEntity: string;
  territoryIDNavigation?: SalesTerritoryClientResponseModel;

  constructor() {
    this.bonus = 0;
    this.businessEntityID = 0;
    this.commissionPct = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesQuota = 0;
    this.salesYTD = 0;
    this.territoryID = 0;
    this.territoryIDEntity = '';
    this.territoryIDNavigation = undefined;
  }

  setProperties(
    bonus: number,
    businessEntityID: number,
    commissionPct: number,
    modifiedDate: any,
    rowguid: any,
    salesLastYear: number,
    salesQuota: number,
    salesYTD: number,
    territoryID: number
  ): void {
    this.bonus = bonus;
    this.businessEntityID = businessEntityID;
    this.commissionPct = commissionPct;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesQuota = salesQuota;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }
}
export class SalesReasonClientRequestModel {
  modifiedDate: any;
  name: string;
  reasonType: string;
  salesReasonID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.reasonType = '';
    this.salesReasonID = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    reasonType: string,
    salesReasonID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.reasonType = reasonType;
    this.salesReasonID = salesReasonID;
  }
}

export class SalesReasonClientResponseModel {
  modifiedDate: any;
  name: string;
  reasonType: string;
  salesReasonID: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.reasonType = '';
    this.salesReasonID = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    reasonType: string,
    salesReasonID: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.reasonType = reasonType;
    this.salesReasonID = salesReasonID;
  }
}
export class SalesTaxRateClientRequestModel {
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesTaxRateID: number;
  stateProvinceID: number;
  taxRate: number;
  taxType: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesTaxRateID = 0;
    this.stateProvinceID = 0;
    this.taxRate = 0;
    this.taxType = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesTaxRateID: number,
    stateProvinceID: number,
    taxRate: number,
    taxType: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesTaxRateID = salesTaxRateID;
    this.stateProvinceID = stateProvinceID;
    this.taxRate = taxRate;
    this.taxType = taxType;
  }
}

export class SalesTaxRateClientResponseModel {
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesTaxRateID: number;
  stateProvinceID: number;
  taxRate: number;
  taxType: number;

  constructor() {
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesTaxRateID = 0;
    this.stateProvinceID = 0;
    this.taxRate = 0;
    this.taxType = 0;
  }

  setProperties(
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesTaxRateID: number,
    stateProvinceID: number,
    taxRate: number,
    taxType: number
  ): void {
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesTaxRateID = salesTaxRateID;
    this.stateProvinceID = stateProvinceID;
    this.taxRate = taxRate;
    this.taxType = taxType;
  }
}
export class SalesTerritoryClientRequestModel {
  costLastYear: number;
  costYTD: number;
  countryRegionCode: string;
  reservedGroup: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesLastYear: number;
  salesYTD: number;
  territoryID: number;

  constructor() {
    this.costLastYear = 0;
    this.costYTD = 0;
    this.countryRegionCode = '';
    this.reservedGroup = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesYTD = 0;
    this.territoryID = 0;
  }

  setProperties(
    costLastYear: number,
    costYTD: number,
    countryRegionCode: string,
    reservedGroup: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesLastYear: number,
    salesYTD: number,
    territoryID: number
  ): void {
    this.costLastYear = costLastYear;
    this.costYTD = costYTD;
    this.countryRegionCode = countryRegionCode;
    this.reservedGroup = reservedGroup;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }
}

export class SalesTerritoryClientResponseModel {
  costLastYear: number;
  costYTD: number;
  countryRegionCode: string;
  reservedGroup: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesLastYear: number;
  salesYTD: number;
  territoryID: number;

  constructor() {
    this.costLastYear = 0;
    this.costYTD = 0;
    this.countryRegionCode = '';
    this.reservedGroup = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesLastYear = 0;
    this.salesYTD = 0;
    this.territoryID = 0;
  }

  setProperties(
    costLastYear: number,
    costYTD: number,
    countryRegionCode: string,
    reservedGroup: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesLastYear: number,
    salesYTD: number,
    territoryID: number
  ): void {
    this.costLastYear = costLastYear;
    this.costYTD = costYTD;
    this.countryRegionCode = countryRegionCode;
    this.reservedGroup = reservedGroup;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesLastYear = salesLastYear;
    this.salesYTD = salesYTD;
    this.territoryID = territoryID;
  }
}
export class ShoppingCartItemClientRequestModel {
  dateCreated: any;
  modifiedDate: any;
  productID: number;
  quantity: number;
  shoppingCartID: string;
  shoppingCartItemID: number;

  constructor() {
    this.dateCreated = undefined;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.quantity = 0;
    this.shoppingCartID = '';
    this.shoppingCartItemID = 0;
  }

  setProperties(
    dateCreated: any,
    modifiedDate: any,
    productID: number,
    quantity: number,
    shoppingCartID: string,
    shoppingCartItemID: number
  ): void {
    this.dateCreated = dateCreated;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.shoppingCartID = shoppingCartID;
    this.shoppingCartItemID = shoppingCartItemID;
  }
}

export class ShoppingCartItemClientResponseModel {
  dateCreated: any;
  modifiedDate: any;
  productID: number;
  quantity: number;
  shoppingCartID: string;
  shoppingCartItemID: number;

  constructor() {
    this.dateCreated = undefined;
    this.modifiedDate = undefined;
    this.productID = 0;
    this.quantity = 0;
    this.shoppingCartID = '';
    this.shoppingCartItemID = 0;
  }

  setProperties(
    dateCreated: any,
    modifiedDate: any,
    productID: number,
    quantity: number,
    shoppingCartID: string,
    shoppingCartItemID: number
  ): void {
    this.dateCreated = dateCreated;
    this.modifiedDate = modifiedDate;
    this.productID = productID;
    this.quantity = quantity;
    this.shoppingCartID = shoppingCartID;
    this.shoppingCartItemID = shoppingCartItemID;
  }
}
export class SpecialOfferClientRequestModel {
  category: string;
  description: string;
  discountPct: number;
  endDate: any;
  maxQty: number;
  minQty: number;
  modifiedDate: any;
  rowguid: any;
  specialOfferID: number;
  startDate: any;
  reservedType: string;

  constructor() {
    this.category = '';
    this.description = '';
    this.discountPct = 0;
    this.endDate = undefined;
    this.maxQty = 0;
    this.minQty = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.specialOfferID = 0;
    this.startDate = undefined;
    this.reservedType = '';
  }

  setProperties(
    category: string,
    description: string,
    discountPct: number,
    endDate: any,
    maxQty: number,
    minQty: number,
    modifiedDate: any,
    rowguid: any,
    specialOfferID: number,
    startDate: any,
    reservedType: string
  ): void {
    this.category = category;
    this.description = description;
    this.discountPct = discountPct;
    this.endDate = endDate;
    this.maxQty = maxQty;
    this.minQty = minQty;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
    this.specialOfferID = specialOfferID;
    this.startDate = startDate;
    this.reservedType = reservedType;
  }
}

export class SpecialOfferClientResponseModel {
  category: string;
  description: string;
  discountPct: number;
  endDate: any;
  maxQty: number;
  minQty: number;
  modifiedDate: any;
  rowguid: any;
  specialOfferID: number;
  startDate: any;
  reservedType: string;

  constructor() {
    this.category = '';
    this.description = '';
    this.discountPct = 0;
    this.endDate = undefined;
    this.maxQty = 0;
    this.minQty = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.specialOfferID = 0;
    this.startDate = undefined;
    this.reservedType = '';
  }

  setProperties(
    category: string,
    description: string,
    discountPct: number,
    endDate: any,
    maxQty: number,
    minQty: number,
    modifiedDate: any,
    rowguid: any,
    specialOfferID: number,
    startDate: any,
    reservedType: string
  ): void {
    this.category = category;
    this.description = description;
    this.discountPct = discountPct;
    this.endDate = endDate;
    this.maxQty = maxQty;
    this.minQty = minQty;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
    this.specialOfferID = specialOfferID;
    this.startDate = startDate;
    this.reservedType = reservedType;
  }
}
export class StoreClientRequestModel {
  businessEntityID: number;
  demographic: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesPersonID: number;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonClientResponseModel;

  constructor() {
    this.businessEntityID = 0;
    this.demographic = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesPersonID = 0;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
  }

  setProperties(
    businessEntityID: number,
    demographic: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesPersonID: number
  ): void {
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesPersonID = salesPersonID;
  }
}

export class StoreClientResponseModel {
  businessEntityID: number;
  demographic: string;
  modifiedDate: any;
  name: string;
  rowguid: any;
  salesPersonID: number;
  salesPersonIDEntity: string;
  salesPersonIDNavigation?: SalesPersonClientResponseModel;

  constructor() {
    this.businessEntityID = 0;
    this.demographic = '';
    this.modifiedDate = undefined;
    this.name = '';
    this.rowguid = undefined;
    this.salesPersonID = 0;
    this.salesPersonIDEntity = '';
    this.salesPersonIDNavigation = undefined;
  }

  setProperties(
    businessEntityID: number,
    demographic: string,
    modifiedDate: any,
    name: string,
    rowguid: any,
    salesPersonID: number
  ): void {
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.rowguid = rowguid;
    this.salesPersonID = salesPersonID;
  }
}


/*<Codenesium>
    <Hash>7553168e80d889a57f97391a3bc8766b</Hash>
</Codenesium>*/