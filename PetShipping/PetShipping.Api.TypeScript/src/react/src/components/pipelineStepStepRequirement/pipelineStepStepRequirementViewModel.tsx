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
    this.detail = moment(detail, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.pipelineStepId = moment(pipelineStepId, 'YYYY-MM-DD');
    this.requirementMet = moment(requirementMet, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>2c14ab164cb93f89d7a9a9d5ada44a24</Hash>
</Codenesium>*/