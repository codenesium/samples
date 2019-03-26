import moment from 'moment';
import UserViewModel from '../user/userViewModel';

export default class ReplyViewModel {
  content: string;
  date: any;
  replierUserId: number;
  replierUserIdEntity: string;
  replierUserIdNavigation?: UserViewModel;
  replyId: number;
  time: any;

  constructor() {
    this.content = '';
    this.date = undefined;
    this.replierUserId = 0;
    this.replierUserIdEntity = '';
    this.replierUserIdNavigation = undefined;
    this.replyId = 0;
    this.time = undefined;
  }

  setProperties(
    content: string,
    date: any,
    replierUserId: number,
    replyId: number,
    time: any
  ): void {
    this.content = content;
    this.date = date;
    this.replierUserId = replierUserId;
    this.replyId = replyId;
    this.time = time;
  }

  toDisplay(): string {
    return String(this.date);
  }
}


/*<Codenesium>
    <Hash>a3cb5209f386770ad133348db521d43f</Hash>
</Codenesium>*/