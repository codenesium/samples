export class ApiAdminClientRequestModel {
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	password : string;
	phone : string;
	username : string;

	constructor() {
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.password = '';
		this.phone = '';
		this.username = '';
	}
}

export class ApiAdminClientResponseModel {
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	password : string;
	phone : string;
	username : string;

	constructor() {
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.password = '';
		this.phone = '';
		this.username = '';
	}
}
export class ApiCityClientRequestModel {
	id : number;
	name : string;
	provinceId : number;
	provinceIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.provinceId = 0;
		this.provinceIdEntity = '';
	}
}

export class ApiCityClientResponseModel {
	id : number;
	name : string;
	provinceId : number;
	provinceIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.provinceId = 0;
		this.provinceIdEntity = '';
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
export class ApiCustomerClientRequestModel {
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;

	constructor() {
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
	}
}

export class ApiCustomerClientResponseModel {
	email : string;
	firstName : string;
	id : number;
	lastName : string;
	phone : string;

	constructor() {
		this.email = '';
		this.firstName = '';
		this.id = 0;
		this.lastName = '';
		this.phone = '';
	}
}
export class ApiEventClientRequestModel {
	address1 : string;
	address2 : string;
	cityId : number;
	cityIdEntity : string;
	date : any;
	description : string;
	endDate : any;
	facebook : string;
	id : number;
	name : string;
	startDate : any;
	website : string;

	constructor() {
		this.address1 = '';
		this.address2 = '';
		this.cityId = 0;
		this.cityIdEntity = '';
		this.date = null;
		this.description = '';
		this.endDate = null;
		this.facebook = '';
		this.id = 0;
		this.name = '';
		this.startDate = null;
		this.website = '';
	}
}

export class ApiEventClientResponseModel {
	address1 : string;
	address2 : string;
	cityId : number;
	cityIdEntity : string;
	date : any;
	description : string;
	endDate : any;
	facebook : string;
	id : number;
	name : string;
	startDate : any;
	website : string;

	constructor() {
		this.address1 = '';
		this.address2 = '';
		this.cityId = 0;
		this.cityIdEntity = '';
		this.date = null;
		this.description = '';
		this.endDate = null;
		this.facebook = '';
		this.id = 0;
		this.name = '';
		this.startDate = null;
		this.website = '';
	}
}
export class ApiProvinceClientRequestModel {
	countryId : number;
	countryIdEntity : string;
	id : number;
	name : string;

	constructor() {
		this.countryId = 0;
		this.countryIdEntity = '';
		this.id = 0;
		this.name = '';
	}
}

export class ApiProvinceClientResponseModel {
	countryId : number;
	countryIdEntity : string;
	id : number;
	name : string;

	constructor() {
		this.countryId = 0;
		this.countryIdEntity = '';
		this.id = 0;
		this.name = '';
	}
}
export class ApiSaleClientRequestModel {
	id : number;
	ipAddress : string;
	note : string;
	saleDate : any;
	transactionId : number;
	transactionIdEntity : string;

	constructor() {
		this.id = 0;
		this.ipAddress = '';
		this.note = '';
		this.saleDate = null;
		this.transactionId = 0;
		this.transactionIdEntity = '';
	}
}

export class ApiSaleClientResponseModel {
	id : number;
	ipAddress : string;
	note : string;
	saleDate : any;
	transactionId : number;
	transactionIdEntity : string;

	constructor() {
		this.id = 0;
		this.ipAddress = '';
		this.note = '';
		this.saleDate = null;
		this.transactionId = 0;
		this.transactionIdEntity = '';
	}
}
export class ApiTicketClientRequestModel {
	id : number;
	publicId : string;
	ticketStatusId : number;
	ticketStatusIdEntity : string;

	constructor() {
		this.id = 0;
		this.publicId = '';
		this.ticketStatusId = 0;
		this.ticketStatusIdEntity = '';
	}
}

export class ApiTicketClientResponseModel {
	id : number;
	publicId : string;
	ticketStatusId : number;
	ticketStatusIdEntity : string;

	constructor() {
		this.id = 0;
		this.publicId = '';
		this.ticketStatusId = 0;
		this.ticketStatusIdEntity = '';
	}
}
export class ApiTicketStatuClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiTicketStatuClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiTransactionClientRequestModel {
	amount : number;
	gatewayConfirmationNumber : string;
	id : number;
	transactionStatusId : number;
	transactionStatusIdEntity : string;

	constructor() {
		this.amount = 0;
		this.gatewayConfirmationNumber = '';
		this.id = 0;
		this.transactionStatusId = 0;
		this.transactionStatusIdEntity = '';
	}
}

export class ApiTransactionClientResponseModel {
	amount : number;
	gatewayConfirmationNumber : string;
	id : number;
	transactionStatusId : number;
	transactionStatusIdEntity : string;

	constructor() {
		this.amount = 0;
		this.gatewayConfirmationNumber = '';
		this.id = 0;
		this.transactionStatusId = 0;
		this.transactionStatusIdEntity = '';
	}
}
export class ApiTransactionStatuClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiTransactionStatuClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiVenueClientRequestModel {
	address1 : string;
	address2 : string;
	adminId : number;
	adminIdEntity : string;
	email : string;
	facebook : string;
	id : number;
	name : string;
	phone : string;
	provinceId : number;
	provinceIdEntity : string;
	website : string;

	constructor() {
		this.address1 = '';
		this.address2 = '';
		this.adminId = 0;
		this.adminIdEntity = '';
		this.email = '';
		this.facebook = '';
		this.id = 0;
		this.name = '';
		this.phone = '';
		this.provinceId = 0;
		this.provinceIdEntity = '';
		this.website = '';
	}
}

export class ApiVenueClientResponseModel {
	address1 : string;
	address2 : string;
	adminId : number;
	adminIdEntity : string;
	email : string;
	facebook : string;
	id : number;
	name : string;
	phone : string;
	provinceId : number;
	provinceIdEntity : string;
	website : string;

	constructor() {
		this.address1 = '';
		this.address2 = '';
		this.adminId = 0;
		this.adminIdEntity = '';
		this.email = '';
		this.facebook = '';
		this.id = 0;
		this.name = '';
		this.phone = '';
		this.provinceId = 0;
		this.provinceIdEntity = '';
		this.website = '';
	}
}

/*<Codenesium>
    <Hash>87ddf8c1c3d5777b901b3b80e9a1b349</Hash>
</Codenesium>*/