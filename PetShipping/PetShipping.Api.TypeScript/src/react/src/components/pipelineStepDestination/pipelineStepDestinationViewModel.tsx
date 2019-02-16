import DestinationViewModel from '../destination/destinationViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';

export default class PipelineStepDestinationViewModel {
  destinationId: number;
  destinationIdEntity: string;
  destinationIdNavigation?: DestinationViewModel;
  id: number;
  pipelineStepId: number;
  pipelineStepIdEntity: string;
  pipelineStepIdNavigation?: PipelineStepViewModel;

  constructor() {
    this.destinationId = 0;
    this.destinationIdEntity = '';
    this.destinationIdNavigation = undefined;
    this.id = 0;
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = undefined;
  }

  setProperties(
    destinationId: number,
    id: number,
    pipelineStepId: number
  ): void {
    this.destinationId = destinationId;
    this.id = id;
    this.pipelineStepId = pipelineStepId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>0f4a70f2866ecf7e516bc116353d5b9c</Hash>
</Codenesium>*/