import moment from 'moment';
import UserViewModel from '../user/userViewModel';

export default class DirectTweetViewModel {
  content: string;
  date: any;
  taggedUserId: number;
  taggedUserIdEntity: string;
  taggedUserIdNavigation?: UserViewModel;
  time: any;
  tweetId: number;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.taggedUserId = 0;
    this.taggedUserIdEntity = '';
    this.taggedUserIdNavigation = new UserViewModel();
    this.time = undefined;
    this.tweetId = 0;
  }

  setProperties(
    content: string,
    date: any,
    taggedUserId: number,
    time: any,
    tweetId: number
  ): void {
    this.content = content;
    this.date = date;
    this.taggedUserId = taggedUserId;
    this.time = time;
    this.tweetId = tweetId;
  }

  toDisplay(): string {
    return String(this.content);
  }
}


/*<Codenesium>
    <Hash>bbcb51d594dcb564fbf270c214a9c1e4</Hash>
</Codenesium>*/