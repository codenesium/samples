export class BreedClientRequestModel {
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

export class BreedClientResponseModel {
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
export class PaymentTypeClientRequestModel {
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

export class PaymentTypeClientResponseModel {
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
export class PenClientRequestModel {
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

export class PenClientResponseModel {
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
export class PetClientRequestModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedClientResponseModel;
  description: string;
  id: number;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenClientResponseModel;
  price: number;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesClientResponseModel;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.description = '';
    this.id = 0;
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = undefined;
    this.price = 0;
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = undefined;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    id: number,
    penId: number,
    price: number,
    speciesId: number
  ): void {
    this.acquiredDate = acquiredDate;
    this.breedId = breedId;
    this.description = description;
    this.id = id;
    this.penId = penId;
    this.price = price;
    this.speciesId = speciesId;
  }
}

export class PetClientResponseModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedClientResponseModel;
  description: string;
  id: number;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenClientResponseModel;
  price: number;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesClientResponseModel;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.description = '';
    this.id = 0;
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = undefined;
    this.price = 0;
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = undefined;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    id: number,
    penId: number,
    price: number,
    speciesId: number
  ): void {
    this.acquiredDate = acquiredDate;
    this.breedId = breedId;
    this.description = description;
    this.id = id;
    this.penId = penId;
    this.price = price;
    this.speciesId = speciesId;
  }
}
export class SaleClientRequestModel {
  amount: number;
  firstName: string;
  id: number;
  lastName: string;
  paymentTypeId: number;
  paymentTypeIdEntity: string;
  paymentTypeIdNavigation?: PaymentTypeClientResponseModel;
  petId: number;
  petIdEntity: string;
  petIdNavigation?: PetClientResponseModel;
  phone: string;

  constructor() {
    this.amount = 0;
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.paymentTypeId = 0;
    this.paymentTypeIdEntity = '';
    this.paymentTypeIdNavigation = undefined;
    this.petId = 0;
    this.petIdEntity = '';
    this.petIdNavigation = undefined;
    this.phone = '';
  }

  setProperties(
    amount: number,
    firstName: string,
    id: number,
    lastName: string,
    paymentTypeId: number,
    petId: number,
    phone: string
  ): void {
    this.amount = amount;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.paymentTypeId = paymentTypeId;
    this.petId = petId;
    this.phone = phone;
  }
}

export class SaleClientResponseModel {
  amount: number;
  firstName: string;
  id: number;
  lastName: string;
  paymentTypeId: number;
  paymentTypeIdEntity: string;
  paymentTypeIdNavigation?: PaymentTypeClientResponseModel;
  petId: number;
  petIdEntity: string;
  petIdNavigation?: PetClientResponseModel;
  phone: string;

  constructor() {
    this.amount = 0;
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.paymentTypeId = 0;
    this.paymentTypeIdEntity = '';
    this.paymentTypeIdNavigation = undefined;
    this.petId = 0;
    this.petIdEntity = '';
    this.petIdNavigation = undefined;
    this.phone = '';
  }

  setProperties(
    amount: number,
    firstName: string,
    id: number,
    lastName: string,
    paymentTypeId: number,
    petId: number,
    phone: string
  ): void {
    this.amount = amount;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.paymentTypeId = paymentTypeId;
    this.petId = petId;
    this.phone = phone;
  }
}
export class SpeciesClientRequestModel {
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

export class SpeciesClientResponseModel {
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


/*<Codenesium>
    <Hash>55636b142a3e94e07dd605f583bff866</Hash>
</Codenesium>*/