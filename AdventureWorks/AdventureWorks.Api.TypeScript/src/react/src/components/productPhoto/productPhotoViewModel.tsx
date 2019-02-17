export default class ProductPhotoViewModel {
    largePhoto:any;
largePhotoFileName:string;
modifiedDate:any;
productPhotoID:number;
thumbNailPhoto:any;
thumbnailPhotoFileName:string;

    constructor() {
		this.largePhoto = undefined;
this.largePhotoFileName = '';
this.modifiedDate = undefined;
this.productPhotoID = 0;
this.thumbNailPhoto = undefined;
this.thumbnailPhotoFileName = '';

    }

	setProperties(largePhoto : any,largePhotoFileName : string,modifiedDate : any,productPhotoID : number,thumbNailPhoto : any,thumbnailPhotoFileName : string) : void
	{
		this.largePhoto = largePhoto;
this.largePhotoFileName = largePhotoFileName;
this.modifiedDate = modifiedDate;
this.productPhotoID = productPhotoID;
this.thumbNailPhoto = thumbNailPhoto;
this.thumbnailPhotoFileName = thumbnailPhotoFileName;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>c942ea538471dd67d9746517a76d2fe9</Hash>
</Codenesium>*/