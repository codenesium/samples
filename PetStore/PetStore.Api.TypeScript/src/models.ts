export class ApiBreedClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiBreedClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiPaymentTypeClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiPaymentTypeClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiPenClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiPenClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiPetClientRequestModel {
	acquiredDate : string;
	breedId : number;
	breedIdEntity : string;
	description : string;
	id : number;
	penId : number;
	penIdEntity : string;
	price : number;
	speciesId : number;
	speciesIdEntity : string;

	constructor() {
		this.acquiredDate = '';
		this.breedId = 0;
		this.breedIdEntity = '';
		this.description = '';
		this.id = 0;
		this.penId = 0;
		this.penIdEntity = '';
		this.price = 0;
		this.speciesId = 0;
		this.speciesIdEntity = '';
	}
}

export class ApiPetClientResponseModel {
	acquiredDate : string;
	breedId : number;
	breedIdEntity : string;
	description : string;
	id : number;
	penId : number;
	penIdEntity : string;
	price : number;
	speciesId : number;
	speciesIdEntity : string;

	constructor() {
		this.acquiredDate = '';
		this.breedId = 0;
		this.breedIdEntity = '';
		this.description = '';
		this.id = 0;
		this.penId = 0;
		this.penIdEntity = '';
		this.price = 0;
		this.speciesId = 0;
		this.speciesIdEntity = '';
	}
}
export class ApiSaleClientRequestModel {
	amount : number;
	firstName : string;
	id : number;
	lastName : string;
	paymentTypeId : number;
	paymentTypeIdEntity : string;
	petId : number;
	petIdEntity : string;
	phone : string;

	constructor() {
		this.amount = 0;
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.paymentTypeId = 0;
		this.paymentTypeIdEntity = '';
		this.petId = 0;
		this.petIdEntity = '';
		this.phone = '';
	}
}

export class ApiSaleClientResponseModel {
	amount : number;
	firstName : string;
	id : number;
	lastName : string;
	paymentTypeId : number;
	paymentTypeIdEntity : string;
	petId : number;
	petIdEntity : string;
	phone : string;

	constructor() {
		this.amount = 0;
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.paymentTypeId = 0;
		this.paymentTypeIdEntity = '';
		this.petId = 0;
		this.petIdEntity = '';
		this.phone = '';
	}
}
export class ApiSpeciesClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiSpeciesClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

/*<Codenesium>
    <Hash>ca0aa6a14a9b8ec76f49c2b5bfe78876</Hash>
</Codenesium>*/