export class ApiBucketClientRequestModel {
	externalId : string;
	id : number;
	name : string;

	constructor() {
		this.externalId = '';
		this.id = 0;
		this.name = '';
	}
}

export class ApiBucketClientResponseModel {
	externalId : string;
	id : number;
	name : string;

	constructor() {
		this.externalId = '';
		this.id = 0;
		this.name = '';
	}
}
export class ApiFileClientRequestModel {
	bucketId : number;
	bucketIdEntity : string;
	dateCreated : string;
	description : string;
	expiration : string;
	extension : string;
	externalId : string;
	fileSizeInByte : number;
	fileTypeId : number;
	fileTypeIdEntity : string;
	id : number;
	location : string;
	privateKey : string;
	publicKey : string;

	constructor() {
		this.bucketId = 0;
		this.bucketIdEntity = '';
		this.dateCreated = '';
		this.description = '';
		this.expiration = '';
		this.extension = '';
		this.externalId = '';
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
	bucketId : number;
	bucketIdEntity : string;
	dateCreated : string;
	description : string;
	expiration : string;
	extension : string;
	externalId : string;
	fileSizeInByte : number;
	fileTypeId : number;
	fileTypeIdEntity : string;
	id : number;
	location : string;
	privateKey : string;
	publicKey : string;

	constructor() {
		this.bucketId = 0;
		this.bucketIdEntity = '';
		this.dateCreated = '';
		this.description = '';
		this.expiration = '';
		this.extension = '';
		this.externalId = '';
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
    <Hash>34110dbd9c32f2d342d73caa0bc935ea</Hash>
</Codenesium>*/