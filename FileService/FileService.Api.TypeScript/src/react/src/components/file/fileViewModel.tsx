import BucketViewModel from '../bucket/bucketViewModel';
import FileTypeViewModel from '../fileType/fileTypeViewModel';

export default class FileViewModel {
  bucketId: any;
  bucketIdEntity: string;
  bucketIdNavigation?: BucketViewModel;
  dateCreated: any;
  description: string;
  expiration: any;
  extension: string;
  externalId: any;
  fileSizeInByte: number;
  fileTypeId: number;
  fileTypeIdEntity: string;
  fileTypeIdNavigation?: FileTypeViewModel;
  id: number;
  location: string;
  privateKey: string;
  publicKey: string;

  constructor() {
    this.bucketId = undefined;
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
    bucketId: any,
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

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>3b3ae98dccc0dda5572d958cfe682d53</Hash>
</Codenesium>*/