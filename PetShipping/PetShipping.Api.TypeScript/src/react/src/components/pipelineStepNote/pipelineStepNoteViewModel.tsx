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
    this.employeeIdNavigation = undefined;
    this.id = 0;
    this.note = '';
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = undefined;
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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>5a65ee744aa2542ddff36f84f8b27b2f</Hash>
</Codenesium>*/