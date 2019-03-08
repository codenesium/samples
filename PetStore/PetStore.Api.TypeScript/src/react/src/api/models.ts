export class BreedClientRequestModel {
  name: string;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesClientResponseModel;

  constructor() {
    this.name = '';
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = undefined;
  }

  setProperties(name: string, speciesId: number): void {
    this.name = name;
    this.speciesId = speciesId;
  }
}

export class BreedClientResponseModel {
  name: string;
  speciesId: number;
  speciesIdEntity: string;
  speciesIdNavigation?: SpeciesClientResponseModel;

  constructor() {
    this.name = '';
    this.speciesId = 0;
    this.speciesIdEntity = '';
    this.speciesIdNavigation = undefined;
  }

  setProperties(name: string, speciesId: number): void {
    this.name = name;
    this.speciesId = speciesId;
  }
}
export class PaymentTypeClientRequestModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }
}

export class PaymentTypeClientResponseModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }
}
export class PenClientRequestModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }
}

export class PenClientResponseModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }
}
export class PetClientRequestModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedClientResponseModel;
  description: string;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenClientResponseModel;
  price: number;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.description = '';
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = undefined;
    this.price = 0;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    penId: number,
    price: number
  ): void {
    this.acquiredDate = acquiredDate;
    this.breedId = breedId;
    this.description = description;
    this.penId = penId;
    this.price = price;
  }
}

export class PetClientResponseModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedClientResponseModel;
  description: string;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenClientResponseModel;
  price: number;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.description = '';
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = undefined;
    this.price = 0;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    penId: number,
    price: number
  ): void {
    this.acquiredDate = acquiredDate;
    this.breedId = breedId;
    this.description = description;
    this.penId = penId;
    this.price = price;
  }
}
export class SaleClientRequestModel {
  amount: number;
  firstName: string;
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
    lastName: string,
    paymentTypeId: number,
    petId: number,
    phone: string
  ): void {
    this.amount = amount;
    this.firstName = firstName;
    this.lastName = lastName;
    this.paymentTypeId = paymentTypeId;
    this.petId = petId;
    this.phone = phone;
  }
}

export class SaleClientResponseModel {
  amount: number;
  firstName: string;
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
    lastName: string,
    paymentTypeId: number,
    petId: number,
    phone: string
  ): void {
    this.amount = amount;
    this.firstName = firstName;
    this.lastName = lastName;
    this.paymentTypeId = paymentTypeId;
    this.petId = petId;
    this.phone = phone;
  }
}
export class SpeciesClientRequestModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }
}

export class SpeciesClientResponseModel {
  name: string;

  constructor() {
    this.name = '';
  }

  setProperties(name: string): void {
    this.name = name;
  }
}


/*<Codenesium>
    <Hash>86d002799c60075bfab298a79a58ca3d</Hash>
</Codenesium>*/