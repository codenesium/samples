export class ApiAirlineRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiAirlineResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiAirTransportRequestModel {
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

			export class ApiAirTransportResponseModel {
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
			export class ApiBreedRequestModel {
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

			export class ApiBreedResponseModel {
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
			export class ApiClientRequestModel {
				email:string;
firstName:string;
id:number;
lastName:string;
notes:string;
phone:string;

	
				constructor() {
					this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.notes = '';
this.phone = '';

		
				}
			}

			export class ApiClientResponseModel {
				email:string;
firstName:string;
id:number;
lastName:string;
notes:string;
phone:string;

	
				constructor() {
					this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.notes = '';
this.phone = '';

		
				}
			}
			export class ApiClientCommunicationRequestModel {
				clientId:number;
clientIdEntity:number;
dateCreated:string;
employeeId:number;
employeeIdEntity:number;
id:number;
notes:string;

	
				constructor() {
					this.clientId = 0;
this.dateCreated = '';
this.employeeId = 0;
this.id = 0;
this.notes = '';

		
				}
			}

			export class ApiClientCommunicationResponseModel {
				clientId:number;
clientIdEntity:number;
dateCreated:string;
employeeId:number;
employeeIdEntity:number;
id:number;
notes:string;

	
				constructor() {
					this.clientId = 0;
this.dateCreated = '';
this.employeeId = 0;
this.id = 0;
this.notes = '';

		
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
			export class ApiCountryRequirementRequestModel {
				countryId:number;
countryIdEntity:number;
details:string;
id:number;

	
				constructor() {
					this.countryId = 0;
this.details = '';
this.id = 0;

		
				}
			}

			export class ApiCountryRequirementResponseModel {
				countryId:number;
countryIdEntity:number;
details:string;
id:number;

	
				constructor() {
					this.countryId = 0;
this.details = '';
this.id = 0;

		
				}
			}
			export class ApiDestinationRequestModel {
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

			export class ApiDestinationResponseModel {
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
			export class ApiEmployeeRequestModel {
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

			export class ApiEmployeeResponseModel {
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
			export class ApiHandlerRequestModel {
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

			export class ApiHandlerResponseModel {
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
			export class ApiHandlerPipelineStepRequestModel {
				handlerId:number;
handlerIdEntity:number;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.handlerId = 0;
this.id = 0;
this.pipelineStepId = 0;

		
				}
			}

			export class ApiHandlerPipelineStepResponseModel {
				handlerId:number;
handlerIdEntity:number;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.handlerId = 0;
this.id = 0;
this.pipelineStepId = 0;

		
				}
			}
			export class ApiOtherTransportRequestModel {
				handlerId:number;
handlerIdEntity:number;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.handlerId = 0;
this.id = 0;
this.pipelineStepId = 0;

		
				}
			}

			export class ApiOtherTransportResponseModel {
				handlerId:number;
handlerIdEntity:number;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.handlerId = 0;
this.id = 0;
this.pipelineStepId = 0;

		
				}
			}
			export class ApiPetRequestModel {
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

			export class ApiPetResponseModel {
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
			export class ApiPipelineRequestModel {
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

			export class ApiPipelineResponseModel {
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
			export class ApiPipelineStatusRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiPipelineStatusResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiPipelineStepRequestModel {
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

			export class ApiPipelineStepResponseModel {
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
			export class ApiPipelineStepDestinationRequestModel {
				destinationId:number;
destinationIdEntity:number;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.destinationId = 0;
this.id = 0;
this.pipelineStepId = 0;

		
				}
			}

			export class ApiPipelineStepDestinationResponseModel {
				destinationId:number;
destinationIdEntity:number;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;

	
				constructor() {
					this.destinationId = 0;
this.id = 0;
this.pipelineStepId = 0;

		
				}
			}
			export class ApiPipelineStepNoteRequestModel {
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

			export class ApiPipelineStepNoteResponseModel {
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
			export class ApiPipelineStepStatusRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiPipelineStepStatusResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiPipelineStepStepRequirementRequestModel {
				details:string;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;
requirementMet:boolean;

	
				constructor() {
					this.details = '';
this.id = 0;
this.pipelineStepId = 0;
this.requirementMet = false;

		
				}
			}

			export class ApiPipelineStepStepRequirementResponseModel {
				details:string;
id:number;
pipelineStepId:number;
pipelineStepIdEntity:number;
requirementMet:boolean;

	
				constructor() {
					this.details = '';
this.id = 0;
this.pipelineStepId = 0;
this.requirementMet = false;

		
				}
			}
			export class ApiSaleRequestModel {
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

			export class ApiSaleResponseModel {
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
			export class ApiSpeciesRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiSpeciesResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}