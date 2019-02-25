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
    this.pipelineStepIdNavigation = new PipelineStepViewModel();
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
    return String();
  }
}


/*<Codenesium>
    <Hash>26737756d44725e041ed63df0988e2da</Hash>
</Codenesium>*/