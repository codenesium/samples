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
    this.employeeId = moment(employeeId, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.note = moment(note, 'YYYY-MM-DD');
    this.pipelineStepId = moment(pipelineStepId, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>dea1f056f17c6c0f6306ccabbcdd48af</Hash>
</Codenesium>*/