import moment from 'moment';
import HandlerViewModel from '../handler/handlerViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';

export default class HandlerPipelineStepViewModel {
  handlerId: number;
  handlerIdEntity: string;
  handlerIdNavigation?: HandlerViewModel;
  id: number;
  pipelineStepId: number;
  pipelineStepIdEntity: string;
  pipelineStepIdNavigation?: PipelineStepViewModel;

  constructor() {
    this.handlerId = 0;
    this.handlerIdEntity = '';
    this.handlerIdNavigation = new HandlerViewModel();
    this.id = 0;
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = new PipelineStepViewModel();
  }

  setProperties(handlerId: number, id: number, pipelineStepId: number): void {
    this.handlerId = handlerId;
    this.id = id;
    this.pipelineStepId = pipelineStepId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>954d3b473398b7b3d30081133a186ca1</Hash>
</Codenesium>*/