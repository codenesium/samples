export class ApiChainRequestModel {
				chainStatusId:number;
chainStatusIdEntity:number;
externalId:string;
id:number;
name:string;
teamId:number;
teamIdEntity:number;

	
				constructor() {
					this.chainStatusId = 0;
this.externalId = '';
this.id = 0;
this.name = '';
this.teamId = 0;

		
				}
			}

			export class ApiChainResponseModel {
				chainStatusId:number;
chainStatusIdEntity:number;
externalId:string;
id:number;
name:string;
teamId:number;
teamIdEntity:number;

	
				constructor() {
					this.chainStatusId = 0;
this.externalId = '';
this.id = 0;
this.name = '';
this.teamId = 0;

		
				}
			}
			export class ApiChainStatusRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiChainStatusResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiClaspRequestModel {
				id:number;
nextChainId:number;
nextChainIdEntity:number;
previousChainId:number;
previousChainIdEntity:number;

	
				constructor() {
					this.id = 0;
this.nextChainId = 0;
this.previousChainId = 0;

		
				}
			}

			export class ApiClaspResponseModel {
				id:number;
nextChainId:number;
nextChainIdEntity:number;
previousChainId:number;
previousChainIdEntity:number;

	
				constructor() {
					this.id = 0;
this.nextChainId = 0;
this.previousChainId = 0;

		
				}
			}
			export class ApiLinkRequestModel {
				assignedMachineId:number;
assignedMachineIdEntity:number;
chainId:number;
chainIdEntity:number;
dateCompleted:string;
dateStarted:string;
dynamicParameters:string;
externalId:string;
id:number;
linkStatusId:number;
linkStatusIdEntity:number;
name:string;
order:number;
response:string;
staticParameters:string;
timeoutInSeconds:number;

	
				constructor() {
					this.assignedMachineId = 0;
this.chainId = 0;
this.dateCompleted = '';
this.dateStarted = '';
this.dynamicParameters = '';
this.externalId = '';
this.id = 0;
this.linkStatusId = 0;
this.name = '';
this.order = 0;
this.response = '';
this.staticParameters = '';
this.timeoutInSeconds = 0;

		
				}
			}

			export class ApiLinkResponseModel {
				assignedMachineId:number;
assignedMachineIdEntity:number;
chainId:number;
chainIdEntity:number;
dateCompleted:string;
dateStarted:string;
dynamicParameters:string;
externalId:string;
id:number;
linkStatusId:number;
linkStatusIdEntity:number;
name:string;
order:number;
response:string;
staticParameters:string;
timeoutInSeconds:number;

	
				constructor() {
					this.assignedMachineId = 0;
this.chainId = 0;
this.dateCompleted = '';
this.dateStarted = '';
this.dynamicParameters = '';
this.externalId = '';
this.id = 0;
this.linkStatusId = 0;
this.name = '';
this.order = 0;
this.response = '';
this.staticParameters = '';
this.timeoutInSeconds = 0;

		
				}
			}
			export class ApiLinkLogRequestModel {
				dateEntered:string;
id:number;
linkId:number;
linkIdEntity:number;
log:string;

	
				constructor() {
					this.dateEntered = '';
this.id = 0;
this.linkId = 0;
this.log = '';

		
				}
			}

			export class ApiLinkLogResponseModel {
				dateEntered:string;
id:number;
linkId:number;
linkIdEntity:number;
log:string;

	
				constructor() {
					this.dateEntered = '';
this.id = 0;
this.linkId = 0;
this.log = '';

		
				}
			}
			export class ApiLinkStatusRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiLinkStatusResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiMachineRequestModel {
				description:string;
id:number;
jwtKey:string;
lastIpAddress:string;
machineGuid:string;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.jwtKey = '';
this.lastIpAddress = '';
this.machineGuid = '';
this.name = '';

		
				}
			}

			export class ApiMachineResponseModel {
				description:string;
id:number;
jwtKey:string;
lastIpAddress:string;
machineGuid:string;
name:string;

	
				constructor() {
					this.description = '';
this.id = 0;
this.jwtKey = '';
this.lastIpAddress = '';
this.machineGuid = '';
this.name = '';

		
				}
			}
			export class ApiMachineRefTeamRequestModel {
				id:number;
machineId:number;
machineIdEntity:number;
teamId:number;
teamIdEntity:number;

	
				constructor() {
					this.id = 0;
this.machineId = 0;
this.teamId = 0;

		
				}
			}

			export class ApiMachineRefTeamResponseModel {
				id:number;
machineId:number;
machineIdEntity:number;
teamId:number;
teamIdEntity:number;

	
				constructor() {
					this.id = 0;
this.machineId = 0;
this.teamId = 0;

		
				}
			}
			export class ApiOrganizationRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiOrganizationResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiTeamRequestModel {
				id:number;
name:string;
organizationId:number;
organizationIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.organizationId = 0;

		
				}
			}

			export class ApiTeamResponseModel {
				id:number;
name:string;
organizationId:number;
organizationIdEntity:number;

	
				constructor() {
					this.id = 0;
this.name = '';
this.organizationId = 0;

		
				}
			}
			export class ApiVersionInfoRequestModel {
				appliedOn:string;
description:string;
version:number;

	
				constructor() {
					this.appliedOn = '';
this.description = '';
this.version = 0;

		
				}
			}

			export class ApiVersionInfoResponseModel {
				appliedOn:string;
description:string;
version:number;

	
				constructor() {
					this.appliedOn = '';
this.description = '';
this.version = 0;

		
				}
			}