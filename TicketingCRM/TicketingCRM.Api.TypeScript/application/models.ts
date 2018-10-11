export class ApiAdminRequestModel {
				email:string;
firstName:string;
id:number;
lastName:string;
password:string;
phone:string;
username:string;

	
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

			export class ApiAdminResponseModel {
				email:string;
firstName:string;
id:number;
lastName:string;
password:string;
phone:string;
username:string;

	
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
			export class ApiCityRequestModel {
				id:number;
name:string;
provinceId:number;
provinceIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.provinceId = 0;

		
				}
			}

			export class ApiCityResponseModel {
				id:number;
name:string;
provinceId:number;
provinceIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.provinceId = 0;

		
				}
			}
			export class ApiCountryRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiCountryResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiCustomerRequestModel {
				email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

	
				constructor() {
					this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

		
				}
			}

			export class ApiCustomerResponseModel {
				email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

	
				constructor() {
					this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

		
				}
			}
			export class ApiEventRequestModel {
				address1:string;
address2:string;
cityId:number;
cityIdEntity:number;
date:string;
description:string;
endDate:string;
facebook:string;
id:number;
name:string;
startDate:string;
website:string;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.cityId = 0;
this.date = '';
this.description = '';
this.endDate = '';
this.facebook = '';
this.id = 0;
this.name = '';
this.startDate = '';
this.website = '';

		
				}
			}

			export class ApiEventResponseModel {
				address1:string;
address2:string;
cityId:number;
cityIdEntity:number;
date:string;
description:string;
endDate:string;
facebook:string;
id:number;
name:string;
startDate:string;
website:string;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.cityId = 0;
this.date = '';
this.description = '';
this.endDate = '';
this.facebook = '';
this.id = 0;
this.name = '';
this.startDate = '';
this.website = '';

		
				}
			}
			export class ApiProvinceRequestModel {
				countryId:number;
countryIdEntity:number;
id:number;
name:string;

	
				constructor() {
					this.countryId = 0;
this.id = 0;
this.name = '';

		
				}
			}

			export class ApiProvinceResponseModel {
				countryId:number;
countryIdEntity:number;
id:number;
name:string;

	
				constructor() {
					this.countryId = 0;
this.id = 0;
this.name = '';

		
				}
			}
			export class ApiSaleRequestModel {
				id:number;
ipAddress:string;
note:string;
saleDate:string;
transactionId:number;
transactionIdEntity:number;

	
				constructor() {
					this.id = 0;
this.ipAddress = '';
this.note = '';
this.saleDate = '';
this.transactionId = 0;

		
				}
			}

			export class ApiSaleResponseModel {
				id:number;
ipAddress:string;
note:string;
saleDate:string;
transactionId:number;
transactionIdEntity:number;

	
				constructor() {
					this.id = 0;
this.ipAddress = '';
this.note = '';
this.saleDate = '';
this.transactionId = 0;

		
				}
			}
			export class ApiTicketRequestModel {
				id:number;
publicId:string;
ticketStatusId:number;
ticketStatusIdEntity:number;

	
				constructor() {
					this.id = 0;
this.publicId = '';
this.ticketStatusId = 0;

		
				}
			}

			export class ApiTicketResponseModel {
				id:number;
publicId:string;
ticketStatusId:number;
ticketStatusIdEntity:number;

	
				constructor() {
					this.id = 0;
this.publicId = '';
this.ticketStatusId = 0;

		
				}
			}
			export class ApiTicketStatuRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTicketStatuResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiTransactionRequestModel {
				amount:number;
gatewayConfirmationNumber:string;
id:number;
transactionStatusId:number;
transactionStatusIdEntity:number;

	
				constructor() {
					this.amount = 0;
this.gatewayConfirmationNumber = '';
this.id = 0;
this.transactionStatusId = 0;

		
				}
			}

			export class ApiTransactionResponseModel {
				amount:number;
gatewayConfirmationNumber:string;
id:number;
transactionStatusId:number;
transactionStatusIdEntity:number;

	
				constructor() {
					this.amount = 0;
this.gatewayConfirmationNumber = '';
this.id = 0;
this.transactionStatusId = 0;

		
				}
			}
			export class ApiTransactionStatuRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTransactionStatuResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiVenueRequestModel {
				address1:string;
address2:string;
adminId:number;
adminIdEntity:number;
email:string;
facebook:string;
id:number;
name:string;
phone:string;
provinceId:number;
provinceIdEntity:number;
website:string;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.adminId = 0;
this.email = '';
this.facebook = '';
this.id = 0;
this.name = '';
this.phone = '';
this.provinceId = 0;
this.website = '';

		
				}
			}

			export class ApiVenueResponseModel {
				address1:string;
address2:string;
adminId:number;
adminIdEntity:number;
email:string;
facebook:string;
id:number;
name:string;
phone:string;
provinceId:number;
provinceIdEntity:number;
website:string;

	
				constructor() {
					this.address1 = '';
this.address2 = '';
this.adminId = 0;
this.email = '';
this.facebook = '';
this.id = 0;
this.name = '';
this.phone = '';
this.provinceId = 0;
this.website = '';

		
				}
			}