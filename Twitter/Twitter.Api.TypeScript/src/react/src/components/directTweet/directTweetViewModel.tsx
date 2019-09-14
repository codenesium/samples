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
    this.taggedUserIdNavigation = undefined;
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
    this.date = moment(date, 'YYYY-MM-DD');
    this.taggedUserId = taggedUserId;
    this.time = time;
    this.tweetId = tweetId;
  }

  toDisplay(): string {
    return String(this.tweetId);
  }
}


/*<Codenesium>
    <Hash>d211170fec2e1397c08a8f6a7c430787</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/