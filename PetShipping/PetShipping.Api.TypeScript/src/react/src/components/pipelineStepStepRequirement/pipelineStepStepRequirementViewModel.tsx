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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>7c2fa399379b257e211c2833f996b70f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/