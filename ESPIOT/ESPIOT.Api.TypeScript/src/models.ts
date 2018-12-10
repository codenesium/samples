export class ApiDeviceClientRequestModel {
	id : MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
	name : MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
	publicId : MAPPING_NOT_FOUND_MapContainer->GetMapping uuid;

	constructor() {
		this.id = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
		this.name = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
		this.publicId = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping uuid;
	}
}

export class ApiDeviceClientResponseModel {
	id : MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
	name : MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
	publicId : MAPPING_NOT_FOUND_MapContainer->GetMapping uuid;

	constructor() {
		this.id = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
		this.name = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
		this.publicId = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping uuid;
	}
}
export class ApiDeviceActionClientRequestModel {
	deviceId : MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
	deviceIdEntity : string;
	id : MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
	name : MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
	value : MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;

	constructor() {
		this.deviceId = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
		this.deviceIdEntity = '';
		this.id = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
		this.name = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
		this.value = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
	}
}

export class ApiDeviceActionClientResponseModel {
	deviceId : MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
	deviceIdEntity : string;
	id : MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
	name : MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
	value : MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;

	constructor() {
		this.deviceId = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
		this.deviceIdEntity = '';
		this.id = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping integer;
		this.name = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
		this.value = UNKNOWN_FILE_TYPE_MAPPING_NOT_FOUND_MapContainer->GetMapping character varying;
	}
}

/*<Codenesium>
    <Hash>453a9444e9ddd67862f0230654ca710c</Hash>
</Codenesium>*/