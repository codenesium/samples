import moment from 'moment'
import PipelineStatusViewModel from '../pipelineStatus/pipelineStatusViewModel'
	

export default class PipelineViewModel {
    id:number;
pipelineStatusId:number;
pipelineStatusIdEntity : string;
pipelineStatusIdNavigation? : PipelineStatusViewModel;
saleId:number;

    constructor() {
		this.id = 0;
this.pipelineStatusId = 0;
this.pipelineStatusIdEntity = '';
this.pipelineStatusIdNavigation = new PipelineStatusViewModel();
this.saleId = 0;

    }

	setProperties(id : number,pipelineStatusId : number,saleId : number) : void
	{
		this.id = id;
this.pipelineStatusId = pipelineStatusId;
this.saleId = saleId;

	}

	toDisplay() : string
	{
		return String(this.id);
	}
};

/*<Codenesium>
    <Hash>ed5995188d87ce003f2ab5cac6a64885</Hash>
</Codenesium>*/