import moment from 'moment';
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
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>e4afc68d00752072cbce9cca0e191ae1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/