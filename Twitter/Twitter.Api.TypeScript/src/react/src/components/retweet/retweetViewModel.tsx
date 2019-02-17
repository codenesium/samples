import UserViewModel from '../user/userViewModel';
import TweetViewModel from '../tweet/tweetViewModel';

export default class RetweetViewModel {
  date: any;
  id: number;
  retwitterUserId: any;
  retwitterUserIdEntity: string;
  retwitterUserIdNavigation?: UserViewModel;
  time: any;
  tweetTweetId: number;
  tweetTweetIdEntity: string;
  tweetTweetIdNavigation?: TweetViewModel;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.retwitterUserId = undefined;
    this.retwitterUserIdEntity = '';
    this.retwitterUserIdNavigation = undefined;
    this.time = undefined;
    this.tweetTweetId = 0;
    this.tweetTweetIdEntity = '';
    this.tweetTweetIdNavigation = undefined;
  }

  setProperties(
    date: any,
    id: number,
    retwitterUserId: any,
    time: any,
    tweetTweetId: number
  ): void {
    this.date = date;
    this.id = id;
    this.retwitterUserId = retwitterUserId;
    this.time = time;
    this.tweetTweetId = tweetTweetId;
  }

  toDisplay(): string {
    return String(NULL_STRING_PASSED_ToLowerCaseFirstLetter);
  }
}


/*<Codenesium>
    <Hash>bb40a771f2715a7a969109a01e367cd0</Hash>
</Codenesium>*/