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
    return String();
  }
}


/*<Codenesium>
    <Hash>94baf2a33301664b40502edd9024d374</Hash>
</Codenesium>*/