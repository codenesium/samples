export class ApiChainClientRequestModel {
	chainStatusId : number;
	chainStatusIdEntity : string;
	externalId : any;
	id : number;
	name : string;
	teamId : number;
	teamIdEntity : string;

	constructor() {
		this.chainStatusId = 0;
		this.chainStatusIdEntity = '';
		this.externalId = null;
		this.id = 0;
		this.name = '';
		this.teamId = 0;
		this.teamIdEntity = '';
	}
}

export class ApiChainClientResponseModel {
	chainStatusId : number;
	chainStatusIdEntity : string;
	externalId : any;
	id : number;
	name : string;
	teamId : number;
	teamIdEntity : string;

	constructor() {
		this.chainStatusId = 0;
		this.chainStatusIdEntity = '';
		this.externalId = null;
		this.id = 0;
		this.name = '';
		this.teamId = 0;
		this.teamIdEntity = '';
	}
}
export class ApiChainStatusClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiChainStatusClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiClaspClientRequestModel {
	id : number;
	nextChainId : number;
	nextChainIdEntity : string;
	previousChainId : number;
	previousChainIdEntity : string;

	constructor() {
		this.id = 0;
		this.nextChainId = 0;
		this.nextChainIdEntity = '';
		this.previousChainId = 0;
		this.previousChainIdEntity = '';
	}
}

export class ApiClaspClientResponseModel {
	id : number;
	nextChainId : number;
	nextChainIdEntity : string;
	previousChainId : number;
	previousChainIdEntity : string;

	constructor() {
		this.id = 0;
		this.nextChainId = 0;
		this.nextChainIdEntity = '';
		this.previousChainId = 0;
		this.previousChainIdEntity = '';
	}
}
export class ApiLinkClientRequestModel {
	assignedMachineId : any;
	assignedMachineIdEntity : string;
	chainId : number;
	chainIdEntity : string;
	dateCompleted : any;
	dateStarted : any;
	dynamicParameter : string;
	externalId : any;
	id : number;
	linkStatusId : number;
	linkStatusIdEntity : string;
	name : string;
	order : number;
	response : string;
	staticParameter : string;
	timeoutInSecond : number;

	constructor() {
		this.assignedMachineId = null;
		this.assignedMachineIdEntity = '';
		this.chainId = 0;
		this.chainIdEntity = '';
		this.dateCompleted = null;
		this.dateStarted = null;
		this.dynamicParameter = '';
		this.externalId = null;
		this.id = 0;
		this.linkStatusId = 0;
		this.linkStatusIdEntity = '';
		this.name = '';
		this.order = 0;
		this.response = '';
		this.staticParameter = '';
		this.timeoutInSecond = 0;
	}
}

export class ApiLinkClientResponseModel {
	assignedMachineId : any;
	assignedMachineIdEntity : string;
	chainId : number;
	chainIdEntity : string;
	dateCompleted : any;
	dateStarted : any;
	dynamicParameter : string;
	externalId : any;
	id : number;
	linkStatusId : number;
	linkStatusIdEntity : string;
	name : string;
	order : number;
	response : string;
	staticParameter : string;
	timeoutInSecond : number;

	constructor() {
		this.assignedMachineId = null;
		this.assignedMachineIdEntity = '';
		this.chainId = 0;
		this.chainIdEntity = '';
		this.dateCompleted = null;
		this.dateStarted = null;
		this.dynamicParameter = '';
		this.externalId = null;
		this.id = 0;
		this.linkStatusId = 0;
		this.linkStatusIdEntity = '';
		this.name = '';
		this.order = 0;
		this.response = '';
		this.staticParameter = '';
		this.timeoutInSecond = 0;
	}
}
export class ApiLinkLogClientRequestModel {
	dateEntered : any;
	id : number;
	linkId : number;
	linkIdEntity : string;
	log : string;

	constructor() {
		this.dateEntered = null;
		this.id = 0;
		this.linkId = 0;
		this.linkIdEntity = '';
		this.log = '';
	}
}

export class ApiLinkLogClientResponseModel {
	dateEntered : any;
	id : number;
	linkId : number;
	linkIdEntity : string;
	log : string;

	constructor() {
		this.dateEntered = null;
		this.id = 0;
		this.linkId = 0;
		this.linkIdEntity = '';
		this.log = '';
	}
}
export class ApiLinkStatusClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiLinkStatusClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiMachineClientRequestModel {
	description : string;
	id : number;
	jwtKey : string;
	lastIpAddress : string;
	machineGuid : any;
	name : string;

	constructor() {
		this.description = '';
		this.id = 0;
		this.jwtKey = '';
		this.lastIpAddress = '';
		this.machineGuid = null;
		this.name = '';
	}
}

export class ApiMachineClientResponseModel {
	description : string;
	id : number;
	jwtKey : string;
	lastIpAddress : string;
	machineGuid : any;
	name : string;

	constructor() {
		this.description = '';
		this.id = 0;
		this.jwtKey = '';
		this.lastIpAddress = '';
		this.machineGuid = null;
		this.name = '';
	}
}
export class ApiOrganizationClientRequestModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}

export class ApiOrganizationClientResponseModel {
	id : number;
	name : string;

	constructor() {
		this.id = 0;
		this.name = '';
	}
}
export class ApiTeamClientRequestModel {
	id : number;
	name : string;
	organizationId : number;
	organizationIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.organizationId = 0;
		this.organizationIdEntity = '';
	}
}

export class ApiTeamClientResponseModel {
	id : number;
	name : string;
	organizationId : number;
	organizationIdEntity : string;

	constructor() {
		this.id = 0;
		this.name = '';
		this.organizationId = 0;
		this.organizationIdEntity = '';
	}
}

/*<Codenesium>
    <Hash>8e2f00a13047949bcdc6977f5c4f2bdf</Hash>
</Codenesium>*/