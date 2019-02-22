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
    this.id = moment(id, 'YYYY-MM-DD');
    this.password = password;
    this.username = username;
  }

  toDisplay(): string {
    return String(this.username);
  }
}


/*<Codenesium>
    <Hash>b8bfc0a77eeed2d382435d2405838786</Hash>
</Codenesium>*/