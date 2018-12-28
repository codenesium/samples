export class ApiColumnSameAsFKTableClientRequestModel {
	id : number;
	person : number;
	personId : number;

	constructor() {
		this.id = 0;
		this.person = 0;
		this.personId = 0;
	}
}

export class ApiColumnSameAsFKTableClientResponseModel {
	id : number;
	person : number;
	personId : number;

	constructor() {
		this.id = 0;
		this.person = 0;
		this.personId = 0;
	}
}
export class ApiCompositePrimaryKeyClientRequestModel {
	id : number;
	id2 : number;

	constructor() {
		this.id = 0;
		this.id2 = 0;
	}
}

export class ApiCompositePrimaryKeyClientResponseModel {
	id : number;
	id2 : number;

	constructor() {
		this.id = 0;
		this.id2 = 0;
	}
}
export class ApiIncludedColumnTestClientRequestModel {
	id : number;
	name : string;
	name2 : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.name2 = '';
	}
}

export class ApiIncludedColumnTestClientResponseModel {
	id : number;
	name : string;
	name2 : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.name2 = '';
	}
}
export class ApiPersonClientRequestModel {
	personId : number;
	personName : string;

	constructor() {
		this.personId = 0;
		this.personName = '';
	}
}

export class ApiPersonClientResponseModel {
	personId : number;
	personName : string;

	constructor() {
		this.personId = 0;
		this.personName = '';
	}
}
export class ApiRowVersionCheckClientRequestModel {
	id : number;
	name : string;
	rowVersion : any;

	constructor() {
		this.id = 0;
		this.name = '';
		this.rowVersion = null;
	}
}

export class ApiRowVersionCheckClientResponseModel {
	id : number;
	name : string;
	rowVersion : any;

	constructor() {
		this.id = 0;
		this.name = '';
		this.rowVersion = null;
	}
}
export class ApiSelfReferenceClientRequestModel {
	id : number;
	selfReferenceId : any;
	selfReferenceId2 : any;

	constructor() {
		this.id = 0;
		this.selfReferenceId = null;
		this.selfReferenceId2 = null;
	}
}

export class ApiSelfReferenceClientResponseModel {
	id : number;
	selfReferenceId : any;
	selfReferenceId2 : any;

	constructor() {
		this.id = 0;
		this.selfReferenceId = null;
		this.selfReferenceId2 = null;
	}
}
export class ApiTableClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiTableClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiTestAllFieldTypeClientRequestModel {
	fieldBigInt : number;
	fieldBinary : any;
	fieldBit : boolean;
	fieldChar : string;
	fieldDate : any;
	fieldDateTime : any;
	fieldDateTime2 : any;
	fieldDateTimeOffset : any;
	fieldDecimal : number;
	fieldFloat : number;
	fieldImage : any;
	fieldMoney : number;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : number;
	fieldNVarchar : string;
	fieldReal : number;
	fieldSmallDateTime : any;
	fieldSmallInt : number;
	fieldSmallMoney : number;
	fieldText : string;
	fieldTime : any;
	fieldTimestamp : any;
	fieldTinyInt : number;
	fieldUniqueIdentifier : any;
	fieldVarBinary : any;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = 0;
		this.fieldBinary = null;
		this.fieldBit = false;
		this.fieldChar = '';
		this.fieldDate = null;
		this.fieldDateTime = null;
		this.fieldDateTime2 = null;
		this.fieldDateTimeOffset = null;
		this.fieldDecimal = 0;
		this.fieldFloat = 0;
		this.fieldImage = null;
		this.fieldMoney = 0;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = 0;
		this.fieldNVarchar = '';
		this.fieldReal = 0;
		this.fieldSmallDateTime = null;
		this.fieldSmallInt = 0;
		this.fieldSmallMoney = 0;
		this.fieldText = '';
		this.fieldTime = null;
		this.fieldTimestamp = null;
		this.fieldTinyInt = 0;
		this.fieldUniqueIdentifier = null;
		this.fieldVarBinary = null;
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}

export class ApiTestAllFieldTypeClientResponseModel {
	fieldBigInt : number;
	fieldBinary : any;
	fieldBit : boolean;
	fieldChar : string;
	fieldDate : any;
	fieldDateTime : any;
	fieldDateTime2 : any;
	fieldDateTimeOffset : any;
	fieldDecimal : number;
	fieldFloat : number;
	fieldImage : any;
	fieldMoney : number;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : number;
	fieldNVarchar : string;
	fieldReal : number;
	fieldSmallDateTime : any;
	fieldSmallInt : number;
	fieldSmallMoney : number;
	fieldText : string;
	fieldTime : any;
	fieldTimestamp : any;
	fieldTinyInt : number;
	fieldUniqueIdentifier : any;
	fieldVarBinary : any;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = 0;
		this.fieldBinary = null;
		this.fieldBit = false;
		this.fieldChar = '';
		this.fieldDate = null;
		this.fieldDateTime = null;
		this.fieldDateTime2 = null;
		this.fieldDateTimeOffset = null;
		this.fieldDecimal = 0;
		this.fieldFloat = 0;
		this.fieldImage = null;
		this.fieldMoney = 0;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = 0;
		this.fieldNVarchar = '';
		this.fieldReal = 0;
		this.fieldSmallDateTime = null;
		this.fieldSmallInt = 0;
		this.fieldSmallMoney = 0;
		this.fieldText = '';
		this.fieldTime = null;
		this.fieldTimestamp = null;
		this.fieldTinyInt = 0;
		this.fieldUniqueIdentifier = null;
		this.fieldVarBinary = null;
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}
export class ApiTestAllFieldTypesNullableClientRequestModel {
	fieldBigInt : any;
	fieldBinary : any;
	fieldBit : any;
	fieldChar : string;
	fieldDate : any;
	fieldDateTime : any;
	fieldDateTime2 : any;
	fieldDateTimeOffset : any;
	fieldDecimal : any;
	fieldFloat : any;
	fieldImage : any;
	fieldMoney : any;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : any;
	fieldNVarchar : string;
	fieldReal : any;
	fieldSmallDateTime : any;
	fieldSmallInt : any;
	fieldSmallMoney : any;
	fieldText : string;
	fieldTime : any;
	fieldTimestamp : any;
	fieldTinyInt : any;
	fieldUniqueIdentifier : any;
	fieldVarBinary : any;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = null;
		this.fieldBinary = null;
		this.fieldBit = null;
		this.fieldChar = '';
		this.fieldDate = null;
		this.fieldDateTime = null;
		this.fieldDateTime2 = null;
		this.fieldDateTimeOffset = null;
		this.fieldDecimal = null;
		this.fieldFloat = null;
		this.fieldImage = null;
		this.fieldMoney = null;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = null;
		this.fieldNVarchar = '';
		this.fieldReal = null;
		this.fieldSmallDateTime = null;
		this.fieldSmallInt = null;
		this.fieldSmallMoney = null;
		this.fieldText = '';
		this.fieldTime = null;
		this.fieldTimestamp = null;
		this.fieldTinyInt = null;
		this.fieldUniqueIdentifier = null;
		this.fieldVarBinary = null;
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}

export class ApiTestAllFieldTypesNullableClientResponseModel {
	fieldBigInt : any;
	fieldBinary : any;
	fieldBit : any;
	fieldChar : string;
	fieldDate : any;
	fieldDateTime : any;
	fieldDateTime2 : any;
	fieldDateTimeOffset : any;
	fieldDecimal : any;
	fieldFloat : any;
	fieldImage : any;
	fieldMoney : any;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : any;
	fieldNVarchar : string;
	fieldReal : any;
	fieldSmallDateTime : any;
	fieldSmallInt : any;
	fieldSmallMoney : any;
	fieldText : string;
	fieldTime : any;
	fieldTimestamp : any;
	fieldTinyInt : any;
	fieldUniqueIdentifier : any;
	fieldVarBinary : any;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = null;
		this.fieldBinary = null;
		this.fieldBit = null;
		this.fieldChar = '';
		this.fieldDate = null;
		this.fieldDateTime = null;
		this.fieldDateTime2 = null;
		this.fieldDateTimeOffset = null;
		this.fieldDecimal = null;
		this.fieldFloat = null;
		this.fieldImage = null;
		this.fieldMoney = null;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = null;
		this.fieldNVarchar = '';
		this.fieldReal = null;
		this.fieldSmallDateTime = null;
		this.fieldSmallInt = null;
		this.fieldSmallMoney = null;
		this.fieldText = '';
		this.fieldTime = null;
		this.fieldTimestamp = null;
		this.fieldTinyInt = null;
		this.fieldUniqueIdentifier = null;
		this.fieldVarBinary = null;
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}
export class ApiTimestampCheckClientRequestModel {
	id : number;
	name : string;
	timestamp : any;

	constructor() {
		this.id = 0;
		this.name = '';
		this.timestamp = null;
	}
}

export class ApiTimestampCheckClientResponseModel {
	id : number;
	name : string;
	timestamp : any;

	constructor() {
		this.id = 0;
		this.name = '';
		this.timestamp = null;
	}
}
export class ApiVPersonClientRequestModel {
	personId : number;
	personName : string;

	constructor() {
		this.personId = 0;
		this.personName = '';
	}
}

export class ApiVPersonClientResponseModel {
	personId : number;
	personName : string;

	constructor() {
		this.personId = 0;
		this.personName = '';
	}
}
export class ApiSchemaAPersonClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiSchemaAPersonClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiSchemaBPersonClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiSchemaBPersonClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiPersonRefClientRequestModel {
	id : number;
	personAId : number;
	personBId : number;

	constructor() {
		this.id = 0;
		this.personAId = 0;
		this.personBId = 0;
	}
}

export class ApiPersonRefClientResponseModel {
	id : number;
	personAId : number;
	personBId : number;

	constructor() {
		this.id = 0;
		this.personAId = 0;
		this.personBId = 0;
	}
}

/*<Codenesium>
    <Hash>a4086550b281ac3ac05c77ae4b6bafb1</Hash>
</Codenesium>*/