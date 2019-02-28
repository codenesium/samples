import moment from 'moment';
import UserViewModel from '../user/userViewModel';

export default class MessageViewModel {
  content: string;
  messageId: number;
  senderUserId: any;
  senderUserIdEntity: string;
  senderUserIdNavigation?: UserViewModel;

  constructor() {
    this.content = '';
    this.messageId = 0;
    this.senderUserId = undefined;
    this.senderUserIdEntity = '';
    this.senderUserIdNavigation = new UserViewModel();
  }

  setProperties(content: string, messageId: number, senderUserId: any): void {
    this.content = content;
    this.messageId = messageId;
    this.senderUserId = senderUserId;
  }

  toDisplay(): string {
    return String(this.content);
  }
}


/*<Codenesium>
    <Hash>62adca5d9d0617144a2a179414569540</Hash>
</Codenesium>*/