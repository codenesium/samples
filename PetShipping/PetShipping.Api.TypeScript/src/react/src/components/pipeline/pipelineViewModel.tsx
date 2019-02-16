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
    this.pipelineStatusIdNavigation = undefined;
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
    <Hash>320bbb98b167ff4ce8890893e61d11b8</Hash>
</Codenesium>*/