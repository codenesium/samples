export class ApiChainClientRequestModel {
	chainStatusId : number;
	chainStatusIdEntity : string;
	externalId : string;
	id : number;
	name : string;
	teamId : number;
	teamIdEntity : string;

	constructor() {
		this.chainStatusId = 0;
		this.chainStatusIdEntity = '';
		this.externalId = '';
		this.id = 0;
		this.name = '';
		this.teamId = 0;
		this.teamIdEntity = '';
	}
}

export class ApiChainClientResponseModel {
	chainStatusId : number;
	chainStatusIdEntity : string;
	externalId : string;
	id : number;
	name : string;
	teamId : number;
	teamIdEntity : string;

	constructor() {
		this.chainStatusId = 0;
		this.chainStatusIdEntity = '';
		this.externalId = '';
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
	assignedMachineId : number;
	assignedMachineIdEntity : string;
	chainId : number;
	chainIdEntity : string;
	dateCompleted : string;
	dateStarted : string;
	dynamicParameter : string;
	externalId : string;
	id : number;
	linkStatusId : number;
	linkStatusIdEntity : string;
	name : string;
	order : number;
	response : string;
	staticParameter : string;
	timeoutInSecond : number;

	constructor() {
		this.assignedMachineId = 0;
		this.assignedMachineIdEntity = '';
		this.chainId = 0;
		this.chainIdEntity = '';
		this.dateCompleted = '';
		this.dateStarted = '';
		this.dynamicParameter = '';
		this.externalId = '';
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
	assignedMachineId : number;
	assignedMachineIdEntity : string;
	chainId : number;
	chainIdEntity : string;
	dateCompleted : string;
	dateStarted : string;
	dynamicParameter : string;
	externalId : string;
	id : number;
	linkStatusId : number;
	linkStatusIdEntity : string;
	name : string;
	order : number;
	response : string;
	staticParameter : string;
	timeoutInSecond : number;

	constructor() {
		this.assignedMachineId = 0;
		this.assignedMachineIdEntity = '';
		this.chainId = 0;
		this.chainIdEntity = '';
		this.dateCompleted = '';
		this.dateStarted = '';
		this.dynamicParameter = '';
		this.externalId = '';
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
	dateEntered : string;
	id : number;
	linkId : number;
	linkIdEntity : string;
	log : string;

	constructor() {
		this.dateEntered = '';
		this.id = 0;
		this.linkId = 0;
		this.linkIdEntity = '';
		this.log = '';
	}
}

export class ApiLinkLogClientResponseModel {
	dateEntered : string;
	id : number;
	linkId : number;
	linkIdEntity : string;
	log : string;

	constructor() {
		this.dateEntered = '';
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
	machineGuid : string;
	name : string;

	constructor() {
		this.description = '';
		this.id = 0;
		this.jwtKey = '';
		this.lastIpAddress = '';
		this.machineGuid = '';
		this.name = '';
	}
}

export class ApiMachineClientResponseModel {
	description : string;
	id : number;
	jwtKey : string;
	lastIpAddress : string;
	machineGuid : string;
	name : string;

	constructor() {
		this.description = '';
		this.id = 0;
		this.jwtKey = '';
		this.lastIpAddress = '';
		this.machineGuid = '';
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
    <Hash>be5966c85795ab52628569daf4a61ba4</Hash>
</Codenesium>*/