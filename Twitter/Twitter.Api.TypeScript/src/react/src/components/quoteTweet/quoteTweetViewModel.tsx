import UserViewModel from '../user/userViewModel';
import TweetViewModel from '../tweet/tweetViewModel';

export default class QuoteTweetViewModel {
  content: string;
  date: any;
  quoteTweetId: number;
  retweeterUserId: number;
  retweeterUserIdEntity: string;
  retweeterUserIdNavigation?: UserViewModel;
  sourceTweetId: number;
  sourceTweetIdEntity: string;
  sourceTweetIdNavigation?: TweetViewModel;
  time: any;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.quoteTweetId = 0;
    this.retweeterUserId = 0;
    this.retweeterUserIdEntity = '';
    this.retweeterUserIdNavigation = undefined;
    this.sourceTweetId = 0;
    this.sourceTweetIdEntity = '';
    this.sourceTweetIdNavigation = undefined;
    this.time = undefined;
  }

  setProperties(
    content: string,
    date: any,
    quoteTweetId: number,
    retweeterUserId: number,
    sourceTweetId: number,
    time: any
  ): void {
    this.content = content;
    this.date = date;
    this.quoteTweetId = quoteTweetId;
    this.retweeterUserId = retweeterUserId;
    this.sourceTweetId = sourceTweetId;
    this.time = time;
  }

  toDisplay(): string {
    return String(NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>3be6522c957c0fd10240e6f141bf3b63</Hash>
</Codenesium>*/