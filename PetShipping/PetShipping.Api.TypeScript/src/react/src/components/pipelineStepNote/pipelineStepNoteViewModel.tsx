import moment from 'moment'
import EmployeeViewModel from '../employee/employeeViewModel'
	import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel'
	

export default class PipelineStepNoteViewModel {
    employeeId:number;
employeeIdEntity : string;
employeeIdNavigation? : EmployeeViewModel;
id:number;
note:string;
pipelineStepId:number;
pipelineStepIdEntity : string;
pipelineStepIdNavigation? : PipelineStepViewModel;

    constructor() {
		this.employeeId = 0;
this.employeeIdEntity = '';
this.employeeIdNavigation = new EmployeeViewModel();
this.id = 0;
this.note = '';
this.pipelineStepId = 0;
this.pipelineStepIdEntity = '';
this.pipelineStepIdNavigation = new PipelineStepViewModel();

    }

	setProperties(employeeId : number,id : number,note : string,pipelineStepId : number) : void
	{
		this.employeeId = moment(employeeId,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.note = moment(note,'YYYY-MM-DD');
this.pipelineStepId = moment(pipelineStepId,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>e94e8e193ba0d1efa91630bbabb242c6</Hash>
</Codenesium>*/