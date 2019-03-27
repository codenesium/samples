import moment from 'moment';

export default class MachineViewModel {
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

  toDisplay(): string {
    return String(this.machineGuid);
  }
}


/*<Codenesium>
    <Hash>f330b1beb3a12e7e96847b7b75bb6609</Hash>
</Codenesium>*/