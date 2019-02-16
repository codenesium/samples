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
    return String(this.content);
  }
}


/*<Codenesium>
    <Hash>766fa299d81ae598d83090d6c4551e24</Hash>
</Codenesium>*/