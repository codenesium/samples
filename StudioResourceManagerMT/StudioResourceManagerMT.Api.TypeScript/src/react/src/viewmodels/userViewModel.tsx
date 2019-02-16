export default class UserViewModel {
  id: number;
  password: string;
  username: string;

  constructor() {
    this.id = 0;
    this.password = '';
    this.username = '';
  }

  setProperties(
    id: number,
    isDeleted: boolean,
    password: string,
    tenantId: number,
    username: string
  ): void {
    this.id = id;
    this.isDeleted = isDeleted;
    this.password = password;
    this.tenantId = tenantId;
    this.username = username;
  }
}


/*<Codenesium>
    <Hash>76e3491f9bbb21f01bf3ca5adc6cd8a7</Hash>
</Codenesium>*/