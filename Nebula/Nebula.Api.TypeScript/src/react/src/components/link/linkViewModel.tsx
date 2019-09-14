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
  dynamicParameters: string;
  externalId: any;
  id: number;
  linkStatusId: number;
  linkStatusIdEntity: string;
  linkStatusIdNavigation?: LinkStatusViewModel;
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
    this.dateCompleted = moment(dateCompleted, 'YYYY-MM-DD');
    this.dateStarted = moment(dateStarted, 'YYYY-MM-DD');
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

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>194609f6b5b5ee89a883171d7e3e13ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/