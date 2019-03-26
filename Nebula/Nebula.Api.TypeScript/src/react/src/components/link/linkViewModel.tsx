import moment from 'moment';
import MachineViewModel from '../machine/machineViewModel';
import ChainViewModel from '../chain/chainViewModel';
import LinkStatusViewModel from '../linkStatus/linkStatusViewModel';

export default class LinkViewModel {
  assignedMachineId: number;
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
    this.assignedMachineId = 0;
    this.assignedMachineIdEntity = '';
    this.assignedMachineIdNavigation = undefined;
    this.chainId = 0;
    this.chainIdEntity = '';
    this.chainIdNavigation = undefined;
    this.dateCompleted = undefined;
    this.dateStarted = undefined;
    this.dynamicParameter = '';
    this.externalId = undefined;
    this.id = 0;
    this.linkStatusId = 0;
    this.linkStatusIdEntity = '';
    this.linkStatusIdNavigation = undefined;
    this.name = '';
    this.order = 0;
    this.response = '';
    this.staticParameter = '';
    this.timeoutInSecond = 0;
  }

  setProperties(
    assignedMachineId: number,
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
    this.dateCompleted = moment(dateCompleted, 'YYYY-MM-DD');
    this.dateStarted = moment(dateStarted, 'YYYY-MM-DD');
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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>1a7c39972902024a27f64d0e8df5869f</Hash>
</Codenesium>*/