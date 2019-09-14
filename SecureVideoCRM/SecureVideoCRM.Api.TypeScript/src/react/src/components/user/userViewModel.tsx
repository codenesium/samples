import moment from 'moment';

export default class UserViewModel {
  email: string;
  id: number;
  password: string;
  stripeCustomerId: string;
  subscriptionTypeId: number;

  constructor() {
    this.email = '';
    this.id = 0;
    this.password = '';
    this.stripeCustomerId = '';
    this.subscriptionTypeId = 0;
  }

  setProperties(
    email: string,
    id: number,
    password: string,
    stripeCustomerId: string,
    subscriptionTypeId: number
  ): void {
    this.email = email;
    this.id = id;
    this.password = password;
    this.stripeCustomerId = stripeCustomerId;
    this.subscriptionTypeId = subscriptionTypeId;
  }

  toDisplay(): string {
    return String(this.email);
  }
}


/*<Codenesium>
    <Hash>a9faedde0f6e5d8ef929a7cfebf18930</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/