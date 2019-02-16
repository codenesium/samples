import PipelineStepStatuViewModel from '../pipelineStepStatu/pipelineStepStatuViewModel';
import EmployeeViewModel from '../employee/employeeViewModel';

export default class PipelineStepViewModel {
  id: number;
  name: string;
  pipelineStepStatusId: number;
  pipelineStepStatusIdEntity: string;
  pipelineStepStatusIdNavigation?: PipelineStepStatuViewModel;
  shipperId: number;
  shipperIdEntity: string;
  shipperIdNavigation?: EmployeeViewModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.pipelineStepStatusId = 0;
    this.pipelineStepStatusIdEntity = '';
    this.pipelineStepStatusIdNavigation = undefined;
    this.shipperId = 0;
    this.shipperIdEntity = '';
    this.shipperIdNavigation = undefined;
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
    <Hash>7e9f1727b50d8c12f3e21384b922b8d0</Hash>
</Codenesium>*/