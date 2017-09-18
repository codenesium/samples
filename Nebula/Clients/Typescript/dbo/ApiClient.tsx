export class ReferenceEntity<T> {
    ReferenceObjectName:string;
    Value :T;
    Href:string;
}export class ApiChainModel {
    chainStatusId:ReferenceEntity<number>;
externalId:any;
id:number;
name:string;
teamId:ReferenceEntity<number>;

	
    constructor() {
		this.chainStatusId = new ReferenceEntity<number>();
this.externalId = "00000000-0000-0000-0000-000000000000";
this.id = 0;
this.name = '';
this.teamId = new ReferenceEntity<number>();

		
    }
};export class ApiChainStatusModel {
    id:number;
name:string;

	
    constructor() {
		this.id = 0;
this.name = '';

		
    }
};export class ApiClaspModel {
    id:number;
nextChainId:ReferenceEntity<number>;
previousChainId:ReferenceEntity<number>;

	
    constructor() {
		this.id = 0;
this.nextChainId = new ReferenceEntity<number>();
this.previousChainId = new ReferenceEntity<number>();

		
    }
};export class ApiLinkModel {
    assignedMachineId:ReferenceEntity<number>;
chainId:ReferenceEntity<number>;
dateCompleted:string;
dateStarted:string;
dynamicParameters:string;
externalId:any;
id:number;
linkStatusId:ReferenceEntity<number>;
name:string;
order:number;
response:string;
staticParameters:string;

	
    constructor() {
		this.assignedMachineId = new ReferenceEntity<number>();
this.chainId = new ReferenceEntity<number>();
this.dateCompleted = '';
this.dateStarted = '';
this.dynamicParameters = '';
this.externalId = "00000000-0000-0000-0000-000000000000";
this.id = 0;
this.linkStatusId = new ReferenceEntity<number>();
this.name = '';
this.order = 0;
this.response = '';
this.staticParameters = '';

		
    }
};export class ApiLinkLogModel {
    dateEntered:string;
id:number;
linkId:ReferenceEntity<number>;
log:string;

	
    constructor() {
		this.dateEntered = '';
this.id = 0;
this.linkId = new ReferenceEntity<number>();
this.log = '';

		
    }
};export class ApiLinkStatusModel {
    id:number;
name:string;

	
    constructor() {
		this.id = 0;
this.name = '';

		
    }
};export class ApiMachineModel {
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
this.machineGuid = "00000000-0000-0000-0000-000000000000";
this.name = '';

		
    }
};export class ApiMachineRefTeamModel {
    id:number;
machineId:ReferenceEntity<number>;
teamId:ReferenceEntity<number>;

	
    constructor() {
		this.id = 0;
this.machineId = new ReferenceEntity<number>();
this.teamId = new ReferenceEntity<number>();

		
    }
};export class ApiOrganizationModel {
    id:number;
name:string;

	
    constructor() {
		this.id = 0;
this.name = '';

		
    }
};export class ApiTeamModel {
    id:number;
name:string;
organizationId:ReferenceEntity<number>;

	
    constructor() {
		this.id = 0;
this.name = '';
this.organizationId = new ReferenceEntity<number>();

		
    }
};export class Response {
	chains : Array<ApiChainModel>;
		chainStatus : Array<ApiChainStatusModel>;
		clasps : Array<ApiClaspModel>;
		links : Array<ApiLinkModel>;
		linkLogs : Array<ApiLinkLogModel>;
		linkStatus : Array<ApiLinkStatusModel>;
		machines : Array<ApiMachineModel>;
		machineRefTeams : Array<ApiMachineRefTeamModel>;
		organizations : Array<ApiOrganizationModel>;
		teams : Array<ApiTeamModel>;
	}