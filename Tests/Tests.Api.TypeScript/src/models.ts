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
	rowVersion : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.rowVersion = '';
	}
}

export class ApiRowVersionCheckClientResponseModel {
	id : number;
	name : string;
	rowVersion : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.rowVersion = '';
	}
}
export class ApiSelfReferenceClientRequestModel {
	id : number;
	selfReferenceId : number;
	selfReferenceId2 : number;

	constructor() {
		this.id = 0;
		this.selfReferenceId = 0;
		this.selfReferenceId2 = 0;
	}
}

export class ApiSelfReferenceClientResponseModel {
	id : number;
	selfReferenceId : number;
	selfReferenceId2 : number;

	constructor() {
		this.id = 0;
		this.selfReferenceId = 0;
		this.selfReferenceId2 = 0;
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
	fieldBinary : string;
	fieldBit : boolean;
	fieldChar : string;
	fieldDate : string;
	fieldDateTime : string;
	fieldDateTime2 : string;
	fieldDateTimeOffset : string;
	fieldDecimal : number;
	fieldFloat : number;
	fieldImage : any;
	fieldMoney : number;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : number;
	fieldNVarchar : string;
	fieldReal : number;
	fieldSmallDateTime : string;
	fieldSmallInt : number;
	fieldSmallMoney : number;
	fieldText : string;
	fieldTime : string;
	fieldTimestamp : MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
	fieldTinyInt : number;
	fieldUniqueIdentifier : string;
	fieldVarBinary : string;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = 0;
		this.fieldBinary = '';
		this.fieldBit = false;
		this.fieldChar = '';
		this.fieldDate = '';
		this.fieldDateTime = '';
		this.fieldDateTime2 = '';
		this.fieldDateTimeOffset = '';
		this.fieldDecimal = 0;
		this.fieldFloat = 0;
		this.fieldImage = null;
		this.fieldMoney = 0;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = 0;
		this.fieldNVarchar = '';
		this.fieldReal = 0;
		this.fieldSmallDateTime = '';
		this.fieldSmallInt = 0;
		this.fieldSmallMoney = 0;
		this.fieldText = '';
		this.fieldTime = '';
		this.fieldTimestamp = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
		this.fieldTinyInt = 0;
		this.fieldUniqueIdentifier = '';
		this.fieldVarBinary = '';
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}

export class ApiTestAllFieldTypeClientResponseModel {
	fieldBigInt : number;
	fieldBinary : string;
	fieldBit : boolean;
	fieldChar : string;
	fieldDate : string;
	fieldDateTime : string;
	fieldDateTime2 : string;
	fieldDateTimeOffset : string;
	fieldDecimal : number;
	fieldFloat : number;
	fieldImage : any;
	fieldMoney : number;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : number;
	fieldNVarchar : string;
	fieldReal : number;
	fieldSmallDateTime : string;
	fieldSmallInt : number;
	fieldSmallMoney : number;
	fieldText : string;
	fieldTime : string;
	fieldTimestamp : MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
	fieldTinyInt : number;
	fieldUniqueIdentifier : string;
	fieldVarBinary : string;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = 0;
		this.fieldBinary = '';
		this.fieldBit = false;
		this.fieldChar = '';
		this.fieldDate = '';
		this.fieldDateTime = '';
		this.fieldDateTime2 = '';
		this.fieldDateTimeOffset = '';
		this.fieldDecimal = 0;
		this.fieldFloat = 0;
		this.fieldImage = null;
		this.fieldMoney = 0;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = 0;
		this.fieldNVarchar = '';
		this.fieldReal = 0;
		this.fieldSmallDateTime = '';
		this.fieldSmallInt = 0;
		this.fieldSmallMoney = 0;
		this.fieldText = '';
		this.fieldTime = '';
		this.fieldTimestamp = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
		this.fieldTinyInt = 0;
		this.fieldUniqueIdentifier = '';
		this.fieldVarBinary = '';
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}
export class ApiTestAllFieldTypesNullableClientRequestModel {
	fieldBigInt : number;
	fieldBinary : string;
	fieldBit : boolean;
	fieldChar : string;
	fieldDate : string;
	fieldDateTime : string;
	fieldDateTime2 : string;
	fieldDateTimeOffset : string;
	fieldDecimal : number;
	fieldFloat : number;
	fieldImage : any;
	fieldMoney : number;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : number;
	fieldNVarchar : string;
	fieldReal : number;
	fieldSmallDateTime : string;
	fieldSmallInt : number;
	fieldSmallMoney : number;
	fieldText : string;
	fieldTime : string;
	fieldTimestamp : MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
	fieldTinyInt : number;
	fieldUniqueIdentifier : string;
	fieldVarBinary : string;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = 0;
		this.fieldBinary = '';
		this.fieldBit = false;
		this.fieldChar = '';
		this.fieldDate = '';
		this.fieldDateTime = '';
		this.fieldDateTime2 = '';
		this.fieldDateTimeOffset = '';
		this.fieldDecimal = 0;
		this.fieldFloat = 0;
		this.fieldImage = null;
		this.fieldMoney = 0;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = 0;
		this.fieldNVarchar = '';
		this.fieldReal = 0;
		this.fieldSmallDateTime = '';
		this.fieldSmallInt = 0;
		this.fieldSmallMoney = 0;
		this.fieldText = '';
		this.fieldTime = '';
		this.fieldTimestamp = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
		this.fieldTinyInt = 0;
		this.fieldUniqueIdentifier = '';
		this.fieldVarBinary = '';
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}

export class ApiTestAllFieldTypesNullableClientResponseModel {
	fieldBigInt : number;
	fieldBinary : string;
	fieldBit : boolean;
	fieldChar : string;
	fieldDate : string;
	fieldDateTime : string;
	fieldDateTime2 : string;
	fieldDateTimeOffset : string;
	fieldDecimal : number;
	fieldFloat : number;
	fieldImage : any;
	fieldMoney : number;
	fieldNChar : string;
	fieldNText : string;
	fieldNumeric : number;
	fieldNVarchar : string;
	fieldReal : number;
	fieldSmallDateTime : string;
	fieldSmallInt : number;
	fieldSmallMoney : number;
	fieldText : string;
	fieldTime : string;
	fieldTimestamp : MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
	fieldTinyInt : number;
	fieldUniqueIdentifier : string;
	fieldVarBinary : string;
	fieldVarchar : string;
	fieldXML : string;
	id : number;

	constructor() {
		this.fieldBigInt = 0;
		this.fieldBinary = '';
		this.fieldBit = false;
		this.fieldChar = '';
		this.fieldDate = '';
		this.fieldDateTime = '';
		this.fieldDateTime2 = '';
		this.fieldDateTimeOffset = '';
		this.fieldDecimal = 0;
		this.fieldFloat = 0;
		this.fieldImage = null;
		this.fieldMoney = 0;
		this.fieldNChar = '';
		this.fieldNText = '';
		this.fieldNumeric = 0;
		this.fieldNVarchar = '';
		this.fieldReal = 0;
		this.fieldSmallDateTime = '';
		this.fieldSmallInt = 0;
		this.fieldSmallMoney = 0;
		this.fieldText = '';
		this.fieldTime = '';
		this.fieldTimestamp = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
		this.fieldTinyInt = 0;
		this.fieldUniqueIdentifier = '';
		this.fieldVarBinary = '';
		this.fieldVarchar = '';
		this.fieldXML = '';
		this.id = 0;
	}
}
export class ApiTimestampCheckClientRequestModel {
	id : number;
	name : string;
	timestamp : MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;

	constructor() {
		this.id = 0;
		this.name = '';
		this.timestamp = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
	}
}

export class ApiTimestampCheckClientResponseModel {
	id : number;
	name : string;
	timestamp : MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;

	constructor() {
		this.id = 0;
		this.name = '';
		this.timestamp = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping timestamp;
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
    <Hash>09c5c09d13f7c705a4ef30d445ceefd1</Hash>
</Codenesium>*/