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
    return String();
  }
}


/*<Codenesium>
    <Hash>75e8f4bd18e26674dfc38d5a68e73329</Hash>
</Codenesium>*/