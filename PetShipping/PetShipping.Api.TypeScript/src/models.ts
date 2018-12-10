export class ApiAirlineClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiAirlineClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiAirTransportClientRequestModel {
	airlineId : number;
	flightNumber : string;
	handlerId : number;
	handlerIdEntity : string;
	id : number;
	landDate : string;
	pipelineStepId : number;
	takeoffDate : string;

	constructor() {
		this.airlineId = 0;
		this.flightNumber = '';
		this.handlerId = 0;
		this.handlerIdEntity = '';
		this.id = 0;
		this.landDate = '';
		this.pipelineStepId = 0;
		this.takeoffDate = '';
	}
}

export class ApiAirTransportClientResponseModel {
	airlineId : number;
	flightNumber : string;
	handlerId : number;
	handlerIdEntity : string;
	id : number;
	landDate : string;
	pipelineStepId : number;
	takeoffDate : string;

	constructor() {
		this.airlineId = 0;
		this.flightNumber = '';
		this.handlerId = 0;
		this.handlerIdEntity = '';
		this.id = 0;
		this.landDate = '';
		this.pipelineStepId = 0;
		this.takeoffDate = '';
	}
}
export class ApiBreedClientRequestModel {
	id : number;
	name : string;
	speciesId : number;
	speciesIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.speciesId = 0;
		this.speciesIdEntity = '';
	}
}

export class ApiBreedClientResponseModel {
	id : number;
	name : string;
	speciesId : number;
	speciesIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.speciesId = 0;
		this.speciesIdEntity = '';
	}
}
export class ApiCustomerClientRequestModel {
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	note : string;
	phone : string;

	constructor() {
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.note = '';
		this.phone = '';
	}
}

export class ApiCustomerClientResponseModel {
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	note : string;
	phone : string;

	constructor() {
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.note = '';
		this.phone = '';
	}
}
export class ApiCustomerCommunicationClientRequestModel {
	customerId : number;
	customerIdEntity : string;
	dateCreated : string;
	employeeId : number;
	employeeIdEntity : string;
	id : number;
	note : string;

	constructor() {
		this.customerId = 0;
		this.customerIdEntity = '';
		this.dateCreated = '';
		this.employeeId = 0;
		this.employeeIdEntity = '';
		this.id = 0;
		this.note = '';
	}
}

export class ApiCustomerCommunicationClientResponseModel {
	customerId : number;
	customerIdEntity : string;
	dateCreated : string;
	employeeId : number;
	employeeIdEntity : string;
	id : number;
	note : string;

	constructor() {
		this.customerId = 0;
		this.customerIdEntity = '';
		this.dateCreated = '';
		this.employeeId = 0;
		this.employeeIdEntity = '';
		this.id = 0;
		this.note = '';
	}
}
export class ApiCountryClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiCountryClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiCountryRequirementClientRequestModel {
	countryId : number;
	countryIdEntity : string;
	detail : string;
	id : number;

	constructor() {
		this.countryId = 0;
		this.countryIdEntity = '';
		this.detail = '';
		this.id = 0;
	}
}

export class ApiCountryRequirementClientResponseModel {
	countryId : number;
	countryIdEntity : string;
	detail : string;
	id : number;

	constructor() {
		this.countryId = 0;
		this.countryIdEntity = '';
		this.detail = '';
		this.id = 0;
	}
}
export class ApiDestinationClientRequestModel {
	countryId : number;
	countryIdEntity : string;
	id : number;
	name : string;
	order : number;

	constructor() {
		this.countryId = 0;
		this.countryIdEntity = '';
		this.id = 0;
		this.name = '';
		this.order = 0;
	}
}

export class ApiDestinationClientResponseModel {
	countryId : number;
	countryIdEntity : string;
	id : number;
	name : string;
	order : number;

	constructor() {
		this.countryId = 0;
		this.countryIdEntity = '';
		this.id = 0;
		this.name = '';
		this.order = 0;
	}
}
export class ApiEmployeeClientRequestModel {
	firstName : string;
	id : number;
	isSalesPerson : boolean;
	isShipper : boolean;
	lastName : string;

	constructor() {
		this.firstName = '';
		this.id = 0;
		this.isSalesPerson = false;
		this.isShipper = false;
		this.lastName = '';
	}
}

export class ApiEmployeeClientResponseModel {
	firstName : string;
	id : number;
	isSalesPerson : boolean;
	isShipper : boolean;
	lastName : string;

	constructor() {
		this.firstName = '';
		this.id = 0;
		this.isSalesPerson = false;
		this.isShipper = false;
		this.lastName = '';
	}
}
export class ApiHandlerClientRequestModel {
	countryId : number;
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;

	constructor() {
		this.countryId = 0;
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
	}
}

export class ApiHandlerClientResponseModel {
	countryId : number;
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;

	constructor() {
		this.countryId = 0;
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
	}
}
export class ApiHandlerPipelineStepClientRequestModel {
	handlerId : number;
	handlerIdEntity : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.handlerId = 0;
		this.handlerIdEntity = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}

export class ApiHandlerPipelineStepClientResponseModel {
	handlerId : number;
	handlerIdEntity : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.handlerId = 0;
		this.handlerIdEntity = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}
export class ApiOtherTransportClientRequestModel {
	handlerId : number;
	handlerIdEntity : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.handlerId = 0;
		this.handlerIdEntity = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}

export class ApiOtherTransportClientResponseModel {
	handlerId : number;
	handlerIdEntity : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.handlerId = 0;
		this.handlerIdEntity = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}
export class ApiPetClientRequestModel {
	breedId : number;
	breedIdEntity : string;
	clientId : number;
	id : number;
	name : string;
	weight : number;

	constructor() {
		this.breedId = 0;
		this.breedIdEntity = '';
		this.clientId = 0;
		this.id = 0;
		this.name = '';
		this.weight = 0;
	}
}

export class ApiPetClientResponseModel {
	breedId : number;
	breedIdEntity : string;
	clientId : number;
	id : number;
	name : string;
	weight : number;

	constructor() {
		this.breedId = 0;
		this.breedIdEntity = '';
		this.clientId = 0;
		this.id = 0;
		this.name = '';
		this.weight = 0;
	}
}
export class ApiPipelineClientRequestModel {
	id : number;
	pipelineStatusId : number;
	pipelineStatusIdEntity : string;
	saleId : number;

	constructor() {
		this.id = 0;
		this.pipelineStatusId = 0;
		this.pipelineStatusIdEntity = '';
		this.saleId = 0;
	}
}

export class ApiPipelineClientResponseModel {
	id : number;
	pipelineStatusId : number;
	pipelineStatusIdEntity : string;
	saleId : number;

	constructor() {
		this.id = 0;
		this.pipelineStatusId = 0;
		this.pipelineStatusIdEntity = '';
		this.saleId = 0;
	}
}
export class ApiPipelineStatuClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiPipelineStatuClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiPipelineStepClientRequestModel {
	id : number;
	name : string;
	pipelineStepStatusId : number;
	pipelineStepStatusIdEntity : string;
	shipperId : number;
	shipperIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.pipelineStepStatusId = 0;
		this.pipelineStepStatusIdEntity = '';
		this.shipperId = 0;
		this.shipperIdEntity = '';
	}
}

export class ApiPipelineStepClientResponseModel {
	id : number;
	name : string;
	pipelineStepStatusId : number;
	pipelineStepStatusIdEntity : string;
	shipperId : number;
	shipperIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.pipelineStepStatusId = 0;
		this.pipelineStepStatusIdEntity = '';
		this.shipperId = 0;
		this.shipperIdEntity = '';
	}
}
export class ApiPipelineStepDestinationClientRequestModel {
	destinationId : number;
	destinationIdEntity : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.destinationId = 0;
		this.destinationIdEntity = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}

export class ApiPipelineStepDestinationClientResponseModel {
	destinationId : number;
	destinationIdEntity : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.destinationId = 0;
		this.destinationIdEntity = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}
export class ApiPipelineStepNoteClientRequestModel {
	employeeId : number;
	employeeIdEntity : string;
	id : number;
	note : string;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.employeeId = 0;
		this.employeeIdEntity = '';
		this.id = 0;
		this.note = '';
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}

export class ApiPipelineStepNoteClientResponseModel {
	employeeId : number;
	employeeIdEntity : string;
	id : number;
	note : string;
	pipelineStepId : number;
	pipelineStepIdEntity : string;

	constructor() {
		this.employeeId = 0;
		this.employeeIdEntity = '';
		this.id = 0;
		this.note = '';
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
	}
}
export class ApiPipelineStepStatuClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiPipelineStepStatuClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiPipelineStepStepRequirementClientRequestModel {
	detail : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;
	requirementMet : boolean;

	constructor() {
		this.detail = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
		this.requirementMet = false;
	}
}

export class ApiPipelineStepStepRequirementClientResponseModel {
	detail : string;
	id : number;
	pipelineStepId : number;
	pipelineStepIdEntity : string;
	requirementMet : boolean;

	constructor() {
		this.detail = '';
		this.id = 0;
		this.pipelineStepId = 0;
		this.pipelineStepIdEntity = '';
		this.requirementMet = false;
	}
}
export class ApiSaleClientRequestModel {
	amount : number;
	cutomerId : number;
	id : number;
	note : string;
	petId : number;
	petIdEntity : string;
	saleDate : string;
	salesPersonId : number;

	constructor() {
		this.amount = 0;
		this.cutomerId = 0;
		this.id = 0;
		this.note = '';
		this.petId = 0;
		this.petIdEntity = '';
		this.saleDate = '';
		this.salesPersonId = 0;
	}
}

export class ApiSaleClientResponseModel {
	amount : number;
	cutomerId : number;
	id : number;
	note : string;
	petId : number;
	petIdEntity : string;
	saleDate : string;
	salesPersonId : number;

	constructor() {
		this.amount = 0;
		this.cutomerId = 0;
		this.id = 0;
		this.note = '';
		this.petId = 0;
		this.petIdEntity = '';
		this.saleDate = '';
		this.salesPersonId = 0;
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
    <Hash>d53c80efcef38d7ca1cac0de30f04527</Hash>
</Codenesium>*/