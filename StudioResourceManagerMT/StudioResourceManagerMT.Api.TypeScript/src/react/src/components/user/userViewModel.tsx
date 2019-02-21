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
    this.password = moment(password, 'YYYY-MM-DD');
    this.username = moment(username, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>063d77832e1026311719289552a9e4ce</Hash>
</Codenesium>*/