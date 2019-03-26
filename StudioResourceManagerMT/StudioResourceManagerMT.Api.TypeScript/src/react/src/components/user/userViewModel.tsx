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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>870fe3114aa03314688c49a7ce00b2ab</Hash>
</Codenesium>*/