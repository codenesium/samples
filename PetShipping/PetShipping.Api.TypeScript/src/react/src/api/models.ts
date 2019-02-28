export class AirlineClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

			export class AirlineClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}
			export class AirTransportClientRequestModel {
				airlineId:number;
flightNumber:string;
handlerId:number;
handlerIdEntity : string;
handlerIdNavigation? : HandlerClientResponseModel;
id:number;
landDate:any;
pipelineStepId:number;
takeoffDate:any;

	
				constructor() {
					this.airlineId = 0;
this.flightNumber = '';
this.handlerId = 0;
this.handlerIdEntity = '';
this.handlerIdNavigation = undefined;
this.id = 0;
this.landDate = undefined;
this.pipelineStepId = 0;
this.takeoffDate = undefined;

				}

				setProperties(airlineId : number,flightNumber : string,handlerId : number,id : number,landDate : any,pipelineStepId : number,takeoffDate : any) : void
				{
					this.airlineId = airlineId;
this.flightNumber = flightNumber;
this.handlerId = handlerId;
this.id = id;
this.landDate = landDate;
this.pipelineStepId = pipelineStepId;
this.takeoffDate = takeoffDate;

				}
			}

			export class AirTransportClientResponseModel {
				airlineId:number;
flightNumber:string;
handlerId:number;
handlerIdEntity : string;
handlerIdNavigation? : HandlerClientResponseModel;
id:number;
landDate:any;
pipelineStepId:number;
takeoffDate:any;

	
				constructor() {
					this.airlineId = 0;
this.flightNumber = '';
this.handlerId = 0;
this.handlerIdEntity = '';
this.handlerIdNavigation = undefined;
this.id = 0;
this.landDate = undefined;
this.pipelineStepId = 0;
this.takeoffDate = undefined;

				}

				setProperties(airlineId : number,flightNumber : string,handlerId : number,id : number,landDate : any,pipelineStepId : number,takeoffDate : any) : void
				{
					this.airlineId = airlineId;
this.flightNumber = flightNumber;
this.handlerId = handlerId;
this.id = id;
this.landDate = landDate;
this.pipelineStepId = pipelineStepId;
this.takeoffDate = takeoffDate;

				}
			}
			export class BreedClientRequestModel {
				id:number;
name:string;
speciesId:number;
speciesIdEntity : string;
speciesIdNavigation? : SpeciesClientResponseModel;

	
				constructor() {
					this.id = 0;
this.name = '';
this.speciesId = 0;
this.speciesIdEntity = '';
this.speciesIdNavigation = undefined;

				}

				setProperties(id : number,name : string,speciesId : number) : void
				{
					this.id = id;
this.name = name;
this.speciesId = speciesId;

				}
			}

			export class BreedClientResponseModel {
				id:number;
name:string;
speciesId:number;
speciesIdEntity : string;
speciesIdNavigation? : SpeciesClientResponseModel;

	
				constructor() {
					this.id = 0;
this.name = '';
this.speciesId = 0;
this.speciesIdEntity = '';
this.speciesIdNavigation = undefined;

				}

				setProperties(id : number,name : string,speciesId : number) : void
				{
					this.id = id;
this.name = name;
this.speciesId = speciesId;

				}
			}
			export class CountryClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

			export class CountryClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}
			export class CountryRequirementClientRequestModel {
				countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryClientResponseModel;
detail:string;
id:number;

	
				constructor() {
					this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = undefined;
this.detail = '';
this.id = 0;

				}

				setProperties(countryId : number,detail : string,id : number) : void
				{
					this.countryId = countryId;
this.detail = detail;
this.id = id;

				}
			}

			export class CountryRequirementClientResponseModel {
				countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryClientResponseModel;
detail:string;
id:number;

	
				constructor() {
					this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = undefined;
this.detail = '';
this.id = 0;

				}

				setProperties(countryId : number,detail : string,id : number) : void
				{
					this.countryId = countryId;
this.detail = detail;
this.id = id;

				}
			}
			export class CustomerClientRequestModel {
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

				setProperties(email : string,firstName : string,id : number,lastName : string,note : string,phone : string) : void
				{
					this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.note = note;
this.phone = phone;

				}
			}

			export class CustomerClientResponseModel {
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

				setProperties(email : string,firstName : string,id : number,lastName : string,note : string,phone : string) : void
				{
					this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.note = note;
this.phone = phone;

				}
			}
			export class CustomerCommunicationClientRequestModel {
				customerId:number;
customerIdEntity : string;
customerIdNavigation? : CustomerClientResponseModel;
dateCreated:any;
employeeId:number;
employeeIdEntity : string;
employeeIdNavigation? : EmployeeClientResponseModel;
id:number;
note:string;

	
				constructor() {
					this.customerId = 0;
this.customerIdEntity = '';
this.customerIdNavigation = undefined;
this.dateCreated = undefined;
this.employeeId = 0;
this.employeeIdEntity = '';
this.employeeIdNavigation = undefined;
this.id = 0;
this.note = '';

				}

				setProperties(customerId : number,dateCreated : any,employeeId : number,id : number,note : string) : void
				{
					this.customerId = customerId;
this.dateCreated = dateCreated;
this.employeeId = employeeId;
this.id = id;
this.note = note;

				}
			}

			export class CustomerCommunicationClientResponseModel {
				customerId:number;
customerIdEntity : string;
customerIdNavigation? : CustomerClientResponseModel;
dateCreated:any;
employeeId:number;
employeeIdEntity : string;
employeeIdNavigation? : EmployeeClientResponseModel;
id:number;
note:string;

	
				constructor() {
					this.customerId = 0;
this.customerIdEntity = '';
this.customerIdNavigation = undefined;
this.dateCreated = undefined;
this.employeeId = 0;
this.employeeIdEntity = '';
this.employeeIdNavigation = undefined;
this.id = 0;
this.note = '';

				}

				setProperties(customerId : number,dateCreated : any,employeeId : number,id : number,note : string) : void
				{
					this.customerId = customerId;
this.dateCreated = dateCreated;
this.employeeId = employeeId;
this.id = id;
this.note = note;

				}
			}
			export class DestinationClientRequestModel {
				countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryClientResponseModel;
id:number;
name:string;
order:number;

	
				constructor() {
					this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = undefined;
this.id = 0;
this.name = '';
this.order = 0;

				}

				setProperties(countryId : number,id : number,name : string,order : number) : void
				{
					this.countryId = countryId;
this.id = id;
this.name = name;
this.order = order;

				}
			}

			export class DestinationClientResponseModel {
				countryId:number;
countryIdEntity : string;
countryIdNavigation? : CountryClientResponseModel;
id:number;
name:string;
order:number;

	
				constructor() {
					this.countryId = 0;
this.countryIdEntity = '';
this.countryIdNavigation = undefined;
this.id = 0;
this.name = '';
this.order = 0;

				}

				setProperties(countryId : number,id : number,name : string,order : number) : void
				{
					this.countryId = countryId;
this.id = id;
this.name = name;
this.order = order;

				}
			}
			export class EmployeeClientRequestModel {
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

				setProperties(firstName : string,id : number,isSalesPerson : boolean,isShipper : boolean,lastName : string) : void
				{
					this.firstName = firstName;
this.id = id;
this.isSalesPerson = isSalesPerson;
this.isShipper = isShipper;
this.lastName = lastName;

				}
			}

			export class EmployeeClientResponseModel {
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

				setProperties(firstName : string,id : number,isSalesPerson : boolean,isShipper : boolean,lastName : string) : void
				{
					this.firstName = firstName;
this.id = id;
this.isSalesPerson = isSalesPerson;
this.isShipper = isShipper;
this.lastName = lastName;

				}
			}
			export class HandlerClientRequestModel {
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

				setProperties(countryId : number,email : string,firstName : string,id : number,lastName : string,phone : string) : void
				{
					this.countryId = countryId;
this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.phone = phone;

				}
			}

			export class HandlerClientResponseModel {
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

				setProperties(countryId : number,email : string,firstName : string,id : number,lastName : string,phone : string) : void
				{
					this.countryId = countryId;
this.email = email;
this.firstName = firstName;
this.id = id;
this.lastName = lastName;
this.phone = phone;

				}
			}
			export class HandlerPipelineStepClientRequestModel {
				handlerId:number;
handlerIdEntity : string;
handlerIdNavigation? : HandlerClientResponseModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.handlerId = 0;
this.handlerIdEntity = '';
this.handlerIdNavigation = undefined;
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(handlerId : number,id : number,pipelineStepId : number) : void
				{
					this.handlerId = handlerId;
this.id = id;
this.pipelineStepId = pipelineStepId;

				}
			}

			export class HandlerPipelineStepClientResponseModel {
				handlerId:number;
handlerIdEntity : string;
handlerIdNavigation? : HandlerClientResponseModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.handlerId = 0;
this.handlerIdEntity = '';
this.handlerIdNavigation = undefined;
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(handlerId : number,id : number,pipelineStepId : number) : void
				{
					this.handlerId = handlerId;
this.id = id;
this.pipelineStepId = pipelineStepId;

				}
			}
			export class OtherTransportClientRequestModel {
				handlerId:number;
handlerIdEntity : string;
handlerIdNavigation? : HandlerClientResponseModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.handlerId = 0;
this.handlerIdEntity = '';
this.handlerIdNavigation = undefined;
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(handlerId : number,id : number,pipelineStepId : number) : void
				{
					this.handlerId = handlerId;
this.id = id;
this.pipelineStepId = pipelineStepId;

				}
			}

			export class OtherTransportClientResponseModel {
				handlerId:number;
handlerIdEntity : string;
handlerIdNavigation? : HandlerClientResponseModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.handlerId = 0;
this.handlerIdEntity = '';
this.handlerIdNavigation = undefined;
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(handlerId : number,id : number,pipelineStepId : number) : void
				{
					this.handlerId = handlerId;
this.id = id;
this.pipelineStepId = pipelineStepId;

				}
			}
			export class PetClientRequestModel {
				breedId:number;
breedIdEntity : string;
breedIdNavigation? : BreedClientResponseModel;
clientId:number;
id:number;
name:string;
weight:number;

	
				constructor() {
					this.breedId = 0;
this.breedIdEntity = '';
this.breedIdNavigation = undefined;
this.clientId = 0;
this.id = 0;
this.name = '';
this.weight = 0;

				}

				setProperties(breedId : number,clientId : number,id : number,name : string,weight : number) : void
				{
					this.breedId = breedId;
this.clientId = clientId;
this.id = id;
this.name = name;
this.weight = weight;

				}
			}

			export class PetClientResponseModel {
				breedId:number;
breedIdEntity : string;
breedIdNavigation? : BreedClientResponseModel;
clientId:number;
id:number;
name:string;
weight:number;

	
				constructor() {
					this.breedId = 0;
this.breedIdEntity = '';
this.breedIdNavigation = undefined;
this.clientId = 0;
this.id = 0;
this.name = '';
this.weight = 0;

				}

				setProperties(breedId : number,clientId : number,id : number,name : string,weight : number) : void
				{
					this.breedId = breedId;
this.clientId = clientId;
this.id = id;
this.name = name;
this.weight = weight;

				}
			}
			export class PipelineClientRequestModel {
				id:number;
pipelineStatusId:number;
pipelineStatusIdEntity : string;
pipelineStatusIdNavigation? : PipelineStatusClientResponseModel;
saleId:number;

	
				constructor() {
					this.id = 0;
this.pipelineStatusId = 0;
this.pipelineStatusIdEntity = '';
this.pipelineStatusIdNavigation = undefined;
this.saleId = 0;

				}

				setProperties(id : number,pipelineStatusId : number,saleId : number) : void
				{
					this.id = id;
this.pipelineStatusId = pipelineStatusId;
this.saleId = saleId;

				}
			}

			export class PipelineClientResponseModel {
				id:number;
pipelineStatusId:number;
pipelineStatusIdEntity : string;
pipelineStatusIdNavigation? : PipelineStatusClientResponseModel;
saleId:number;

	
				constructor() {
					this.id = 0;
this.pipelineStatusId = 0;
this.pipelineStatusIdEntity = '';
this.pipelineStatusIdNavigation = undefined;
this.saleId = 0;

				}

				setProperties(id : number,pipelineStatusId : number,saleId : number) : void
				{
					this.id = id;
this.pipelineStatusId = pipelineStatusId;
this.saleId = saleId;

				}
			}
			export class PipelineStatusClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

			export class PipelineStatusClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}
			export class PipelineStepClientRequestModel {
				id:number;
name:string;
pipelineStepStatusId:number;
pipelineStepStatusIdEntity : string;
pipelineStepStatusIdNavigation? : PipelineStepStatusClientResponseModel;
shipperId:number;
shipperIdEntity : string;
shipperIdNavigation? : EmployeeClientResponseModel;

	
				constructor() {
					this.id = 0;
this.name = '';
this.pipelineStepStatusId = 0;
this.pipelineStepStatusIdEntity = '';
this.pipelineStepStatusIdNavigation = undefined;
this.shipperId = 0;
this.shipperIdEntity = '';
this.shipperIdNavigation = undefined;

				}

				setProperties(id : number,name : string,pipelineStepStatusId : number,shipperId : number) : void
				{
					this.id = id;
this.name = name;
this.pipelineStepStatusId = pipelineStepStatusId;
this.shipperId = shipperId;

				}
			}

			export class PipelineStepClientResponseModel {
				id:number;
name:string;
pipelineStepStatusId:number;
pipelineStepStatusIdEntity : string;
pipelineStepStatusIdNavigation? : PipelineStepStatusClientResponseModel;
shipperId:number;
shipperIdEntity : string;
shipperIdNavigation? : EmployeeClientResponseModel;

	
				constructor() {
					this.id = 0;
this.name = '';
this.pipelineStepStatusId = 0;
this.pipelineStepStatusIdEntity = '';
this.pipelineStepStatusIdNavigation = undefined;
this.shipperId = 0;
this.shipperIdEntity = '';
this.shipperIdNavigation = undefined;

				}

				setProperties(id : number,name : string,pipelineStepStatusId : number,shipperId : number) : void
				{
					this.id = id;
this.name = name;
this.pipelineStepStatusId = pipelineStepStatusId;
this.shipperId = shipperId;

				}
			}
			export class PipelineStepDestinationClientRequestModel {
				destinationId:number;
destinationIdEntity : string;
destinationIdNavigation? : DestinationClientResponseModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.destinationId = 0;
this.destinationIdEntity = '';
this.destinationIdNavigation = undefined;
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(destinationId : number,id : number,pipelineStepId : number) : void
				{
					this.destinationId = destinationId;
this.id = id;
this.pipelineStepId = pipelineStepId;

				}
			}

			export class PipelineStepDestinationClientResponseModel {
				destinationId:number;
destinationIdEntity : string;
destinationIdNavigation? : DestinationClientResponseModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.destinationId = 0;
this.destinationIdEntity = '';
this.destinationIdNavigation = undefined;
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(destinationId : number,id : number,pipelineStepId : number) : void
				{
					this.destinationId = destinationId;
this.id = id;
this.pipelineStepId = pipelineStepId;

				}
			}
			export class PipelineStepNoteClientRequestModel {
				employeeId:number;
employeeIdEntity : string;
employeeIdNavigation? : EmployeeClientResponseModel;
id:number;
note:string;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.employeeId = 0;
this.employeeIdEntity = '';
this.employeeIdNavigation = undefined;
this.id = 0;
this.note = '';
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(employeeId : number,id : number,note : string,pipelineStepId : number) : void
				{
					this.employeeId = employeeId;
this.id = id;
this.note = note;
this.pipelineStepId = pipelineStepId;

				}
			}

			export class PipelineStepNoteClientResponseModel {
				employeeId:number;
employeeIdEntity : string;
employeeIdNavigation? : EmployeeClientResponseModel;
id:number;
note:string;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;

	
				constructor() {
					this.employeeId = 0;
this.employeeIdEntity = '';
this.employeeIdNavigation = undefined;
this.id = 0;
this.note = '';
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;

				}

				setProperties(employeeId : number,id : number,note : string,pipelineStepId : number) : void
				{
					this.employeeId = employeeId;
this.id = id;
this.note = note;
this.pipelineStepId = pipelineStepId;

				}
			}
			export class PipelineStepStatusClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

			export class PipelineStepStatusClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}
			export class PipelineStepStepRequirementClientRequestModel {
				detail:string;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;
requirementMet:boolean;

	
				constructor() {
					this.detail = '';
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;
this.requirementMet = false;

				}

				setProperties(detail : string,id : number,pipelineStepId : number,requirementMet : boolean) : void
				{
					this.detail = detail;
this.id = id;
this.pipelineStepId = pipelineStepId;
this.requirementMet = requirementMet;

				}
			}

			export class PipelineStepStepRequirementClientResponseModel {
				detail:string;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepClientResponseModel;
requirementMet:boolean;

	
				constructor() {
					this.detail = '';
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = undefined;
this.requirementMet = false;

				}

				setProperties(detail : string,id : number,pipelineStepId : number,requirementMet : boolean) : void
				{
					this.detail = detail;
this.id = id;
this.pipelineStepId = pipelineStepId;
this.requirementMet = requirementMet;

				}
			}
			export class SaleClientRequestModel {
				amount:number;
cutomerId:number;
id:number;
note:string;
petId:number;
petIdEntity : string;
petIdNavigation? : PetClientResponseModel;
saleDate:any;
salesPersonId:number;

	
				constructor() {
					this.amount = 0;
this.cutomerId = 0;
this.id = 0;
this.note = '';
this.petId = 0;
this.petIdEntity = '';
this.petIdNavigation = undefined;
this.saleDate = undefined;
this.salesPersonId = 0;

				}

				setProperties(amount : number,cutomerId : number,id : number,note : string,petId : number,saleDate : any,salesPersonId : number) : void
				{
					this.amount = amount;
this.cutomerId = cutomerId;
this.id = id;
this.note = note;
this.petId = petId;
this.saleDate = saleDate;
this.salesPersonId = salesPersonId;

				}
			}

			export class SaleClientResponseModel {
				amount:number;
cutomerId:number;
id:number;
note:string;
petId:number;
petIdEntity : string;
petIdNavigation? : PetClientResponseModel;
saleDate:any;
salesPersonId:number;

	
				constructor() {
					this.amount = 0;
this.cutomerId = 0;
this.id = 0;
this.note = '';
this.petId = 0;
this.petIdEntity = '';
this.petIdNavigation = undefined;
this.saleDate = undefined;
this.salesPersonId = 0;

				}

				setProperties(amount : number,cutomerId : number,id : number,note : string,petId : number,saleDate : any,salesPersonId : number) : void
				{
					this.amount = amount;
this.cutomerId = cutomerId;
this.id = id;
this.note = note;
this.petId = petId;
this.saleDate = saleDate;
this.salesPersonId = salesPersonId;

				}
			}
			export class SpeciesClientRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

			export class SpeciesClientResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

				}

				setProperties(id : number,name : string) : void
				{
					this.id = id;
this.name = name;

				}
			}

/*<Codenesium>
    <Hash>dc0d8e9a095e122793882252518b794d</Hash>
</Codenesium>*/