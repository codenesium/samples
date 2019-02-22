import moment from 'moment';
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
    this.retwitterUserIdNavigation = new UserViewModel();
    this.time = undefined;
    this.tweetTweetId = 0;
    this.tweetTweetIdEntity = '';
    this.tweetTweetIdNavigation = new TweetViewModel();
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
    <Hash>788ae40838aec633c535c2d8d8adf13f</Hash>
</Codenesium>*/