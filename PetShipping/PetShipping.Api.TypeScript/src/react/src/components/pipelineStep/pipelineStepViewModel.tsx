import moment from 'moment';
import PipelineStepStatusViewModel from '../pipelineStepStatus/pipelineStepStatusViewModel';
import EmployeeViewModel from '../employee/employeeViewModel';

export default class PipelineStepViewModel {
  id: number;
  name: string;
  pipelineStepStatusId: number;
  pipelineStepStatusIdEntity: string;
  pipelineStepStatusIdNavigation?: PipelineStepStatusViewModel;
  shipperId: number;
  shipperIdEntity: string;
  shipperIdNavigation?: EmployeeViewModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.pipelineStepStatusId = 0;
    this.pipelineStepStatusIdEntity = '';
    this.pipelineStepStatusIdNavigation = new PipelineStepStatusViewModel();
    this.shipperId = 0;
    this.shipperIdEntity = '';
    this.shipperIdNavigation = new EmployeeViewModel();
  }

  setProperties(
    id: number,
    name: string,
    pipelineStepStatusId: number,
    shipperId: number
  ): void {
    this.id = id;
    this.name = name;
    this.pipelineStepStatusId = pipelineStepStatusId;
    this.shipperId = shipperId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>2b02ae258e2cee81f566ac54c9ad4bca</Hash>
</Codenesium>*/