export default class ChangeEmailViewModel {
  password: string;
  newEmail: string;

  constructor() {
    this.password = '';
    this.newEmail = '';
  }

  setProperties(
    password:string,
    newEmail:string
  ): void {
    this.password = password;
    this.newEmail = newEmail
  }

  toDisplay(): string {
    return '';
  }
}