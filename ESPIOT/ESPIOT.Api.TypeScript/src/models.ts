export class ApiEfmigrationshistoryClientRequestModel {
	migrationId : string;
	productVersion : string;

	constructor() {
		this.migrationId = '';
		this.productVersion = '';
	}
}

export class ApiEfmigrationshistoryClientResponseModel {
	migrationId : string;
	productVersion : string;

	constructor() {
		this.migrationId = '';
		this.productVersion = '';
	}
}
export class ApiDeviceClientRequestModel {
	id : number;
	name : string;
	publicId : any;

	constructor() {
		this.id = 0;
		this.name = '';
		this.publicId = null;
	}
}

export class ApiDeviceClientResponseModel {
	id : number;
	name : string;
	publicId : any;

	constructor() {
		this.id = 0;
		this.name = '';
		this.publicId = null;
	}
}
export class ApiDeviceActionClientRequestModel {
	deviceId : number;
	deviceIdEntity : string;
	id : number;
	name : string;
	value : string;

	constructor() {
		this.deviceId = 0;
		this.deviceIdEntity = '';
		this.id = 0;
		this.name = '';
		this.value = '';
	}
}

export class ApiDeviceActionClientResponseModel {
	deviceId : number;
	deviceIdEntity : string;
	id : number;
	name : string;
	value : string;

	constructor() {
		this.deviceId = 0;
		this.deviceIdEntity = '';
		this.id = 0;
		this.name = '';
		this.value = '';
	}
}

/*<Codenesium>
    <Hash>a2ea1f71de142a74de014c1cd4239c38</Hash>
</Codenesium>*/