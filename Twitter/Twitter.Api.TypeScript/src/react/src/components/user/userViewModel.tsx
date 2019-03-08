import moment from 'moment'
import LocationViewModel from '../location/locationViewModel'
	

export default class UserViewModel {
    bioImgUrl:string;
birthday:any;
contentDescription:string;
email:string;
fullName:string;
headerImgUrl:string;
interest:string;
locationLocationId:number;
locationLocationIdEntity : string;
locationLocationIdNavigation? : LocationViewModel;
password:string;
phoneNumber:string;
privacy:string;
userId:number;
username:string;
website:string;

    constructor() {
		this.bioImgUrl = '';
this.birthday = undefined;
this.contentDescription = '';
this.email = '';
this.fullName = '';
this.headerImgUrl = '';
this.interest = '';
this.locationLocationId = 0;
this.locationLocationIdEntity = '';
this.locationLocationIdNavigation = new LocationViewModel();
this.password = '';
this.phoneNumber = '';
this.privacy = '';
this.userId = 0;
this.username = '';
this.website = '';

    }

	setProperties(bioImgUrl : string,birthday : any,contentDescription : string,email : string,fullName : string,headerImgUrl : string,interest : string,locationLocationId : number,password : string,phoneNumber : string,privacy : string,userId : number,username : string,website : string) : void
	{
		this.bioImgUrl = bioImgUrl;
this.birthday = birthday;
this.contentDescription = contentDescription;
this.email = email;
this.fullName = fullName;
this.headerImgUrl = headerImgUrl;
this.interest = interest;
this.locationLocationId = locationLocationId;
this.password = password;
this.phoneNumber = phoneNumber;
this.privacy = privacy;
this.userId = userId;
this.username = username;
this.website = website;

	}

	toDisplay() : string
	{
		return String(this.bio_img_url);
	}
};

/*<Codenesium>
    <Hash>ae9626b31ec71878b261a7a75f7fffa0</Hash>
</Codenesium>*/