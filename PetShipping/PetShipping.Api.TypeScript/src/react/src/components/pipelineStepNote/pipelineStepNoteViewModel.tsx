import moment from 'moment';
import EmployeeViewModel from '../employee/employeeViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';

export default class PipelineStepNoteViewModel {
  employeeId: number;
  employeeIdEntity: string;
  employeeIdNavigation?: EmployeeViewModel;
  id: number;
  note: string;
  pipelineStepId: number;
  pipelineStepIdEntity: string;
  pipelineStepIdNavigation?: PipelineStepViewModel;

  constructor() {
    this.employeeId = 0;
    this.employeeIdEntity = '';
    this.employeeIdNavigation = new EmployeeViewModel();
    this.id = 0;
    this.note = '';
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = new PipelineStepViewModel();
  }

  setProperties(
    employeeId: number,
    id: number,
    note: string,
    pipelineStepId: number
  ): void {
    this.employeeId = employeeId;
    this.id = id;
    this.note = note;
    this.pipelineStepId = pipelineStepId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>ee77746bbe526beb458b8e7b6bf3e719</Hash>
</Codenesium>*/