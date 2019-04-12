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
    this.senderUserIdNavigation = undefined;
  }

  setProperties(content: string, messageId: number, senderUserId: any): void {
    this.content = content;
    this.messageId = messageId;
    this.senderUserId = senderUserId;
  }

  toDisplay(): string {
    return String(this.messageId);
  }
}


/*<Codenesium>
    <Hash>6f3c04e96032683b408e65d58f17a6d9</Hash>
</Codenesium>*/