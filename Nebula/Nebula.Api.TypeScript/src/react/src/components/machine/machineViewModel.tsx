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
    return String();
  }
}


/*<Codenesium>
    <Hash>2c4e50cfb11e77e595b0215ff117ec96</Hash>
</Codenesium>*/