import moment from 'moment';
import UserViewModel from '../user/userViewModel';

export default class BadgeViewModel {
  date: any;
  id: number;
  name: string;
  userId: number;
  userIdEntity: string;
  userIdNavigation?: UserViewModel;

  constructor() {
    this.date = undefined;
    this.id = 0;
    this.name = '';
    this.userId = 0;
    this.userIdEntity = '';
    this.userIdNavigation = undefined;
  }

  setProperties(date: any, id: number, name: string, userId: number): void {
    this.date = moment(date, 'YYYY-MM-DD');
    this.id = id;
    this.name = name;
    this.userId = userId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>18f1409ed8143dd8f79511709d7c0898</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/