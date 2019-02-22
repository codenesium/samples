import moment from 'moment';
import PipelineStatuViewModel from '../pipelineStatu/pipelineStatuViewModel';

export default class PipelineViewModel {
  id: number;
  pipelineStatusId: number;
  pipelineStatusIdEntity: string;
  pipelineStatusIdNavigation?: PipelineStatuViewModel;
  saleId: number;

  constructor() {
    this.id = 0;
    this.pipelineStatusId = 0;
    this.pipelineStatusIdEntity = '';
    this.pipelineStatusIdNavigation = new PipelineStatuViewModel();
    this.saleId = 0;
  }

  setProperties(id: number, pipelineStatusId: number, saleId: number): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.pipelineStatusId = moment(pipelineStatusId, 'YYYY-MM-DD');
    this.saleId = moment(saleId, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>e76be7d7009fcf16f65e98a10436a746</Hash>
</Codenesium>*/