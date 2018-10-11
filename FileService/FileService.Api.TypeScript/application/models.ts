export class ApiBucketRequestModel {
				externalId:string;
id:number;
name:string;

	
				constructor() {
					this.externalId = '';
this.id = 0;
this.name = '';

		
				}
			}

			export class ApiBucketResponseModel {
				externalId:string;
id:number;
name:string;

	
				constructor() {
					this.externalId = '';
this.id = 0;
this.name = '';

		
				}
			}
			export class ApiFileRequestModel {
				bucketId:number;
bucketIdEntity:number;
dateCreated:string;
description:string;
expiration:string;
extension:string;
externalId:string;
fileSizeInByte:number;
fileTypeId:number;
fileTypeIdEntity:number;
id:number;
location:string;
privateKey:string;
publicKey:string;

	
				constructor() {
					this.bucketId = 0;
this.dateCreated = '';
this.description = '';
this.expiration = '';
this.extension = '';
this.externalId = '';
this.fileSizeInByte = 0;
this.fileTypeId = 0;
this.id = 0;
this.location = '';
this.privateKey = '';
this.publicKey = '';

		
				}
			}

			export class ApiFileResponseModel {
				bucketId:number;
bucketIdEntity:number;
dateCreated:string;
description:string;
expiration:string;
extension:string;
externalId:string;
fileSizeInByte:number;
fileTypeId:number;
fileTypeIdEntity:number;
id:number;
location:string;
privateKey:string;
publicKey:string;

	
				constructor() {
					this.bucketId = 0;
this.dateCreated = '';
this.description = '';
this.expiration = '';
this.extension = '';
this.externalId = '';
this.fileSizeInByte = 0;
this.fileTypeId = 0;
this.id = 0;
this.location = '';
this.privateKey = '';
this.publicKey = '';

		
				}
			}
			export class ApiFileTypeRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiFileTypeResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}