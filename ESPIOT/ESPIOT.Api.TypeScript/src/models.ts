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
    <Hash>1b0b644b5a19b985a1e5979e2fce959d</Hash>
</Codenesium>*/