import moment from 'moment';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';

export default class PipelineStepStepRequirementViewModel {
  detail: string;
  id: number;
  pipelineStepId: number;
  pipelineStepIdEntity: string;
  pipelineStepIdNavigation?: PipelineStepViewModel;
  requirementMet: boolean;

  constructor() {
    this.detail = '';
    this.id = 0;
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = undefined;
    this.requirementMet = false;
  }

  setProperties(
    detail: string,
    id: number,
    pipelineStepId: number,
    requirementMet: boolean
  ): void {
    this.detail = detail;
    this.id = id;
    this.pipelineStepId = pipelineStepId;
    this.requirementMet = requirementMet;
  }

  toDisplay(): string {
    return String(this.detail);
  }
}


/*<Codenesium>
    <Hash>0d8e1da301dba5a059e4d91fc2709afb</Hash>
</Codenesium>*/