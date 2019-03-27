export class ChainClientRequestModel {
  chainStatusId: number;
  chainStatusIdEntity: string;
  chainStatusIdNavigation?: ChainStatusClientResponseModel;
  externalId: any;
  id: number;
  name: string;
  teamId: number;
  teamIdEntity: string;
  teamIdNavigation?: TeamClientResponseModel;

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

  setProperties(
    chainStatusId: number,
    externalId: any,
    id: number,
    name: string,
    teamId: number
  ): void {
    this.chainStatusId = chainStatusId;
    this.externalId = externalId;
    this.id = id;
    this.name = name;
    this.teamId = teamId;
  }
}

export class ChainClientResponseModel {
  chainStatusId: number;
  chainStatusIdEntity: string;
  chainStatusIdNavigation?: ChainStatusClientResponseModel;
  externalId: any;
  id: number;
  name: string;
  teamId: number;
  teamIdEntity: string;
  teamIdNavigation?: TeamClientResponseModel;

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

  setProperties(
    chainStatusId: number,
    externalId: any,
    id: number,
    name: string,
    teamId: number
  ): void {
    this.chainStatusId = chainStatusId;
    this.externalId = externalId;
    this.id = id;
    this.name = name;
    this.teamId = teamId;
  }
}
export class ChainStatusClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class ChainStatusClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class ClaspClientRequestModel {
  id: number;
  nextChainId: number;
  nextChainIdEntity: string;
  nextChainIdNavigation?: ChainClientResponseModel;
  previousChainId: number;
  previousChainIdEntity: string;
  previousChainIdNavigation?: ChainClientResponseModel;

  constructor() {
    this.id = 0;
    this.nextChainId = 0;
    this.nextChainIdEntity = '';
    this.nextChainIdNavigation = undefined;
    this.previousChainId = 0;
    this.previousChainIdEntity = '';
    this.previousChainIdNavigation = undefined;
  }

  setProperties(
    id: number,
    nextChainId: number,
    previousChainId: number
  ): void {
    this.id = id;
    this.nextChainId = nextChainId;
    this.previousChainId = previousChainId;
  }
}

export class ClaspClientResponseModel {
  id: number;
  nextChainId: number;
  nextChainIdEntity: string;
  nextChainIdNavigation?: ChainClientResponseModel;
  previousChainId: number;
  previousChainIdEntity: string;
  previousChainIdNavigation?: ChainClientResponseModel;

  constructor() {
    this.id = 0;
    this.nextChainId = 0;
    this.nextChainIdEntity = '';
    this.nextChainIdNavigation = undefined;
    this.previousChainId = 0;
    this.previousChainIdEntity = '';
    this.previousChainIdNavigation = undefined;
  }

  setProperties(
    id: number,
    nextChainId: number,
    previousChainId: number
  ): void {
    this.id = id;
    this.nextChainId = nextChainId;
    this.previousChainId = previousChainId;
  }
}
export class LinkClientRequestModel {
  assignedMachineId: number;
  assignedMachineIdEntity: string;
  assignedMachineIdNavigation?: MachineClientResponseModel;
  chainId: number;
  chainIdEntity: string;
  chainIdNavigation?: ChainClientResponseModel;
  dateCompleted: any;
  dateStarted: any;
  dynamicParameters: string;
  externalId: any;
  id: number;
  linkStatusId: number;
  linkStatusIdEntity: string;
  linkStatusIdNavigation?: LinkStatusClientResponseModel;
  name: string;
  order: number;
  response: string;
  staticParameters: string;
  timeoutInSeconds: number;

  constructor() {
    this.assignedMachineId = 0;
    this.assignedMachineIdEntity = '';
    this.assignedMachineIdNavigation = undefined;
    this.chainId = 0;
    this.chainIdEntity = '';
    this.chainIdNavigation = undefined;
    this.dateCompleted = undefined;
    this.dateStarted = undefined;
    this.dynamicParameters = '';
    this.externalId = undefined;
    this.id = 0;
    this.linkStatusId = 0;
    this.linkStatusIdEntity = '';
    this.linkStatusIdNavigation = undefined;
    this.name = '';
    this.order = 0;
    this.response = '';
    this.staticParameters = '';
    this.timeoutInSeconds = 0;
  }

  setProperties(
    assignedMachineId: number,
    chainId: number,
    dateCompleted: any,
    dateStarted: any,
    dynamicParameters: string,
    externalId: any,
    id: number,
    linkStatusId: number,
    name: string,
    order: number,
    response: string,
    staticParameters: string,
    timeoutInSeconds: number
  ): void {
    this.assignedMachineId = assignedMachineId;
    this.chainId = chainId;
    this.dateCompleted = dateCompleted;
    this.dateStarted = dateStarted;
    this.dynamicParameters = dynamicParameters;
    this.externalId = externalId;
    this.id = id;
    this.linkStatusId = linkStatusId;
    this.name = name;
    this.order = order;
    this.response = response;
    this.staticParameters = staticParameters;
    this.timeoutInSeconds = timeoutInSeconds;
  }
}

export class LinkClientResponseModel {
  assignedMachineId: number;
  assignedMachineIdEntity: string;
  assignedMachineIdNavigation?: MachineClientResponseModel;
  chainId: number;
  chainIdEntity: string;
  chainIdNavigation?: ChainClientResponseModel;
  dateCompleted: any;
  dateStarted: any;
  dynamicParameters: string;
  externalId: any;
  id: number;
  linkStatusId: number;
  linkStatusIdEntity: string;
  linkStatusIdNavigation?: LinkStatusClientResponseModel;
  name: string;
  order: number;
  response: string;
  staticParameters: string;
  timeoutInSeconds: number;

  constructor() {
    this.assignedMachineId = 0;
    this.assignedMachineIdEntity = '';
    this.assignedMachineIdNavigation = undefined;
    this.chainId = 0;
    this.chainIdEntity = '';
    this.chainIdNavigation = undefined;
    this.dateCompleted = undefined;
    this.dateStarted = undefined;
    this.dynamicParameters = '';
    this.externalId = undefined;
    this.id = 0;
    this.linkStatusId = 0;
    this.linkStatusIdEntity = '';
    this.linkStatusIdNavigation = undefined;
    this.name = '';
    this.order = 0;
    this.response = '';
    this.staticParameters = '';
    this.timeoutInSeconds = 0;
  }

  setProperties(
    assignedMachineId: number,
    chainId: number,
    dateCompleted: any,
    dateStarted: any,
    dynamicParameters: string,
    externalId: any,
    id: number,
    linkStatusId: number,
    name: string,
    order: number,
    response: string,
    staticParameters: string,
    timeoutInSeconds: number
  ): void {
    this.assignedMachineId = assignedMachineId;
    this.chainId = chainId;
    this.dateCompleted = dateCompleted;
    this.dateStarted = dateStarted;
    this.dynamicParameters = dynamicParameters;
    this.externalId = externalId;
    this.id = id;
    this.linkStatusId = linkStatusId;
    this.name = name;
    this.order = order;
    this.response = response;
    this.staticParameters = staticParameters;
    this.timeoutInSeconds = timeoutInSeconds;
  }
}
export class LinkLogClientRequestModel {
  dateEntered: any;
  id: number;
  linkId: number;
  linkIdEntity: string;
  linkIdNavigation?: LinkClientResponseModel;
  log: string;

  constructor() {
    this.dateEntered = undefined;
    this.id = 0;
    this.linkId = 0;
    this.linkIdEntity = '';
    this.linkIdNavigation = undefined;
    this.log = '';
  }

  setProperties(
    dateEntered: any,
    id: number,
    linkId: number,
    log: string
  ): void {
    this.dateEntered = dateEntered;
    this.id = id;
    this.linkId = linkId;
    this.log = log;
  }
}

export class LinkLogClientResponseModel {
  dateEntered: any;
  id: number;
  linkId: number;
  linkIdEntity: string;
  linkIdNavigation?: LinkClientResponseModel;
  log: string;

  constructor() {
    this.dateEntered = undefined;
    this.id = 0;
    this.linkId = 0;
    this.linkIdEntity = '';
    this.linkIdNavigation = undefined;
    this.log = '';
  }

  setProperties(
    dateEntered: any,
    id: number,
    linkId: number,
    log: string
  ): void {
    this.dateEntered = dateEntered;
    this.id = id;
    this.linkId = linkId;
    this.log = log;
  }
}
export class LinkStatusClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class LinkStatusClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class MachineClientRequestModel {
  description: string;
  id: number;
  jwtKey: string;
  lastIpAddress: string;
  machineGuid: any;
  name: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.jwtKey = '';
    this.lastIpAddress = '';
    this.machineGuid = undefined;
    this.name = '';
  }

  setProperties(
    description: string,
    id: number,
    jwtKey: string,
    lastIpAddress: string,
    machineGuid: any,
    name: string
  ): void {
    this.description = description;
    this.id = id;
    this.jwtKey = jwtKey;
    this.lastIpAddress = lastIpAddress;
    this.machineGuid = machineGuid;
    this.name = name;
  }
}

export class MachineClientResponseModel {
  description: string;
  id: number;
  jwtKey: string;
  lastIpAddress: string;
  machineGuid: any;
  name: string;

  constructor() {
    this.description = '';
    this.id = 0;
    this.jwtKey = '';
    this.lastIpAddress = '';
    this.machineGuid = undefined;
    this.name = '';
  }

  setProperties(
    description: string,
    id: number,
    jwtKey: string,
    lastIpAddress: string,
    machineGuid: any,
    name: string
  ): void {
    this.description = description;
    this.id = id;
    this.jwtKey = jwtKey;
    this.lastIpAddress = lastIpAddress;
    this.machineGuid = machineGuid;
    this.name = name;
  }
}
export class MachineRefTeamClientRequestModel {
  id: number;
  machineId: number;
  machineIdEntity: string;
  machineIdNavigation?: MachineClientResponseModel;
  teamId: number;
  teamIdEntity: string;
  teamIdNavigation?: TeamClientResponseModel;

  constructor() {
    this.id = 0;
    this.machineId = 0;
    this.machineIdEntity = '';
    this.machineIdNavigation = undefined;
    this.teamId = 0;
    this.teamIdEntity = '';
    this.teamIdNavigation = undefined;
  }

  setProperties(id: number, machineId: number, teamId: number): void {
    this.id = id;
    this.machineId = machineId;
    this.teamId = teamId;
  }
}

export class MachineRefTeamClientResponseModel {
  id: number;
  machineId: number;
  machineIdEntity: string;
  machineIdNavigation?: MachineClientResponseModel;
  teamId: number;
  teamIdEntity: string;
  teamIdNavigation?: TeamClientResponseModel;

  constructor() {
    this.id = 0;
    this.machineId = 0;
    this.machineIdEntity = '';
    this.machineIdNavigation = undefined;
    this.teamId = 0;
    this.teamIdEntity = '';
    this.teamIdNavigation = undefined;
  }

  setProperties(id: number, machineId: number, teamId: number): void {
    this.id = id;
    this.machineId = machineId;
    this.teamId = teamId;
  }
}
export class OrganizationClientRequestModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}

export class OrganizationClientResponseModel {
  id: number;
  name: string;

  constructor() {
    this.id = 0;
    this.name = '';
  }

  setProperties(id: number, name: string): void {
    this.id = id;
    this.name = name;
  }
}
export class TeamClientRequestModel {
  id: number;
  name: string;
  organizationId: number;
  organizationIdEntity: string;
  organizationIdNavigation?: OrganizationClientResponseModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.organizationId = 0;
    this.organizationIdEntity = '';
    this.organizationIdNavigation = undefined;
  }

  setProperties(id: number, name: string, organizationId: number): void {
    this.id = id;
    this.name = name;
    this.organizationId = organizationId;
  }
}

export class TeamClientResponseModel {
  id: number;
  name: string;
  organizationId: number;
  organizationIdEntity: string;
  organizationIdNavigation?: OrganizationClientResponseModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.organizationId = 0;
    this.organizationIdEntity = '';
    this.organizationIdNavigation = undefined;
  }

  setProperties(id: number, name: string, organizationId: number): void {
    this.id = id;
    this.name = name;
    this.organizationId = organizationId;
  }
}
export class VersionInfoClientRequestModel {
  appliedOn: any;
  description: string;
  version: number;

  constructor() {
    this.appliedOn = undefined;
    this.description = '';
    this.version = 0;
  }

  setProperties(appliedOn: any, description: string, version: number): void {
    this.appliedOn = appliedOn;
    this.description = description;
    this.version = version;
  }
}

export class VersionInfoClientResponseModel {
  appliedOn: any;
  description: string;
  version: number;

  constructor() {
    this.appliedOn = undefined;
    this.description = '';
    this.version = 0;
  }

  setProperties(appliedOn: any, description: string, version: number): void {
    this.appliedOn = appliedOn;
    this.description = description;
    this.version = version;
  }
}


/*<Codenesium>
    <Hash>6969deba43b6f73f8b4f3daec1460259</Hash>
</Codenesium>*/