export class AdminClientRequestModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  password: string;
  phone: string;
  username: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.password = '';
    this.phone = '';
    this.username = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    password: string,
    phone: string,
    username: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.password = password;
    this.phone = phone;
    this.username = username;
  }
}

export class AdminClientResponseModel {
  email: string;
  firstName: string;
  id: number;
  lastName: string;
  password: string;
  phone: string;
  username: string;

  constructor() {
    this.email = '';
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.password = '';
    this.phone = '';
    this.username = '';
  }

  setProperties(
    email: string,
    firstName: string,
    id: number,
    lastName: string,
    password: string,
    phone: string,
    username: string
  ): void {
    this.email = email;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.password = password;
    this.phone = phone;
    this.username = username;
  }
}
export class CityClientRequestModel {
  id: number;
  name: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceClientResponseModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
  }

  setProperties(id: number, name: string, provinceId: number): void {
    this.id = id;
    this.name = name;
    this.provinceId = provinceId;
  }
}

export class CityClientResponseModel {
  id: number;
  name: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceClientResponseModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
  }

  setProperties(id: number, name: string, provinceId: number): void {
    this.id = id;
    this.name = name;
    this.provinceId = provinceId;
  }
}
export class CountryClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class CountryClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
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
export class EventClientRequestModel {
  address1: string;
  address2: string;
  cityId: number;
  cityIdEntity: string;
  cityIdNavigation?: CityClientResponseModel;
  date: any;
  description: string;
  endDate: any;
  facebook: string;
  id: number;
  name: string;
  startDate: any;
  website: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.cityId = 0;
    this.cityIdEntity = '';
    this.cityIdNavigation = undefined;
    this.date = undefined;
    this.description = '';
    this.endDate = undefined;
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.startDate = undefined;
    this.website = '';
  }

  setProperties(
    address1: string,
    address2: string,
    cityId: number,
    date: any,
    description: string,
    endDate: any,
    facebook: string,
    id: number,
    name: string,
    startDate: any,
    website: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.cityId = cityId;
    this.date = date;
    this.description = description;
    this.endDate = endDate;
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.startDate = startDate;
    this.website = website;
  }
}

export class EventClientResponseModel {
  address1: string;
  address2: string;
  cityId: number;
  cityIdEntity: string;
  cityIdNavigation?: CityClientResponseModel;
  date: any;
  description: string;
  endDate: any;
  facebook: string;
  id: number;
  name: string;
  startDate: any;
  website: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.cityId = 0;
    this.cityIdEntity = '';
    this.cityIdNavigation = undefined;
    this.date = undefined;
    this.description = '';
    this.endDate = undefined;
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.startDate = undefined;
    this.website = '';
  }

  setProperties(
    address1: string,
    address2: string,
    cityId: number,
    date: any,
    description: string,
    endDate: any,
    facebook: string,
    id: number,
    name: string,
    startDate: any,
    website: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.cityId = cityId;
    this.date = date;
    this.description = description;
    this.endDate = endDate;
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.startDate = startDate;
    this.website = website;
  }
}
export class ProvinceClientRequestModel {
  countryId: number;
  countryIdEntity: string;
  countryIdNavigation?: CountryClientResponseModel;
  id: number;
  name: string;

  constructor() {
    this.countryId = 0;
    this.countryIdEntity = '';
    this.countryIdNavigation = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(countryId: number, id: number, name: string): void {
    this.countryId = countryId;
    this.id = id;
    this.name = name;
  }
}

export class ProvinceClientResponseModel {
  countryId: number;
  countryIdEntity: string;
  countryIdNavigation?: CountryClientResponseModel;
  id: number;
  name: string;

  constructor() {
    this.countryId = 0;
    this.countryIdEntity = '';
    this.countryIdNavigation = undefined;
    this.id = 0;
    this.name = '';
  }

  setProperties(countryId: number, id: number, name: string): void {
    this.countryId = countryId;
    this.id = id;
    this.name = name;
  }
}
export class SaleClientRequestModel {
  id: number;
  ipAddress: string;
  note: string;
  saleDate: any;
  transactionId: number;
  transactionIdEntity: string;
  transactionIdNavigation?: TransactionClientResponseModel;

  constructor() {
    this.id = 0;
    this.ipAddress = '';
    this.note = '';
    this.saleDate = undefined;
    this.transactionId = 0;
    this.transactionIdEntity = '';
    this.transactionIdNavigation = undefined;
  }

  setProperties(
    id: number,
    ipAddress: string,
    note: string,
    saleDate: any,
    transactionId: number
  ): void {
    this.id = id;
    this.ipAddress = ipAddress;
    this.note = note;
    this.saleDate = saleDate;
    this.transactionId = transactionId;
  }
}

export class SaleClientResponseModel {
  id: number;
  ipAddress: string;
  note: string;
  saleDate: any;
  transactionId: number;
  transactionIdEntity: string;
  transactionIdNavigation?: TransactionClientResponseModel;

  constructor() {
    this.id = 0;
    this.ipAddress = '';
    this.note = '';
    this.saleDate = undefined;
    this.transactionId = 0;
    this.transactionIdEntity = '';
    this.transactionIdNavigation = undefined;
  }

  setProperties(
    id: number,
    ipAddress: string,
    note: string,
    saleDate: any,
    transactionId: number
  ): void {
    this.id = id;
    this.ipAddress = ipAddress;
    this.note = note;
    this.saleDate = saleDate;
    this.transactionId = transactionId;
  }
}
export class SaleTicketClientRequestModel {
  id: number;
  saleId: number;
  saleIdEntity: string;
  saleIdNavigation?: SaleClientResponseModel;
  ticketId: number;
  ticketIdEntity: string;
  ticketIdNavigation?: TicketClientResponseModel;

  constructor() {
    this.id = 0;
    this.saleId = 0;
    this.saleIdEntity = '';
    this.saleIdNavigation = undefined;
    this.ticketId = 0;
    this.ticketIdEntity = '';
    this.ticketIdNavigation = undefined;
  }

  setProperties(id: number, saleId: number, ticketId: number): void {
    this.id = id;
    this.saleId = saleId;
    this.ticketId = ticketId;
  }
}

export class SaleTicketClientResponseModel {
  id: number;
  saleId: number;
  saleIdEntity: string;
  saleIdNavigation?: SaleClientResponseModel;
  ticketId: number;
  ticketIdEntity: string;
  ticketIdNavigation?: TicketClientResponseModel;

  constructor() {
    this.id = 0;
    this.saleId = 0;
    this.saleIdEntity = '';
    this.saleIdNavigation = undefined;
    this.ticketId = 0;
    this.ticketIdEntity = '';
    this.ticketIdNavigation = undefined;
  }

  setProperties(id: number, saleId: number, ticketId: number): void {
    this.id = id;
    this.saleId = saleId;
    this.ticketId = ticketId;
  }
}
export class TicketClientRequestModel {
  id: number;
  publicId: string;
  ticketStatusId: number;
  ticketStatusIdEntity: string;
  ticketStatusIdNavigation?: TicketStatusClientResponseModel;

  constructor() {
    this.id = 0;
    this.publicId = '';
    this.ticketStatusId = 0;
    this.ticketStatusIdEntity = '';
    this.ticketStatusIdNavigation = undefined;
  }

  setProperties(id: number, publicId: string, ticketStatusId: number): void {
    this.id = id;
    this.publicId = publicId;
    this.ticketStatusId = ticketStatusId;
  }
}

export class TicketClientResponseModel {
  id: number;
  publicId: string;
  ticketStatusId: number;
  ticketStatusIdEntity: string;
  ticketStatusIdNavigation?: TicketStatusClientResponseModel;

  constructor() {
    this.id = 0;
    this.publicId = '';
    this.ticketStatusId = 0;
    this.ticketStatusIdEntity = '';
    this.ticketStatusIdNavigation = undefined;
  }

  setProperties(id: number, publicId: string, ticketStatusId: number): void {
    this.id = id;
    this.publicId = publicId;
    this.ticketStatusId = ticketStatusId;
  }
}
export class TicketStatusClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class TicketStatusClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class TransactionClientRequestModel {
  amount: number;
  gatewayConfirmationNumber: string;
  id: number;
  transactionStatusId: number;
  transactionStatusIdEntity: string;
  transactionStatusIdNavigation?: TransactionStatusClientResponseModel;

  constructor() {
    this.amount = 0;
    this.gatewayConfirmationNumber = '';
    this.id = 0;
    this.transactionStatusId = 0;
    this.transactionStatusIdEntity = '';
    this.transactionStatusIdNavigation = undefined;
  }

  setProperties(
    amount: number,
    gatewayConfirmationNumber: string,
    id: number,
    transactionStatusId: number
  ): void {
    this.amount = amount;
    this.gatewayConfirmationNumber = gatewayConfirmationNumber;
    this.id = id;
    this.transactionStatusId = transactionStatusId;
  }
}

export class TransactionClientResponseModel {
  amount: number;
  gatewayConfirmationNumber: string;
  id: number;
  transactionStatusId: number;
  transactionStatusIdEntity: string;
  transactionStatusIdNavigation?: TransactionStatusClientResponseModel;

  constructor() {
    this.amount = 0;
    this.gatewayConfirmationNumber = '';
    this.id = 0;
    this.transactionStatusId = 0;
    this.transactionStatusIdEntity = '';
    this.transactionStatusIdNavigation = undefined;
  }

  setProperties(
    amount: number,
    gatewayConfirmationNumber: string,
    id: number,
    transactionStatusId: number
  ): void {
    this.amount = amount;
    this.gatewayConfirmationNumber = gatewayConfirmationNumber;
    this.id = id;
    this.transactionStatusId = transactionStatusId;
  }
}
export class TransactionStatusClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class TransactionStatusClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class VenueClientRequestModel {
  address1: string;
  address2: string;
  adminId: number;
  adminIdEntity: string;
  adminIdNavigation?: AdminClientResponseModel;
  email: string;
  facebook: string;
  id: number;
  name: string;
  phone: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceClientResponseModel;
  website: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.adminId = 0;
    this.adminIdEntity = '';
    this.adminIdNavigation = undefined;
    this.email = '';
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.phone = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
    this.website = '';
  }

  setProperties(
    address1: string,
    address2: string,
    adminId: number,
    email: string,
    facebook: string,
    id: number,
    name: string,
    phone: string,
    provinceId: number,
    website: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.adminId = adminId;
    this.email = email;
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.phone = phone;
    this.provinceId = provinceId;
    this.website = website;
  }
}

export class VenueClientResponseModel {
  address1: string;
  address2: string;
  adminId: number;
  adminIdEntity: string;
  adminIdNavigation?: AdminClientResponseModel;
  email: string;
  facebook: string;
  id: number;
  name: string;
  phone: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceClientResponseModel;
  website: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.adminId = 0;
    this.adminIdEntity = '';
    this.adminIdNavigation = undefined;
    this.email = '';
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.phone = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
    this.website = '';
  }

  setProperties(
    address1: string,
    address2: string,
    adminId: number,
    email: string,
    facebook: string,
    id: number,
    name: string,
    phone: string,
    provinceId: number,
    website: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.adminId = adminId;
    this.email = email;
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.phone = phone;
    this.provinceId = provinceId;
    this.website = website;
  }
}


/*<Codenesium>
    <Hash>24a453148b0e6d060beea56276bcc468</Hash>
</Codenesium>*/