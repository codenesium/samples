import moment from 'moment';

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
    this.fieldDate = moment(fieldDate, 'YYYY-MM-DD');
    this.fieldDateTime = moment(fieldDateTime, 'YYYY-MM-DD');
    this.fieldDateTime2 = moment(fieldDateTime2, 'YYYY-MM-DD');
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
    this.fieldSmallDateTime = moment(fieldSmallDateTime, 'YYYY-MM-DD');
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
    return String(this.fieldBigInt);
  }
}


/*<Codenesium>
    <Hash>f31612ea4638fd2b37e318c5d707c8e5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/