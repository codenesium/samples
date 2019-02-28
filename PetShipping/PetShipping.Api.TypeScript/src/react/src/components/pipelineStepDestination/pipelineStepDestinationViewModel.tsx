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
		this.destinationId = destinationId;
this.id = id;
this.pipelineStepId = pipelineStepId;

	}

	toDisplay() : string
	{
		return String(this.destinationId);
	}
};

/*<Codenesium>
    <Hash>6fb17245c7e031161fa027153256e6d0</Hash>
</Codenesium>*/