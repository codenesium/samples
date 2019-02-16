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
    return String();
  }
}


/*<Codenesium>
    <Hash>64aab7b917359412e18729590730b47c</Hash>
</Codenesium>*/