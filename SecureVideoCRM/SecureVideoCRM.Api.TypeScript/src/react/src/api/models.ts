export class VideoClientRequestModel {
  description: string;
  id: number;
  title: string;
  url: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.title = '';
    this.url = '';
  }

  setProperties(
    description: string,
    id: number,
    title: string,
    url: string
  ): void {
    this.description = description;
    this.id = id;
    this.title = title;
    this.url = url;
  }
}

export class VideoClientResponseModel {
  description: string;
  id: number;
  title: string;
  url: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.title = '';
    this.url = '';
  }

  setProperties(
    description: string,
    id: number,
    title: string,
    url: string
  ): void {
    this.description = description;
    this.id = id;
    this.title = title;
    this.url = url;
  }
}
export class UserClientRequestModel {
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
}

export class UserClientResponseModel {
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
}
export class SubscriptionClientRequestModel {
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
}

export class SubscriptionClientResponseModel {
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
}


/*<Codenesium>
    <Hash>0f753511828038bed1cb88e2362a72c7</Hash>
</Codenesium>*/