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
    this.largePhoto = moment(largePhoto, 'YYYY-MM-DD');
    this.largePhotoFileName = moment(largePhotoFileName, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.productPhotoID = moment(productPhotoID, 'YYYY-MM-DD');
    this.thumbNailPhoto = moment(thumbNailPhoto, 'YYYY-MM-DD');
    this.thumbnailPhotoFileName = moment(thumbnailPhotoFileName, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>3d847756a6f54cde24871d7122026025</Hash>
</Codenesium>*/