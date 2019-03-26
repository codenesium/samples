export default class ChangePasswordViewModel {
  currentPassword: string;
  newPassword: string;

  constructor() {
    this.currentPassword = '';
    this.newPassword = '';
  }

  setProperties(
    currentPassword:string,
    newPassword:string
  ): void {
    this.currentPassword = currentPassword;
    this.newPassword = newPassword
  }

  toDisplay(): string {
    return '';
  }
}