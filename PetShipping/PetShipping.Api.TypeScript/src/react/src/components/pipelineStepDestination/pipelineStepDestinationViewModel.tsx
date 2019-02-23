import moment from 'moment'
import DestinationViewModel from '../destination/destinationViewModel'
	import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel'
	

export default class PipelineStepDestinationViewModel {
    destinationId:number;
destinationIdEntity : string;
destinationIdNavigation? : DestinationViewModel;
id:number;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepViewModel;

    constructor() {
		this.destinationId = 0;
this.destinationIdEntity = '';
this.destinationIdNavigation = new DestinationViewModel();
this.id = 0;
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = new PipelineStepViewModel();

    }

	setProperties(destinationId : number,id : number,pipelineStepId : number) : void
	{
		this.destinationId = moment(destinationId,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.pipelineStepId = moment(pipelineStepId,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>1452a8d52e7cde76003513e1f073c67b</Hash>
</Codenesium>*/