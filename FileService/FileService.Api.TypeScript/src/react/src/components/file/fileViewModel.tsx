import moment from 'moment';
import BucketViewModel from '../bucket/bucketViewModel';
import FileTypeViewModel from '../fileType/fileTypeViewModel';

export default class FileViewModel {
  bucketId: number;
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
    this.dateCreated = moment(dateCreated, 'YYYY-MM-DD');
    this.description = description;
    this.expiration = moment(expiration, 'YYYY-MM-DD');
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
    return String(this.externalId);
  }
}


/*<Codenesium>
    <Hash>196aaf0bd2cc215820dabf526b892c8c</Hash>
</Codenesium>*/