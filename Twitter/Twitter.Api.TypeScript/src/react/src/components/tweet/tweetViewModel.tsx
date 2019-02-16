import LocationViewModel from '../location/locationViewModel';
import UserViewModel from '../user/userViewModel';

export default class TweetViewModel {
  content: string;
  date: any;
  locationId: number;
  locationIdEntity: string;
  locationIdNavigation?: LocationViewModel;
  time: any;
  tweetId: number;
  userUserId: number;
  userUserIdEntity: string;
  userUserIdNavigation?: UserViewModel;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.locationId = 0;
    this.locationIdEntity = '';
    this.locationIdNavigation = undefined;
    this.time = undefined;
    this.tweetId = 0;
    this.userUserId = 0;
    this.userUserIdEntity = '';
    this.userUserIdNavigation = undefined;
  }

  setProperties(
    content: string,
    date: any,
    locationId: number,
    time: any,
    tweetId: number,
    userUserId: number
  ): void {
    this.content = content;
    this.date = date;
    this.locationId = locationId;
    this.time = time;
    this.tweetId = tweetId;
    this.userUserId = userUserId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>381ab874026ac258e26d4a7fa16bfd5d</Hash>
</Codenesium>*/