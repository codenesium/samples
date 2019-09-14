import moment from 'moment';
import LocationViewModel from '../location/locationViewModel';

export default class UserViewModel {
  bioImgUrl: string;
  birthday: any;
  contentDescription: string;
  email: string;
  fullName: string;
  headerImgUrl: string;
  interest: string;
  locationLocationId: number;
  locationLocationIdEntity: string;
  locationLocationIdNavigation?: LocationViewModel;
  password: string;
  phoneNumber: string;
  privacy: string;
  userId: number;
  username: string;
  website: string;

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
    this.locationLocationIdNavigation = undefined;
    this.password = '';
    this.phoneNumber = '';
    this.privacy = '';
    this.userId = 0;
    this.username = '';
    this.website = '';
  }

  setProperties(
    bioImgUrl: string,
    birthday: any,
    contentDescription: string,
    email: string,
    fullName: string,
    headerImgUrl: string,
    interest: string,
    locationLocationId: number,
    password: string,
    phoneNumber: string,
    privacy: string,
    userId: number,
    username: string,
    website: string
  ): void {
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

  toDisplay(): string {
    return String(this.username);
  }
}


/*<Codenesium>
    <Hash>265b8ec8dda0f0bee44e098cd1db28b3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/