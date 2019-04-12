import moment from 'moment';

export default class UserViewModel {
  id: number;
  password: string;
  username: string;

  constructor() {
    this.id = 0;
    this.password = '';
    this.username = '';
  }

  setProperties(id: number, password: string, username: string): void {
    this.id = id;
    this.password = password;
    this.username = username;
  }

  toDisplay(): string {
    return String(this.username);
  }
}


/*<Codenesium>
    <Hash>200831dd610af90fc4cffeb7eaf8819d</Hash>
</Codenesium>*/