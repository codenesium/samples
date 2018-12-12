export class ApiBucketClientRequestModel {
	externalId : any;
	id : number;
	name : string;

	constructor() {
		this.externalId = null;
		this.id = 0;
		this.name = '';
	}
}

export class ApiBucketClientResponseModel {
	externalId : any;
	id : number;
	name : string;

	constructor() {
		this.externalId = null;
		this.id = 0;
		this.name = '';
	}
}
export class ApiFileClientRequestModel {
	bucketId : any;
	bucketIdEntity : string;
	dateCreated : any;
	description : string;
	expiration : any;
	extension : string;
	externalId : any;
	fileSizeInByte : number;
	fileTypeId : number;
	fileTypeIdEntity : string;
	id : number;
	location : string;
	privateKey : string;
	publicKey : string;

	constructor() {
		this.bucketId = null;
		this.bucketIdEntity = '';
		this.dateCreated = null;
		this.description = '';
		this.expiration = null;
		this.extension = '';
		this.externalId = null;
		this.fileSizeInByte = 0;
		this.fileTypeId = 0;
		this.fileTypeIdEntity = '';
		this.id = 0;
		this.location = '';
		this.privateKey = '';
		this.publicKey = '';
	}
}

export class ApiFileClientResponseModel {
	bucketId : any;
	bucketIdEntity : string;
	dateCreated : any;
	description : string;
	expiration : any;
	extension : string;
	externalId : any;
	fileSizeInByte : number;
	fileTypeId : number;
	fileTypeIdEntity : string;
	id : number;
	location : string;
	privateKey : string;
	publicKey : string;

	constructor() {
		this.bucketId = null;
		this.bucketIdEntity = '';
		this.dateCreated = null;
		this.description = '';
		this.expiration = null;
		this.extension = '';
		this.externalId = null;
		this.fileSizeInByte = 0;
		this.fileTypeId = 0;
		this.fileTypeIdEntity = '';
		this.id = 0;
		this.location = '';
		this.privateKey = '';
		this.publicKey = '';
	}
}
export class ApiFileTypeClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiFileTypeClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

/*<Codenesium>
    <Hash>8cd49c90e2f1b8faecd6570da0e22adf</Hash>
</Codenesium>*/