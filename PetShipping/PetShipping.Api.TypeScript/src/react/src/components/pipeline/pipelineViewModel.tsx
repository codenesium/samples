import moment from 'moment';
import PipelineStatusViewModel from '../pipelineStatus/pipelineStatusViewModel';

export default class PipelineViewModel {
  id: number;
  pipelineStatusId: number;
  pipelineStatusIdEntity: string;
  pipelineStatusIdNavigation?: PipelineStatusViewModel;
  saleId: number;

  constructor() {
    this.id = 0;
    this.pipelineStatusId = 0;
    this.pipelineStatusIdEntity = '';
    this.pipelineStatusIdNavigation = new PipelineStatusViewModel();
    this.saleId = 0;
  }

  setProperties(id: number, pipelineStatusId: number, saleId: number): void {
    this.id = id;
    this.pipelineStatusId = pipelineStatusId;
    this.saleId = saleId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>2f12b9001bfbc858025bb275c45e3f72</Hash>
</Codenesium>*/