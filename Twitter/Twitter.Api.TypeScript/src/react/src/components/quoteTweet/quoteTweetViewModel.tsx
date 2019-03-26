import moment from 'moment';
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
    return String(this.quoteTweetId);
  }
}


/*<Codenesium>
    <Hash>d78ea96ecdf29a67acd19dcdb3ab2f8d</Hash>
</Codenesium>*/