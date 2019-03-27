export default class ResetPasswordViewModel {
  email: string;

  constructor() {
    this.email = '';
  }

  setProperties(
    email:string
  ): void {
    this.email = email;
  }

  toDisplay(): string {
    return String(this.email);
  }
}