import moment from 'moment';
import MessageViewModel from '../message/messageViewModel';
import UserViewModel from '../user/userViewModel';

export default class MessengerViewModel {
  date: any;
  fromUserId: any;
  id: number;
  messageId: any;
  messageIdEntity: string;
  messageIdNavigation?: MessageViewModel;
  time: any;
  toUserId: number;
  toUserIdEntity: string;
  toUserIdNavigation?: UserViewModel;
  userId: any;
  userIdEntity: string;
  userIdNavigation?: UserViewModel;

  constructor() {
    this.date = undefined;
    this.fromUserId = undefined;
    this.id = 0;
    this.messageId = undefined;
    this.messageIdEntity = '';
    this.messageIdNavigation = undefined;
    this.time = undefined;
    this.toUserId = 0;
    this.toUserIdEntity = '';
    this.toUserIdNavigation = undefined;
    this.userId = undefined;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(
    date: any,
    fromUserId: any,
    id: number,
    messageId: any,
    time: any,
    toUserId: number,
    userId: any
  ): void {
    this.date = date;
    this.fromUserId = fromUserId;
    this.id = id;
    this.messageId = messageId;
    this.time = time;
    this.toUserId = toUserId;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>695cdf674047753c91529710fb985c1b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/