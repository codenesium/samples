export class ApiAirlineServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiAirlineServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiAirTransportServerRequestModel {
				airlineId:number;
flightNumber:string;
handlerId:number;
handlerIdEntity:number;
id:number;
landDate:string;
pipelineStepId:number;
takeoffDate:string;

	
				constructor() {
					this.airlineId = 0;
this.flightNumber = '';
this.handlerId = 0;
this.id = 0;
this.landDate = '';
this.pipelineStepId = 0;
this.takeoffDate = '';

		
				}
			}

			export class ApiAirTransportServerResponseModel {
				airlineId:number;
flightNumber:string;
handlerId:number;
handlerIdEntity:number;
id:number;
landDate:string;
pipelineStepId:number;
takeoffDate:string;

	
				constructor() {
					this.airlineId = 0;
this.flightNumber = '';
this.handlerId = 0;
this.id = 0;
this.landDate = '';
this.pipelineStepId = 0;
this.takeoffDate = '';

		
				}
			}
			export class ApiBreedServerRequestModel {
				id:number;
name:string;
speciesId:number;
speciesIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.speciesId = 0;

		
				}
			}

			export class ApiBreedServerResponseModel {
				id:number;
name:string;
speciesId:number;
speciesIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.speciesId = 0;

		
				}
			}
			export class ApiClientServerRequestModel {
				email:string;
firstName:string;
id:number;
lastName:string;
note:string;
phone:string;

	
				constructor() {
					this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.note = '';
this.phone = '';

		
				}
			}

			export class ApiClientServerResponseModel {
				email:string;
firstName:string;
id:number;
lastName:string;
note:string;
phone:string;

	
				constructor() {
					this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.note = '';
this.phone = '';

		
				}
			}
			export class ApiClientCommunicationServerRequestModel {
				clientId:number;
clientIdEntity:number;
dateCreated:string;
employeeId:number;
employeeIdEntity:number;
id:number;
note:string;

	
				constructor() {
					this.clientId = 0;
this.dateCreated = '';
this.employeeId = 0;
this.id = 0;
this.note = '';

		
				}
			}

			export class ApiClientCommunicationServerResponseModel {
				clientId:number;
clientIdEntity:number;
dateCreated:string;
employeeId:number;
employeeIdEntity:number;
id:number;
note:string;

	
				constructor() {
					this.clientId = 0;
this.dateCreated = '';
this.employeeId = 0;
this.id = 0;
this.note = '';

		
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
			export class ApiCountryRequirementServerRequestModel {
				countryId:number;
countryIdEntity:number;
detail:string;
id:number;

	
				constructor() {
					this.countryId = 0;
this.detail = '';
this.id = 0;

		
				}
			}

			export class ApiCountryRequirementServerResponseModel {
				countryId:number;
countryIdEntity:number;
detail:string;
id:number;

	
				constructor() {
					this.countryId = 0;
this.detail = '';
this.id = 0;

		
				}
			}
			export class ApiDestinationServerRequestModel {
				countryId:number;
countryIdEntity:number;
id:number;
name:string;
order:number;

	
				constructor() {
					this.countryId = 0;
this.id = 0;
this.name = '';
this.order = 0;

		
				}
			}

			export class ApiDestinationServerResponseModel {
				countryId:number;
countryIdEntity:number;
id:number;
name:string;
order:number;

	
				constructor() {
					this.countryId = 0;
this.id = 0;
this.name = '';
this.order = 0;

		
				}
			}
			export class ApiEmployeeServerRequestModel {
				firstName:string;
id:number;
isSalesPerson:boolean;
isShipper:boolean;
lastName:string;

	
				constructor() {
					this.firstName = '';
this.id = 0;
this.isSalesPerson = false;
this.isShipper = false;
this.lastName = '';

		
				}
			}

			export class ApiEmployeeServerResponseModel {
				firstName:string;
id:number;
isSalesPerson:boolean;
isShipper:boolean;
lastName:string;

	
				constructor() {
					this.firstName = '';
this.id = 0;
this.isSalesPerson = false;
this.isShipper = false;
this.lastName = '';

		
				}
			}
			export class ApiHandlerServerRequestModel {
				countryId:number;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

	
				constructor() {
					this.countryId = 0;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

		
				}
			}

			export class ApiHandlerServerResponseModel {
				countryId:number;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

	
				constructor() {
					this.countryId = 0;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

		
				}
			}
			export class ApiPetServerRequestModel {
				breedId:number;
breedIdEntity:number;
clientId:number;
clientIdEntity:number;
id:number;
name:string;
weight:number;

	
				constructor() {
					this.breedId = 0;
this.clientId = 0;
this.id = 0;
this.name = '';
this.weight = 0;

		
				}
			}

			export class ApiPetServerResponseModel {
				breedId:number;
breedIdEntity:number;
clientId:number;
clientIdEntity:number;
id:number;
name:string;
weight:number;

	
				constructor() {
					this.breedId = 0;
this.clientId = 0;
this.id = 0;
this.name = '';
this.weight = 0;

		
				}
			}
			export class ApiPipelineServerRequestModel {
				id:number;
pipelineStatusId:number;
pipelineStatusIdEntity:number;
saleId:number;

	
				constructor() {
					this.id = 0;
this.pipelineStatusId = 0;
this.saleId = 0;

		
				}
			}

			export class ApiPipelineServerResponseModel {
				id:number;
pipelineStatusId:number;
pipelineStatusIdEntity:number;
saleId:number;

	
				constructor() {
					this.id = 0;
this.pipelineStatusId = 0;
this.saleId = 0;

		
				}
			}
			export class ApiPipelineStatuServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiPipelineStatuServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiPipelineStepServerRequestModel {
				id:number;
name:string;
pipelineStepStatusId:number;
pipelineStepStatusIdEntity:number;
shipperId:number;
shipperIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.pipelineStepStatusId = 0;
this.shipperId = 0;

		
				}
			}

			export class ApiPipelineStepServerResponseModel {
				id:number;
name:string;
pipelineStepStatusId:number;
pipelineStepStatusIdEntity:number;
shipperId:number;
shipperIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.pipelineStepStatusId = 0;
this.shipperId = 0;

		
				}
			}
			export class ApiPipelineStepNoteServerRequestModel {
				employeeId:number;
employeeIdEntity:number;
id:number;
note:string;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.employeeId = 0;
this.id = 0;
this.note = '';
this.pipelineStepId = 0;

		
				}
			}

			export class ApiPipelineStepNoteServerResponseModel {
				employeeId:number;
employeeIdEntity:number;
id:number;
note:string;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.employeeId = 0;
this.id = 0;
this.note = '';
this.pipelineStepId = 0;

		
				}
			}
			export class ApiPipelineStepStatuServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiPipelineStepStatuServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiPipelineStepStepRequirementServerRequestModel {
				detail:string;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;
requirementMet:boolean;

	
				constructor() {
					this.detail = '';
this.id = 0;
this.pipelineStepId = 0;
this.requirementMet = false;

		
				}
			}

			export class ApiPipelineStepStepRequirementServerResponseModel {
				detail:string;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;
requirementMet:boolean;

	
				constructor() {
					this.detail = '';
this.id = 0;
this.pipelineStepId = 0;
this.requirementMet = false;

		
				}
			}
			export class ApiSaleServerRequestModel {
				amount:number;
clientId:number;
clientIdEntity:number;
id:number;
note:string;
petId:number;
petIdEntity:number;
saleDate:string;
salesPersonId:number;

	
				constructor() {
					this.amount = 0;
this.clientId = 0;
this.id = 0;
this.note = '';
this.petId = 0;
this.saleDate = '';
this.salesPersonId = 0;

		
				}
			}

			export class ApiSaleServerResponseModel {
				amount:number;
clientId:number;
clientIdEntity:number;
id:number;
note:string;
petId:number;
petIdEntity:number;
saleDate:string;
salesPersonId:number;

	
				constructor() {
					this.amount = 0;
this.clientId = 0;
this.id = 0;
this.note = '';
this.petId = 0;
this.saleDate = '';
this.salesPersonId = 0;

		
				}
			}
			export class ApiSpeciesServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiSpeciesServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}