export class ColumnSameAsFKTableClientRequestModel {
  id: number;
  person: number;
  personEntity: string;
  personNavigation?: PersonClientResponseModel;
  personId: number;
  personIdEntity: string;
  personIdNavigation?: PersonClientResponseModel;

  constructor() {
    this.id = 0;
    this.person = 0;
    this.personEntity = '';
    this.personNavigation = undefined;
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = undefined;
  }

  setProperties(id: number, person: number, personId: number): void {
    this.id = id;
    this.person = person;
    this.personId = personId;
  }
}

export class ColumnSameAsFKTableClientResponseModel {
  id: number;
  person: number;
  personEntity: string;
  personNavigation?: PersonClientResponseModel;
  personId: number;
  personIdEntity: string;
  personIdNavigation?: PersonClientResponseModel;

  constructor() {
    this.id = 0;
    this.person = 0;
    this.personEntity = '';
    this.personNavigation = undefined;
    this.personId = 0;
    this.personIdEntity = '';
    this.personIdNavigation = undefined;
  }

  setProperties(id: number, person: number, personId: number): void {
    this.id = id;
    this.person = person;
    this.personId = personId;
  }
}
export class IncludedColumnTestClientRequestModel {
  id: number;
  name: string;
  name2: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.name2 = '';
  }

  setProperties(id: number, name: string, name2: string): void {
    this.id = id;
    this.name = name;
    this.name2 = name2;
  }
}

export class IncludedColumnTestClientResponseModel {
  id: number;
  name: string;
  name2: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.name2 = '';
  }

  setProperties(id: number, name: string, name2: string): void {
    this.id = id;
    this.name = name;
    this.name2 = name2;
  }
}
export class PersonClientRequestModel {
  personId: number;
  personName: string;

  constructor() {
    this.personId = 0;
    this.personName = '';
  }

  setProperties(personId: number, personName: string): void {
    this.personId = personId;
    this.personName = personName;
  }
}

export class PersonClientResponseModel {
  personId: number;
  personName: string;

  constructor() {
    this.personId = 0;
    this.personName = '';
  }

  setProperties(personId: number, personName: string): void {
    this.personId = personId;
    this.personName = personName;
  }
}
export class RowVersionCheckClientRequestModel {
  id: number;
  name: string;
  rowVersion: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.rowVersion = undefined;
  }

  setProperties(id: number, name: string, rowVersion: any): void {
    this.id = id;
    this.name = name;
    this.rowVersion = rowVersion;
  }
}

export class RowVersionCheckClientResponseModel {
  id: number;
  name: string;
  rowVersion: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.rowVersion = undefined;
  }

  setProperties(id: number, name: string, rowVersion: any): void {
    this.id = id;
    this.name = name;
    this.rowVersion = rowVersion;
  }
}
export class SelfReferenceClientRequestModel {
  id: number;
  selfReferenceId: number;
  selfReferenceIdEntity: string;
  selfReferenceIdNavigation?: SelfReferenceClientResponseModel;
  selfReferenceId2: number;
  selfReferenceId2Entity: string;
  selfReferenceId2Navigation?: SelfReferenceClientResponseModel;

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
}

export class SelfReferenceClientResponseModel {
  id: number;
  selfReferenceId: number;
  selfReferenceIdEntity: string;
  selfReferenceIdNavigation?: SelfReferenceClientResponseModel;
  selfReferenceId2: number;
  selfReferenceId2Entity: string;
  selfReferenceId2Navigation?: SelfReferenceClientResponseModel;

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
}
export class TableClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class TableClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class TestAllFieldTypeClientRequestModel {
  fieldBigInt: number;
  fieldBinary: any;
  fieldBit: boolean;
  fieldChar: string;
  fieldDate: any;
  fieldDateTime: any;
  fieldDateTime2: any;
  fieldDateTimeOffset: any;
  fieldDecimal: number;
  fieldFloat: number;
  fieldImage: any;
  fieldMoney: number;
  fieldNChar: string;
  fieldNText: string;
  fieldNumeric: number;
  fieldNVarchar: string;
  fieldReal: number;
  fieldSmallDateTime: any;
  fieldSmallInt: number;
  fieldSmallMoney: number;
  fieldText: string;
  fieldTime: any;
  fieldTimestamp: any;
  fieldTinyInt: number;
  fieldUniqueIdentifier: any;
  fieldVarBinary: any;
  fieldVarchar: string;
  fieldXML: string;
  id: number;

  constructor() {
    this.fieldBigInt = 0;
    this.fieldBinary = undefined;
    this.fieldBit = false;
    this.fieldChar = '';
    this.fieldDate = undefined;
    this.fieldDateTime = undefined;
    this.fieldDateTime2 = undefined;
    this.fieldDateTimeOffset = undefined;
    this.fieldDecimal = 0;
    this.fieldFloat = 0;
    this.fieldImage = undefined;
    this.fieldMoney = 0;
    this.fieldNChar = '';
    this.fieldNText = '';
    this.fieldNumeric = 0;
    this.fieldNVarchar = '';
    this.fieldReal = 0;
    this.fieldSmallDateTime = undefined;
    this.fieldSmallInt = 0;
    this.fieldSmallMoney = 0;
    this.fieldText = '';
    this.fieldTime = undefined;
    this.fieldTimestamp = undefined;
    this.fieldTinyInt = 0;
    this.fieldUniqueIdentifier = undefined;
    this.fieldVarBinary = undefined;
    this.fieldVarchar = '';
    this.fieldXML = '';
    this.id = 0;
  }

  setProperties(
    fieldBigInt: number,
    fieldBinary: any,
    fieldBit: boolean,
    fieldChar: string,
    fieldDate: any,
    fieldDateTime: any,
    fieldDateTime2: any,
    fieldDateTimeOffset: any,
    fieldDecimal: number,
    fieldFloat: number,
    fieldImage: any,
    fieldMoney: number,
    fieldNChar: string,
    fieldNText: string,
    fieldNumeric: number,
    fieldNVarchar: string,
    fieldReal: number,
    fieldSmallDateTime: any,
    fieldSmallInt: number,
    fieldSmallMoney: number,
    fieldText: string,
    fieldTime: any,
    fieldTimestamp: any,
    fieldTinyInt: number,
    fieldUniqueIdentifier: any,
    fieldVarBinary: any,
    fieldVarchar: string,
    fieldXML: string,
    id: number
  ): void {
    this.fieldBigInt = fieldBigInt;
    this.fieldBinary = fieldBinary;
    this.fieldBit = fieldBit;
    this.fieldChar = fieldChar;
    this.fieldDate = fieldDate;
    this.fieldDateTime = fieldDateTime;
    this.fieldDateTime2 = fieldDateTime2;
    this.fieldDateTimeOffset = fieldDateTimeOffset;
    this.fieldDecimal = fieldDecimal;
    this.fieldFloat = fieldFloat;
    this.fieldImage = fieldImage;
    this.fieldMoney = fieldMoney;
    this.fieldNChar = fieldNChar;
    this.fieldNText = fieldNText;
    this.fieldNumeric = fieldNumeric;
    this.fieldNVarchar = fieldNVarchar;
    this.fieldReal = fieldReal;
    this.fieldSmallDateTime = fieldSmallDateTime;
    this.fieldSmallInt = fieldSmallInt;
    this.fieldSmallMoney = fieldSmallMoney;
    this.fieldText = fieldText;
    this.fieldTime = fieldTime;
    this.fieldTimestamp = fieldTimestamp;
    this.fieldTinyInt = fieldTinyInt;
    this.fieldUniqueIdentifier = fieldUniqueIdentifier;
    this.fieldVarBinary = fieldVarBinary;
    this.fieldVarchar = fieldVarchar;
    this.fieldXML = fieldXML;
    this.id = id;
  }
}

export class TestAllFieldTypeClientResponseModel {
  fieldBigInt: number;
  fieldBinary: any;
  fieldBit: boolean;
  fieldChar: string;
  fieldDate: any;
  fieldDateTime: any;
  fieldDateTime2: any;
  fieldDateTimeOffset: any;
  fieldDecimal: number;
  fieldFloat: number;
  fieldImage: any;
  fieldMoney: number;
  fieldNChar: string;
  fieldNText: string;
  fieldNumeric: number;
  fieldNVarchar: string;
  fieldReal: number;
  fieldSmallDateTime: any;
  fieldSmallInt: number;
  fieldSmallMoney: number;
  fieldText: string;
  fieldTime: any;
  fieldTimestamp: any;
  fieldTinyInt: number;
  fieldUniqueIdentifier: any;
  fieldVarBinary: any;
  fieldVarchar: string;
  fieldXML: string;
  id: number;

  constructor() {
    this.fieldBigInt = 0;
    this.fieldBinary = undefined;
    this.fieldBit = false;
    this.fieldChar = '';
    this.fieldDate = undefined;
    this.fieldDateTime = undefined;
    this.fieldDateTime2 = undefined;
    this.fieldDateTimeOffset = undefined;
    this.fieldDecimal = 0;
    this.fieldFloat = 0;
    this.fieldImage = undefined;
    this.fieldMoney = 0;
    this.fieldNChar = '';
    this.fieldNText = '';
    this.fieldNumeric = 0;
    this.fieldNVarchar = '';
    this.fieldReal = 0;
    this.fieldSmallDateTime = undefined;
    this.fieldSmallInt = 0;
    this.fieldSmallMoney = 0;
    this.fieldText = '';
    this.fieldTime = undefined;
    this.fieldTimestamp = undefined;
    this.fieldTinyInt = 0;
    this.fieldUniqueIdentifier = undefined;
    this.fieldVarBinary = undefined;
    this.fieldVarchar = '';
    this.fieldXML = '';
    this.id = 0;
  }

  setProperties(
    fieldBigInt: number,
    fieldBinary: any,
    fieldBit: boolean,
    fieldChar: string,
    fieldDate: any,
    fieldDateTime: any,
    fieldDateTime2: any,
    fieldDateTimeOffset: any,
    fieldDecimal: number,
    fieldFloat: number,
    fieldImage: any,
    fieldMoney: number,
    fieldNChar: string,
    fieldNText: string,
    fieldNumeric: number,
    fieldNVarchar: string,
    fieldReal: number,
    fieldSmallDateTime: any,
    fieldSmallInt: number,
    fieldSmallMoney: number,
    fieldText: string,
    fieldTime: any,
    fieldTimestamp: any,
    fieldTinyInt: number,
    fieldUniqueIdentifier: any,
    fieldVarBinary: any,
    fieldVarchar: string,
    fieldXML: string,
    id: number
  ): void {
    this.fieldBigInt = fieldBigInt;
    this.fieldBinary = fieldBinary;
    this.fieldBit = fieldBit;
    this.fieldChar = fieldChar;
    this.fieldDate = fieldDate;
    this.fieldDateTime = fieldDateTime;
    this.fieldDateTime2 = fieldDateTime2;
    this.fieldDateTimeOffset = fieldDateTimeOffset;
    this.fieldDecimal = fieldDecimal;
    this.fieldFloat = fieldFloat;
    this.fieldImage = fieldImage;
    this.fieldMoney = fieldMoney;
    this.fieldNChar = fieldNChar;
    this.fieldNText = fieldNText;
    this.fieldNumeric = fieldNumeric;
    this.fieldNVarchar = fieldNVarchar;
    this.fieldReal = fieldReal;
    this.fieldSmallDateTime = fieldSmallDateTime;
    this.fieldSmallInt = fieldSmallInt;
    this.fieldSmallMoney = fieldSmallMoney;
    this.fieldText = fieldText;
    this.fieldTime = fieldTime;
    this.fieldTimestamp = fieldTimestamp;
    this.fieldTinyInt = fieldTinyInt;
    this.fieldUniqueIdentifier = fieldUniqueIdentifier;
    this.fieldVarBinary = fieldVarBinary;
    this.fieldVarchar = fieldVarchar;
    this.fieldXML = fieldXML;
    this.id = id;
  }
}
export class TestAllFieldTypesNullableClientRequestModel {
  fieldBigInt: number;
  fieldBinary: any;
  fieldBit: boolean;
  fieldChar: string;
  fieldDate: any;
  fieldDateTime: any;
  fieldDateTime2: any;
  fieldDateTimeOffset: any;
  fieldDecimal: number;
  fieldFloat: number;
  fieldImage: any;
  fieldMoney: number;
  fieldNChar: string;
  fieldNText: string;
  fieldNumeric: number;
  fieldNVarchar: string;
  fieldReal: number;
  fieldSmallDateTime: any;
  fieldSmallInt: number;
  fieldSmallMoney: number;
  fieldText: string;
  fieldTime: any;
  fieldTimestamp: any;
  fieldTinyInt: number;
  fieldUniqueIdentifier: any;
  fieldVarBinary: any;
  fieldVarchar: string;
  fieldXML: string;
  id: number;

  constructor() {
    this.fieldBigInt = 0;
    this.fieldBinary = undefined;
    this.fieldBit = false;
    this.fieldChar = '';
    this.fieldDate = undefined;
    this.fieldDateTime = undefined;
    this.fieldDateTime2 = undefined;
    this.fieldDateTimeOffset = undefined;
    this.fieldDecimal = 0;
    this.fieldFloat = 0;
    this.fieldImage = undefined;
    this.fieldMoney = 0;
    this.fieldNChar = '';
    this.fieldNText = '';
    this.fieldNumeric = 0;
    this.fieldNVarchar = '';
    this.fieldReal = 0;
    this.fieldSmallDateTime = undefined;
    this.fieldSmallInt = 0;
    this.fieldSmallMoney = 0;
    this.fieldText = '';
    this.fieldTime = undefined;
    this.fieldTimestamp = undefined;
    this.fieldTinyInt = 0;
    this.fieldUniqueIdentifier = undefined;
    this.fieldVarBinary = undefined;
    this.fieldVarchar = '';
    this.fieldXML = '';
    this.id = 0;
  }

  setProperties(
    fieldBigInt: number,
    fieldBinary: any,
    fieldBit: boolean,
    fieldChar: string,
    fieldDate: any,
    fieldDateTime: any,
    fieldDateTime2: any,
    fieldDateTimeOffset: any,
    fieldDecimal: number,
    fieldFloat: number,
    fieldImage: any,
    fieldMoney: number,
    fieldNChar: string,
    fieldNText: string,
    fieldNumeric: number,
    fieldNVarchar: string,
    fieldReal: number,
    fieldSmallDateTime: any,
    fieldSmallInt: number,
    fieldSmallMoney: number,
    fieldText: string,
    fieldTime: any,
    fieldTimestamp: any,
    fieldTinyInt: number,
    fieldUniqueIdentifier: any,
    fieldVarBinary: any,
    fieldVarchar: string,
    fieldXML: string,
    id: number
  ): void {
    this.fieldBigInt = fieldBigInt;
    this.fieldBinary = fieldBinary;
    this.fieldBit = fieldBit;
    this.fieldChar = fieldChar;
    this.fieldDate = fieldDate;
    this.fieldDateTime = fieldDateTime;
    this.fieldDateTime2 = fieldDateTime2;
    this.fieldDateTimeOffset = fieldDateTimeOffset;
    this.fieldDecimal = fieldDecimal;
    this.fieldFloat = fieldFloat;
    this.fieldImage = fieldImage;
    this.fieldMoney = fieldMoney;
    this.fieldNChar = fieldNChar;
    this.fieldNText = fieldNText;
    this.fieldNumeric = fieldNumeric;
    this.fieldNVarchar = fieldNVarchar;
    this.fieldReal = fieldReal;
    this.fieldSmallDateTime = fieldSmallDateTime;
    this.fieldSmallInt = fieldSmallInt;
    this.fieldSmallMoney = fieldSmallMoney;
    this.fieldText = fieldText;
    this.fieldTime = fieldTime;
    this.fieldTimestamp = fieldTimestamp;
    this.fieldTinyInt = fieldTinyInt;
    this.fieldUniqueIdentifier = fieldUniqueIdentifier;
    this.fieldVarBinary = fieldVarBinary;
    this.fieldVarchar = fieldVarchar;
    this.fieldXML = fieldXML;
    this.id = id;
  }
}

export class TestAllFieldTypesNullableClientResponseModel {
  fieldBigInt: number;
  fieldBinary: any;
  fieldBit: boolean;
  fieldChar: string;
  fieldDate: any;
  fieldDateTime: any;
  fieldDateTime2: any;
  fieldDateTimeOffset: any;
  fieldDecimal: number;
  fieldFloat: number;
  fieldImage: any;
  fieldMoney: number;
  fieldNChar: string;
  fieldNText: string;
  fieldNumeric: number;
  fieldNVarchar: string;
  fieldReal: number;
  fieldSmallDateTime: any;
  fieldSmallInt: number;
  fieldSmallMoney: number;
  fieldText: string;
  fieldTime: any;
  fieldTimestamp: any;
  fieldTinyInt: number;
  fieldUniqueIdentifier: any;
  fieldVarBinary: any;
  fieldVarchar: string;
  fieldXML: string;
  id: number;

  constructor() {
    this.fieldBigInt = 0;
    this.fieldBinary = undefined;
    this.fieldBit = false;
    this.fieldChar = '';
    this.fieldDate = undefined;
    this.fieldDateTime = undefined;
    this.fieldDateTime2 = undefined;
    this.fieldDateTimeOffset = undefined;
    this.fieldDecimal = 0;
    this.fieldFloat = 0;
    this.fieldImage = undefined;
    this.fieldMoney = 0;
    this.fieldNChar = '';
    this.fieldNText = '';
    this.fieldNumeric = 0;
    this.fieldNVarchar = '';
    this.fieldReal = 0;
    this.fieldSmallDateTime = undefined;
    this.fieldSmallInt = 0;
    this.fieldSmallMoney = 0;
    this.fieldText = '';
    this.fieldTime = undefined;
    this.fieldTimestamp = undefined;
    this.fieldTinyInt = 0;
    this.fieldUniqueIdentifier = undefined;
    this.fieldVarBinary = undefined;
    this.fieldVarchar = '';
    this.fieldXML = '';
    this.id = 0;
  }

  setProperties(
    fieldBigInt: number,
    fieldBinary: any,
    fieldBit: boolean,
    fieldChar: string,
    fieldDate: any,
    fieldDateTime: any,
    fieldDateTime2: any,
    fieldDateTimeOffset: any,
    fieldDecimal: number,
    fieldFloat: number,
    fieldImage: any,
    fieldMoney: number,
    fieldNChar: string,
    fieldNText: string,
    fieldNumeric: number,
    fieldNVarchar: string,
    fieldReal: number,
    fieldSmallDateTime: any,
    fieldSmallInt: number,
    fieldSmallMoney: number,
    fieldText: string,
    fieldTime: any,
    fieldTimestamp: any,
    fieldTinyInt: number,
    fieldUniqueIdentifier: any,
    fieldVarBinary: any,
    fieldVarchar: string,
    fieldXML: string,
    id: number
  ): void {
    this.fieldBigInt = fieldBigInt;
    this.fieldBinary = fieldBinary;
    this.fieldBit = fieldBit;
    this.fieldChar = fieldChar;
    this.fieldDate = fieldDate;
    this.fieldDateTime = fieldDateTime;
    this.fieldDateTime2 = fieldDateTime2;
    this.fieldDateTimeOffset = fieldDateTimeOffset;
    this.fieldDecimal = fieldDecimal;
    this.fieldFloat = fieldFloat;
    this.fieldImage = fieldImage;
    this.fieldMoney = fieldMoney;
    this.fieldNChar = fieldNChar;
    this.fieldNText = fieldNText;
    this.fieldNumeric = fieldNumeric;
    this.fieldNVarchar = fieldNVarchar;
    this.fieldReal = fieldReal;
    this.fieldSmallDateTime = fieldSmallDateTime;
    this.fieldSmallInt = fieldSmallInt;
    this.fieldSmallMoney = fieldSmallMoney;
    this.fieldText = fieldText;
    this.fieldTime = fieldTime;
    this.fieldTimestamp = fieldTimestamp;
    this.fieldTinyInt = fieldTinyInt;
    this.fieldUniqueIdentifier = fieldUniqueIdentifier;
    this.fieldVarBinary = fieldVarBinary;
    this.fieldVarchar = fieldVarchar;
    this.fieldXML = fieldXML;
    this.id = id;
  }
}
export class TimestampCheckClientRequestModel {
  id: number;
  name: string;
  timestamp: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.timestamp = undefined;
  }

  setProperties(id: number, name: string, timestamp: any): void {
    this.id = id;
    this.name = name;
    this.timestamp = timestamp;
  }
}

export class TimestampCheckClientResponseModel {
  id: number;
  name: string;
  timestamp: any;

  constructor() {
    this.id = 0;
    this.name = '';
    this.timestamp = undefined;
  }

  setProperties(id: number, name: string, timestamp: any): void {
    this.id = id;
    this.name = name;
    this.timestamp = timestamp;
  }
}
export class VPersonClientRequestModel {
  personId: number;
  personName: string;

  constructor() {
    this.personId = 0;
    this.personName = '';
  }

  setProperties(personId: number, personName: string): void {
    this.personId = personId;
    this.personName = personName;
  }
}

export class VPersonClientResponseModel {
  personId: number;
  personName: string;

  constructor() {
    this.personId = 0;
    this.personName = '';
  }

  setProperties(personId: number, personName: string): void {
    this.personId = personId;
    this.personName = personName;
  }
}


/*<Codenesium>
    <Hash>d1c4b9b6070ed46a155d0b23f4e07f8b</Hash>
</Codenesium>*/