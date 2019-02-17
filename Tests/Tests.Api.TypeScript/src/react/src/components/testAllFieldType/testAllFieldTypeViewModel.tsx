export default class TestAllFieldTypeViewModel {
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

  toDisplay(): string {
    return String(NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>8705d1f6efbbdc122bb69a13fde321c0</Hash>
</Codenesium>*/