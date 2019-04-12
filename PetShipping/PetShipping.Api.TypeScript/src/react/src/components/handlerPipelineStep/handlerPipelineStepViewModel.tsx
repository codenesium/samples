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
    this.handlerIdNavigation = undefined;
    this.id = 0;
    this.pipelineStepId = 0;
    this.pipelineStepIdEntity = '';
    this.pipelineStepIdNavigation = undefined;
  }

  setProperties(handlerId: number, id: number, pipelineStepId: number): void {
    this.handlerId = handlerId;
    this.id = id;
    this.pipelineStepId = pipelineStepId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>a501b616e32f5bbd4a2258b8fa21b98c</Hash>
</Codenesium>*/