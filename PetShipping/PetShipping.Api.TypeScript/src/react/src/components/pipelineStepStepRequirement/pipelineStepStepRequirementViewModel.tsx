import moment from 'moment';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';

export default class PipelineStepStepRequirementViewModel {
  details: string;
  id: number;
  pipelineStepId: number;
  pipelineStepIdEntity: string;
  pipelineStepIdNavigation?: PipelineStepViewModel;
  requirementMet: boolean;

  constructor() {
    this.details = '';
    this.id = 0;
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = undefined;
    this.requirementMet = false;
  }

  setProperties(
    details: string,
    id: number,
    pipelineStepId: number,
    requirementMet: boolean
  ): void {
    this.details = details;
    this.id = id;
    this.pipelineStepId = pipelineStepId;
    this.requirementMet = requirementMet;
  }

  toDisplay(): string {
    return String(this.details);
  }
}


/*<Codenesium>
    <Hash>bf5312363033ac0f47633aefd5479636</Hash>
</Codenesium>*/