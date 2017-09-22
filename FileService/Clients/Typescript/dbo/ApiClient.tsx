export class ReferenceEntity<T> {
    ReferenceObjectName:string;
    Value :T;
    Href:string;
}export class ApiBucketModel {
    externalId:any;
id:number;
name:string;

	
    constructor() {
		this.externalId = "00000000-0000-0000-0000-000000000000";
this.id = 0;
this.name = '';

		
    }
};export class ApiFileModel {
    bucketId:ReferenceEntity<number>;
dateCreated:string;
description:string;
expiration:string;
extension:string;
externalId:any;
fileSizeInBytes:number;
fileTypeId:ReferenceEntity<number>;
id:number;
location:string;
privateKey:string;
publicKey:string;

	
    constructor() {
		this.bucketId = new ReferenceEntity<number>();
this.dateCreated = '';
this.description = '';
this.expiration = '';
this.extension = '';
this.externalId = "00000000-0000-0000-0000-000000000000";
this.fileSizeInBytes = 0;
this.fileTypeId = new ReferenceEntity<number>();
this.id = 0;
this.location = '';
this.privateKey = '';
this.publicKey = '';

		
    }
};export class ApiFileTypeModel {
    id:number;
name:string;

	
    constructor() {
		this.id = 0;
this.name = '';

		
    }
};export class Response {
	buckets : Array<ApiBucketModel>;
		files : Array<ApiFileModel>;
		fileTypes : Array<ApiFileTypeModel>;
	}