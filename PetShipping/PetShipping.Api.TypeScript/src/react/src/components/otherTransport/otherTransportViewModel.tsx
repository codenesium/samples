import moment from 'moment';
import HandlerViewModel from '../handler/handlerViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';

export default class OtherTransportViewModel {
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
    <Hash>9a8cf5ddd1be0ae2bb9f1015c8fb87e0</Hash>
</Codenesium>*/