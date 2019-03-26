export class BucketClientRequestModel {
  externalId: any;
  id: number;
  name: string;

  constructor() {
    this.externalId = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(externalId: any, id: number, name: string): void {
    this.externalId = externalId;
    this.id = id;
    this.name = name;
  }
}

export class BucketClientResponseModel {
  externalId: any;
  id: number;
  name: string;

  constructor() {
    this.externalId = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(externalId: any, id: number, name: string): void {
    this.externalId = externalId;
    this.id = id;
    this.name = name;
  }
}
export class FileClientRequestModel {
  bucketId: number;
  bucketIdEntity: string;
  bucketIdNavigation?: BucketClientResponseModel;
  dateCreated: any;
  description: string;
  expiration: any;
  extension: string;
  externalId: any;
  fileSizeInByte: number;
  fileTypeId: number;
  fileTypeIdEntity: string;
  fileTypeIdNavigation?: FileTypeClientResponseModel;
  id: number;
  location: string;
  privateKey: string;
  publicKey: string;

  constructor() {
    this.bucketId = 0;
    this.bucketIdEntity = '';
    this.bucketIdNavigation = undefined;
    this.dateCreated = undefined;
    this.description = '';
    this.expiration = undefined;
    this.extension = '';
    this.externalId = undefined;
    this.fileSizeInByte = 0;
    this.fileTypeId = 0;
    this.fileTypeIdEntity = '';
    this.fileTypeIdNavigation = undefined;
    this.id = 0;
    this.location = '';
    this.privateKey = '';
    this.publicKey = '';
  }

  setProperties(
    bucketId: number,
    dateCreated: any,
    description: string,
    expiration: any,
    extension: string,
    externalId: any,
    fileSizeInByte: number,
    fileTypeId: number,
    id: number,
    location: string,
    privateKey: string,
    publicKey: string
  ): void {
    this.bucketId = bucketId;
    this.dateCreated = dateCreated;
    this.description = description;
    this.expiration = expiration;
    this.extension = extension;
    this.externalId = externalId;
    this.fileSizeInByte = fileSizeInByte;
    this.fileTypeId = fileTypeId;
    this.id = id;
    this.location = location;
    this.privateKey = privateKey;
    this.publicKey = publicKey;
  }
}

export class FileClientResponseModel {
  bucketId: number;
  bucketIdEntity: string;
  bucketIdNavigation?: BucketClientResponseModel;
  dateCreated: any;
  description: string;
  expiration: any;
  extension: string;
  externalId: any;
  fileSizeInByte: number;
  fileTypeId: number;
  fileTypeIdEntity: string;
  fileTypeIdNavigation?: FileTypeClientResponseModel;
  id: number;
  location: string;
  privateKey: string;
  publicKey: string;

  constructor() {
    this.bucketId = 0;
    this.bucketIdEntity = '';
    this.bucketIdNavigation = undefined;
    this.dateCreated = undefined;
    this.description = '';
    this.expiration = undefined;
    this.extension = '';
    this.externalId = undefined;
    this.fileSizeInByte = 0;
    this.fileTypeId = 0;
    this.fileTypeIdEntity = '';
    this.fileTypeIdNavigation = undefined;
    this.id = 0;
    this.location = '';
    this.privateKey = '';
    this.publicKey = '';
  }

  setProperties(
    bucketId: number,
    dateCreated: any,
    description: string,
    expiration: any,
    extension: string,
    externalId: any,
    fileSizeInByte: number,
    fileTypeId: number,
    id: number,
    location: string,
    privateKey: string,
    publicKey: string
  ): void {
    this.bucketId = bucketId;
    this.dateCreated = dateCreated;
    this.description = description;
    this.expiration = expiration;
    this.extension = extension;
    this.externalId = externalId;
    this.fileSizeInByte = fileSizeInByte;
    this.fileTypeId = fileTypeId;
    this.id = id;
    this.location = location;
    this.privateKey = privateKey;
    this.publicKey = publicKey;
  }
}
export class FileTypeClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class FileTypeClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>ade7887d6c1fb7447552c08e74efe908</Hash>
</Codenesium>*/