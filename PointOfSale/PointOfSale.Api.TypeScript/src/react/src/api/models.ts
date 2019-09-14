export class CustomerClientRequestModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
  }
}

export class CustomerClientResponseModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  phone: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.phone = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    phone: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.phone = phone;
  }
}
export class ProductClientRequestModel {
  active: boolean;
  description: string;
  id: number;
  name: string;
  price: number;
  quantity: number;

  constructor() {
    this.active = false;
    this.description = '';
    this.id = 0;
    this.name = '';
    this.price = 0;
    this.quantity = 0;
  }

  setProperties(
    active: boolean,
    description: string,
    id: number,
    name: string,
    price: number,
    quantity: number
  ): void {
    this.active = active;
    this.description = description;
    this.id = id;
    this.name = name;
    this.price = price;
    this.quantity = quantity;
  }
}

export class ProductClientResponseModel {
  active: boolean;
  description: string;
  id: number;
  name: string;
  price: number;
  quantity: number;

  constructor() {
    this.active = false;
    this.description = '';
    this.id = 0;
    this.name = '';
    this.price = 0;
    this.quantity = 0;
  }

  setProperties(
    active: boolean,
    description: string,
    id: number,
    name: string,
    price: number,
    quantity: number
  ): void {
    this.active = active;
    this.description = description;
    this.id = id;
    this.name = name;
    this.price = price;
    this.quantity = quantity;
  }
}
export class SaleClientRequestModel {
  customerId: number;
  date: any;
  id: number;

  constructor() {
    this.customerId = 0;
    this.date = undefined;
    this.id = 0;
  }

  setProperties(customerId: number, date: any, id: number): void {
    this.customerId = customerId;
    this.date = date;
    this.id = id;
  }
}

export class SaleClientResponseModel {
  customerId: number;
  date: any;
  id: number;

  constructor() {
    this.customerId = 0;
    this.date = undefined;
    this.id = 0;
  }

  setProperties(customerId: number, date: any, id: number): void {
    this.customerId = customerId;
    this.date = date;
    this.id = id;
  }
}


/*<Codenesium>
    <Hash>a4524f9e7283a91d254d8b89765ac851</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/