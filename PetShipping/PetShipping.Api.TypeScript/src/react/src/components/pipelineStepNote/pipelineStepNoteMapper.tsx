import * as Api from '../../api/models';
import PipelineStepNoteViewModel from  './pipelineStepNoteViewModel';
	import EmployeeViewModel from '../employee/employeeViewModel'
		import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel'
	export default class PipelineStepNoteMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineStepNoteClientResponseModel) : PipelineStepNoteViewModel 
	{
		let response = new PipelineStepNoteViewModel();
		response.setProperties(dto.employeeId,dto.id,dto.note,dto.pipelineStepId);
		
						if(dto.employeeIdNavigation != null)
				{
				  response.employeeIdNavigation = new EmployeeViewModel();
				  response.employeeIdNavigation.setProperties(
				  dto.employeeIdNavigation.firstName,dto.employeeIdNavigation.id,dto.employeeIdNavigation.isSalesPerson,dto.employeeIdNavigation.isShipper,dto.employeeIdNavigation.lastName
				  );
				}
							if(dto.pipelineStepIdNavigation != null)
				{
				  response.pipelineStepIdNavigation = new PipelineStepViewModel();
				  response.pipelineStepIdNavigation.setProperties(
				  dto.pipelineStepIdNavigation.id,dto.pipelineStepIdNavigation.name,dto.pipelineStepIdNavigation.pipelineStepStatusId,dto.pipelineStepIdNavigation.shipperId
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineStepNoteViewModel) : Api.PipelineStepNoteClientRequestModel
	{
		let response = new Api.PipelineStepNoteClientRequestModel();
		response.setProperties(model.employeeId,model.id,model.note,model.pipelineStepId);
		return response;
	}
};

/*<Codenesium>
    <Hash>1daf5666f1caa764c70ea576c4063eb6</Hash>
</Codenesium>*/