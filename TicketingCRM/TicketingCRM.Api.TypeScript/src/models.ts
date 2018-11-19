export class ApiAdminServerRequestModel {
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

			export class ApiAdminServerResponseModel {
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
			export class ApiCityServerRequestModel {
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

			export class ApiCityServerResponseModel {
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
			export class ApiCountryServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiCountryServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiCustomerServerRequestModel {
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

			export class ApiCustomerServerResponseModel {
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
			export class ApiEventServerRequestModel {
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

			export class ApiEventServerResponseModel {
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
			export class ApiProvinceServerRequestModel {
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

			export class ApiProvinceServerResponseModel {
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
			export class ApiSaleServerRequestModel {
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

			export class ApiSaleServerResponseModel {
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
			export class ApiTicketServerRequestModel {
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

			export class ApiTicketServerResponseModel {
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
			export class ApiTicketStatuServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTicketStatuServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiTransactionServerRequestModel {
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

			export class ApiTransactionServerResponseModel {
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
			export class ApiTransactionStatuServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiTransactionStatuServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiVenueServerRequestModel {
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

			export class ApiVenueServerResponseModel {
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