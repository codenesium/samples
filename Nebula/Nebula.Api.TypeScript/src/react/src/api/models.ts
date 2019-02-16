export class ChainClientRequestModel {
				chainStatusId:number;
chainStatusIdEntity : string;
chainStatusIdNavigation? : ChainStatusClientResponseModel;
externalId:any;
id:number;
name:string;
teamId:number;
teamIdEntity : string;
teamIdNavigation? : TeamClientResponseModel;

	
				constructor() {
					this.chainStatusId = 0;
this.chainStatusIdEntity = '';
this.chainStatusIdNavigation = undefined;
this.externalId = undefined;
this.id = 0;
this.name = '';
this.teamId = 0;
this.teamIdEntity = '';
this.teamIdNavigation = undefined;

				}

				setProperties(chainStatusId : number,externalId : any,id : number,name : string,teamId : number) : void
				{
					this.chainStatusId = chainStatusId;
this.externalId = externalId;
this.id = id;
this.name = name;
this.teamId = teamId;

				}
			}

			export class ChainClientResponseModel {
				chainStatusId:number;
chainStatusIdEntity : string;
chainStatusIdNavigation? : ChainStatusClientResponseModel;
externalId:any;
id:number;
name:string;
teamId:number;
teamIdEntity : string;
teamIdNavigation? : TeamClientResponseModel;

	
				constructor() {
					this.chainStatusId = 0;
this.chainStatusIdEntity = '';
this.chainStatusIdNavigation = undefined;
this.externalId = undefined;
this.id = 0;
this.name = '';
this.teamId = 0;
this.teamIdEntity = '';
this.teamIdNavigation = undefined;

				}

				setProperties(chainStatusId : number,externalId : any,id : number,name : string,teamId : number) : void
				{
					this.chainStatusId = chainStatusId;
this.externalId = externalId;
this.id = id;
this.name = name;
this.teamId = teamId;

				}
			}
			export class ChainStatusClientRequestModel {
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

			export class ChainStatusClientResponseModel {
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
			export class ClaspClientRequestModel {
				id:number;
nextChainId:number;
nextChainIdEntity : string;
nextChainIdNavigation? : ChainClientResponseModel;
previousChainId:number;
previousChainIdEntity : string;
previousChainIdNavigation? : ChainClientResponseModel;

	
				constructor() {
					this.id = 0;
this.nextChainId = 0;
this.nextChainIdEntity = '';
this.nextChainIdNavigation = undefined;
this.previousChainId = 0;
this.previousChainIdEntity = '';
this.previousChainIdNavigation = undefined;

				}

				setProperties(id : number,nextChainId : number,previousChainId : number) : void
				{
					this.id = id;
this.nextChainId = nextChainId;
this.previousChainId = previousChainId;

				}
			}

			export class ClaspClientResponseModel {
				id:number;
nextChainId:number;
nextChainIdEntity : string;
nextChainIdNavigation? : ChainClientResponseModel;
previousChainId:number;
previousChainIdEntity : string;
previousChainIdNavigation? : ChainClientResponseModel;

	
				constructor() {
					this.id = 0;
this.nextChainId = 0;
this.nextChainIdEntity = '';
this.nextChainIdNavigation = undefined;
this.previousChainId = 0;
this.previousChainIdEntity = '';
this.previousChainIdNavigation = undefined;

				}

				setProperties(id : number,nextChainId : number,previousChainId : number) : void
				{
					this.id = id;
this.nextChainId = nextChainId;
this.previousChainId = previousChainId;

				}
			}
			export class LinkClientRequestModel {
				assignedMachineId:any;
assignedMachineIdEntity : string;
assignedMachineIdNavigation? : MachineClientResponseModel;
chainId:number;
chainIdEntity : string;
chainIdNavigation? : ChainClientResponseModel;
dateCompleted:any;
dateStarted:any;
dynamicParameter:string;
externalId:any;
id:number;
linkStatusId:number;
linkStatusIdEntity : string;
linkStatusIdNavigation? : LinkStatusClientResponseModel;
name:string;
order:number;
response:string;
staticParameter:string;
timeoutInSecond:number;

	
				constructor() {
					this.assignedMachineId = undefined;
this.assignedMachineIdEntity = '';
this.assignedMachineIdNavigation = undefined;
this.chainId = 0;
this.chainIdEntity = '';
this.chainIdNavigation = undefined;
this.dateCompleted = undefined;
this.dateStarted = undefined;
this.dynamicParameter = '';
this.externalId = undefined;
this.id = 0;
this.linkStatusId = 0;
this.linkStatusIdEntity = '';
this.linkStatusIdNavigation = undefined;
this.name = '';
this.order = 0;
this.response = '';
this.staticParameter = '';
this.timeoutInSecond = 0;

				}

				setProperties(assignedMachineId : any,chainId : number,dateCompleted : any,dateStarted : any,dynamicParameter : string,externalId : any,id : number,linkStatusId : number,name : string,order : number,response : string,staticParameter : string,timeoutInSecond : number) : void
				{
					this.assignedMachineId = assignedMachineId;
this.chainId = chainId;
this.dateCompleted = dateCompleted;
this.dateStarted = dateStarted;
this.dynamicParameter = dynamicParameter;
this.externalId = externalId;
this.id = id;
this.linkStatusId = linkStatusId;
this.name = name;
this.order = order;
this.response = response;
this.staticParameter = staticParameter;
this.timeoutInSecond = timeoutInSecond;

				}
			}

			export class LinkClientResponseModel {
				assignedMachineId:any;
assignedMachineIdEntity : string;
assignedMachineIdNavigation? : MachineClientResponseModel;
chainId:number;
chainIdEntity : string;
chainIdNavigation? : ChainClientResponseModel;
dateCompleted:any;
dateStarted:any;
dynamicParameter:string;
externalId:any;
id:number;
linkStatusId:number;
linkStatusIdEntity : string;
linkStatusIdNavigation? : LinkStatusClientResponseModel;
name:string;
order:number;
response:string;
staticParameter:string;
timeoutInSecond:number;

	
				constructor() {
					this.assignedMachineId = undefined;
this.assignedMachineIdEntity = '';
this.assignedMachineIdNavigation = undefined;
this.chainId = 0;
this.chainIdEntity = '';
this.chainIdNavigation = undefined;
this.dateCompleted = undefined;
this.dateStarted = undefined;
this.dynamicParameter = '';
this.externalId = undefined;
this.id = 0;
this.linkStatusId = 0;
this.linkStatusIdEntity = '';
this.linkStatusIdNavigation = undefined;
this.name = '';
this.order = 0;
this.response = '';
this.staticParameter = '';
this.timeoutInSecond = 0;

				}

				setProperties(assignedMachineId : any,chainId : number,dateCompleted : any,dateStarted : any,dynamicParameter : string,externalId : any,id : number,linkStatusId : number,name : string,order : number,response : string,staticParameter : string,timeoutInSecond : number) : void
				{
					this.assignedMachineId = assignedMachineId;
this.chainId = chainId;
this.dateCompleted = dateCompleted;
this.dateStarted = dateStarted;
this.dynamicParameter = dynamicParameter;
this.externalId = externalId;
this.id = id;
this.linkStatusId = linkStatusId;
this.name = name;
this.order = order;
this.response = response;
this.staticParameter = staticParameter;
this.timeoutInSecond = timeoutInSecond;

				}
			}
			export class LinkLogClientRequestModel {
				dateEntered:any;
id:number;
linkId:number;
linkIdEntity : string;
linkIdNavigation? : LinkClientResponseModel;
log:string;

	
				constructor() {
					this.dateEntered = undefined;
this.id = 0;
this.linkId = 0;
this.linkIdEntity = '';
this.linkIdNavigation = undefined;
this.log = '';

				}

				setProperties(dateEntered : any,id : number,linkId : number,log : string) : void
				{
					this.dateEntered = dateEntered;
this.id = id;
this.linkId = linkId;
this.log = log;

				}
			}

			export class LinkLogClientResponseModel {
				dateEntered:any;
id:number;
linkId:number;
linkIdEntity : string;
linkIdNavigation? : LinkClientResponseModel;
log:string;

	
				constructor() {
					this.dateEntered = undefined;
this.id = 0;
this.linkId = 0;
this.linkIdEntity = '';
this.linkIdNavigation = undefined;
this.log = '';

				}

				setProperties(dateEntered : any,id : number,linkId : number,log : string) : void
				{
					this.dateEntered = dateEntered;
this.id = id;
this.linkId = linkId;
this.log = log;

				}
			}
			export class LinkStatusClientRequestModel {
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

			export class LinkStatusClientResponseModel {
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
			export class MachineClientRequestModel {
				description:string;
id:number;
jwtKey:string;
lastIpAddress:string;
machineGuid:any;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.jwtKey = '';
this.lastIpAddress = '';
this.machineGuid = undefined;
this.name = '';

				}

				setProperties(description : string,id : number,jwtKey : string,lastIpAddress : string,machineGuid : any,name : string) : void
				{
					this.description = description;
this.id = id;
this.jwtKey = jwtKey;
this.lastIpAddress = lastIpAddress;
this.machineGuid = machineGuid;
this.name = name;

				}
			}

			export class MachineClientResponseModel {
				description:string;
id:number;
jwtKey:string;
lastIpAddress:string;
machineGuid:any;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.jwtKey = '';
this.lastIpAddress = '';
this.machineGuid = undefined;
this.name = '';

				}

				setProperties(description : string,id : number,jwtKey : string,lastIpAddress : string,machineGuid : any,name : string) : void
				{
					this.description = description;
this.id = id;
this.jwtKey = jwtKey;
this.lastIpAddress = lastIpAddress;
this.machineGuid = machineGuid;
this.name = name;

				}
			}
			export class OrganizationClientRequestModel {
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

			export class OrganizationClientResponseModel {
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
			export class TeamClientRequestModel {
				id:number;
name:string;
organizationId:number;
organizationIdEntity : string;
organizationIdNavigation? : OrganizationClientResponseModel;

	
				constructor() {
					this.id = 0;
this.name = '';
this.organizationId = 0;
this.organizationIdEntity = '';
this.organizationIdNavigation = undefined;

				}

				setProperties(id : number,name : string,organizationId : number) : void
				{
					this.id = id;
this.name = name;
this.organizationId = organizationId;

				}
			}

			export class TeamClientResponseModel {
				id:number;
name:string;
organizationId:number;
organizationIdEntity : string;
organizationIdNavigation? : OrganizationClientResponseModel;

	
				constructor() {
					this.id = 0;
this.name = '';
this.organizationId = 0;
this.organizationIdEntity = '';
this.organizationIdNavigation = undefined;

				}

				setProperties(id : number,name : string,organizationId : number) : void
				{
					this.id = id;
this.name = name;
this.organizationId = organizationId;

				}
			}

/*<Codenesium>
    <Hash>3068f30ae77175cde34699aa8b11ffa6</Hash>
</Codenesium>*/