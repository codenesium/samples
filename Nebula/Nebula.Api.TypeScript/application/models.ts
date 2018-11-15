export class ApiChainStatusServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiChainStatusServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiLinkServerRequestModel {
				assignedMachineId:number;
assignedMachineIdEntity:number;
chainId:number;
chainIdEntity:number;
dateCompleted:string;
dateStarted:string;
dynamicParameter:string;
externalId:string;
id:number;
linkStatusId:number;
linkStatusIdEntity:number;
name:string;
order:number;
response:string;
staticParameter:string;
timeoutInSecond:number;

	
				constructor() {
					this.assignedMachineId = 0;
this.chainId = 0;
this.dateCompleted = '';
this.dateStarted = '';
this.dynamicParameter = '';
this.externalId = '';
this.id = 0;
this.linkStatusId = 0;
this.name = '';
this.order = 0;
this.response = '';
this.staticParameter = '';
this.timeoutInSecond = 0;

		
				}
			}

			export class ApiLinkServerResponseModel {
				assignedMachineId:number;
assignedMachineIdEntity:number;
chainId:number;
chainIdEntity:number;
dateCompleted:string;
dateStarted:string;
dynamicParameter:string;
externalId:string;
id:number;
linkStatusId:number;
linkStatusIdEntity:number;
name:string;
order:number;
response:string;
staticParameter:string;
timeoutInSecond:number;

	
				constructor() {
					this.assignedMachineId = 0;
this.chainId = 0;
this.dateCompleted = '';
this.dateStarted = '';
this.dynamicParameter = '';
this.externalId = '';
this.id = 0;
this.linkStatusId = 0;
this.name = '';
this.order = 0;
this.response = '';
this.staticParameter = '';
this.timeoutInSecond = 0;

		
				}
			}
			export class ApiLinkLogServerRequestModel {
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

			export class ApiLinkLogServerResponseModel {
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
			export class ApiLinkStatusServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiLinkStatusServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiMachineServerRequestModel {
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

			export class ApiMachineServerResponseModel {
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
			export class ApiOrganizationServerRequestModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}

			export class ApiOrganizationServerResponseModel {
				id:number;
name:string;

	
				constructor() {
					this.id = 0;
this.name = '';

		
				}
			}
			export class ApiTeamServerRequestModel {
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

			export class ApiTeamServerResponseModel {
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
			export class ApiVersionInfoServerRequestModel {
				appliedOn:string;
description:string;
version:number;

	
				constructor() {
					this.appliedOn = '';
this.description = '';
this.version = 0;

		
				}
			}

			export class ApiVersionInfoServerResponseModel {
				appliedOn:string;
description:string;
version:number;

	
				constructor() {
					this.appliedOn = '';
this.description = '';
this.version = 0;

		
				}
			}