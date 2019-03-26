export default class LoginViewModel {
  email: string;
  password: string;

  constructor() {
    this.email = '';
    this.password = '';
  }

  setProperties(
    email:string, 
    password:string
  ): void {
    this.email = email;
    this.password = password;
  }

  toDisplay(): string {
    return String(this.email);
  }
}