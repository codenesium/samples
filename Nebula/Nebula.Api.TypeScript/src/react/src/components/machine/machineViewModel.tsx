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
    <Hash>ed2fd6551e9c5676f54f09d62eb1a526</Hash>
</Codenesium>*/