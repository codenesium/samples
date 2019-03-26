import moment from 'moment';

export default class ProductPhotoViewModel {
  largePhoto: any;
  largePhotoFileName: string;
  modifiedDate: any;
  productPhotoID: number;
  thumbNailPhoto: any;
  thumbnailPhotoFileName: string;

  constructor() {
    this.largePhoto = undefined;
    this.largePhotoFileName = '';
    this.modifiedDate = undefined;
    this.productPhotoID = 0;
    this.thumbNailPhoto = undefined;
    this.thumbnailPhotoFileName = '';
  }

  setProperties(
    largePhoto: any,
    largePhotoFileName: string,
    modifiedDate: any,
    productPhotoID: number,
    thumbNailPhoto: any,
    thumbnailPhotoFileName: string
  ): void {
    this.largePhoto = largePhoto;
    this.largePhotoFileName = largePhotoFileName;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productPhotoID = productPhotoID;
    this.thumbNailPhoto = thumbNailPhoto;
    this.thumbnailPhotoFileName = thumbnailPhotoFileName;
  }

  toDisplay(): string {
    return String(this.largePhoto);
  }
}


/*<Codenesium>
    <Hash>286719bfd1f57318a29b7d4402bd0e8a</Hash>
</Codenesium>*/