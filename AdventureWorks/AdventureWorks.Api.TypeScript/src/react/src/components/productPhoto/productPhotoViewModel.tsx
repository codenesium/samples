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
    this.modifiedDate = modifiedDate;
    this.productPhotoID = productPhotoID;
    this.thumbNailPhoto = thumbNailPhoto;
    this.thumbnailPhotoFileName = thumbnailPhotoFileName;
  }
}


/*<Codenesium>
    <Hash>2f2167b5a7c78c2f90bf5d070c837d00</Hash>
</Codenesium>*/