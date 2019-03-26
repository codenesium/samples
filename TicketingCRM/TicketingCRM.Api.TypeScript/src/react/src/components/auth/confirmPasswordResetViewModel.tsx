export default class ConfirmPasswordResetViewModel {
  newPassword: string;
  id:string;
  token:string;

  constructor() {
    this.newPassword = '';
    this.id= '';
    this.token = '';

  }

  setProperties(
    id:string,
    newPassword:string,
    token:string
  ): void {
    this.newPassword = newPassword;
    this.id = id;
    this.token = token;
  }

  toDisplay(): string {
    return String(this.newPassword);
  }
}