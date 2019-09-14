import moment from 'moment';

export default class SubscriptionViewModel {
  id: number;
  name: string;
  stripePlanName: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.stripePlanName = '';
  }

  setProperties(id: number, name: string, stripePlanName: string): void {
    this.id = id;
    this.name = name;
    this.stripePlanName = stripePlanName;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>439db26c8a98161de8f4c13fdd8b14df</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/