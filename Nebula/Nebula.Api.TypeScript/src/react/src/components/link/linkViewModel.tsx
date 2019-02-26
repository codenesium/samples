import moment from 'moment';
import MachineViewModel from '../machine/machineViewModel';
import ChainViewModel from '../chain/chainViewModel';
import LinkStatusViewModel from '../linkStatus/linkStatusViewModel';

export default class LinkViewModel {
  assignedMachineId: any;
  assignedMachineIdEntity: string;
  assignedMachineIdNavigation?: MachineViewModel;
  chainId: number;
  chainIdEntity: string;
  chainIdNavigation?: ChainViewModel;
  dateCompleted: any;
  dateStarted: any;
  dynamicParameter: string;
  externalId: any;
  id: number;
  linkStatusId: number;
  linkStatusIdEntity: string;
  linkStatusIdNavigation?: LinkStatusViewModel;
  name: string;
  order: number;
  response: string;
  staticParameter: string;
  timeoutInSecond: number;

  constructor() {
    this.assignedMachineId = undefined;
    this.assignedMachineIdEntity = '';
    this.assignedMachineIdNavigation = new MachineViewModel();
    this.chainId = 0;
    this.chainIdEntity = '';
    this.chainIdNavigation = new ChainViewModel();
    this.dateCompleted = undefined;
    this.dateStarted = undefined;
    this.dynamicParameter = '';
    this.externalId = undefined;
    this.id = 0;
    this.linkStatusId = 0;
    this.linkStatusIdEntity = '';
    this.linkStatusIdNavigation = new LinkStatusViewModel();
    this.name = '';
    this.order = 0;
    this.response = '';
    this.staticParameter = '';
    this.timeoutInSecond = 0;
  }

  setProperties(
    assignedMachineId: any,
    chainId: number,
    dateCompleted: any,
    dateStarted: any,
    dynamicParameter: string,
    externalId: any,
    id: number,
    linkStatusId: number,
    name: string,
    order: number,
    response: string,
    staticParameter: string,
    timeoutInSecond: number
  ): void {
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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>3a6ade9980743c81a1f9d2a933a33e5e</Hash>
</Codenesium>*/