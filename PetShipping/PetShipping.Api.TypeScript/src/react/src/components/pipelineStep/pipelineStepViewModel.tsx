import moment from 'moment'
import PipelineStepStatuViewModel from '../pipelineStepStatu/pipelineStepStatuViewModel'
	import EmployeeViewModel from '../employee/employeeViewModel'
	

export default class PipelineStepViewModel {
    id:number;
name:string;
pipelineStepStatusId:number;
pipelineStepStatusIdEntity : string;
pipelineStepStatusIdNavigation? : PipelineStepStatuViewModel;
shipperId:number;
shipperIdEntity : string;
shipperIdNavigation? : EmployeeViewModel;

    constructor() {
		this.id = 0;
this.name = '';
this.pipelineStepStatusId = 0;
this.pipelineStepStatusIdEntity = '';
this.pipelineStepStatusIdNavigation = new PipelineStepStatuViewModel();
this.shipperId = 0;
this.shipperIdEntity = '';
this.shipperIdNavigation = new EmployeeViewModel();

    }

	setProperties(id : number,name : string,pipelineStepStatusId : number,shipperId : number) : void
	{
		this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.pipelineStepStatusId = moment(pipelineStepStatusId,'YYYY-MM-DD');
this.shipperId = moment(shipperId,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>af12e8a20b7db66f4fc7f35c5332288e</Hash>
</Codenesium>*/