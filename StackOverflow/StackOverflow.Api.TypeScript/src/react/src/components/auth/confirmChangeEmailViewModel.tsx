export default class ConfirmChangeEmailViewModel {
  token: string;
 
  constructor() {
    this.token = '';
  }

  setProperties(
    token:string,
  ): void {
    this.token = token;
  }

  toDisplay(): string {
    return '';
  }
}