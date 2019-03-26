import moment from 'moment';

export default class TestAllFieldTypesNullableViewModel {
  fieldBigInt: any;
  fieldBinary: any;
  fieldBit: boolean;
  fieldChar: string;
  fieldDate: any;
  fieldDateTime: any;
  fieldDateTime2: any;
  fieldDateTimeOffset: any;
  fieldDecimal: number;
  fieldFloat: any;
  fieldImage: any;
  fieldMoney: any;
  fieldNChar: string;
  fieldNText: string;
  fieldNumeric: any;
  fieldNVarchar: string;
  fieldReal: any;
  fieldSmallDateTime: any;
  fieldSmallInt: any;
  fieldSmallMoney: any;
  fieldText: string;
  fieldTime: any;
  fieldTimestamp: any;
  fieldTinyInt: any;
  fieldUniqueIdentifier: any;
  fieldVarBinary: any;
  fieldVarchar: string;
  fieldXML: string;
  id: number;

  constructor() {
    this.fieldBigInt = undefined;
    this.fieldBinary = undefined;
    this.fieldBit = false;
    this.fieldChar = '';
    this.fieldDate = undefined;
    this.fieldDateTime = undefined;
    this.fieldDateTime2 = undefined;
    this.fieldDateTimeOffset = undefined;
    this.fieldDecimal = 0;
    this.fieldFloat = undefined;
    this.fieldImage = undefined;
    this.fieldMoney = undefined;
    this.fieldNChar = '';
    this.fieldNText = '';
    this.fieldNumeric = undefined;
    this.fieldNVarchar = '';
    this.fieldReal = undefined;
    this.fieldSmallDateTime = undefined;
    this.fieldSmallInt = undefined;
    this.fieldSmallMoney = undefined;
    this.fieldText = '';
    this.fieldTime = undefined;
    this.fieldTimestamp = undefined;
    this.fieldTinyInt = undefined;
    this.fieldUniqueIdentifier = undefined;
    this.fieldVarBinary = undefined;
    this.fieldVarchar = '';
    this.fieldXML = '';
    this.id = 0;
  }

  setProperties(
    fieldBigInt: any,
    fieldBinary: any,
    fieldBit: boolean,
    fieldChar: string,
    fieldDate: any,
    fieldDateTime: any,
    fieldDateTime2: any,
    fieldDateTimeOffset: any,
    fieldDecimal: number,
    fieldFloat: any,
    fieldImage: any,
    fieldMoney: any,
    fieldNChar: string,
    fieldNText: string,
    fieldNumeric: any,
    fieldNVarchar: string,
    fieldReal: any,
    fieldSmallDateTime: any,
    fieldSmallInt: any,
    fieldSmallMoney: any,
    fieldText: string,
    fieldTime: any,
    fieldTimestamp: any,
    fieldTinyInt: any,
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
    return String();
  }
}


/*<Codenesium>
    <Hash>40063674fbf516fc1da829c5d0d485b5</Hash>
</Codenesium>*/