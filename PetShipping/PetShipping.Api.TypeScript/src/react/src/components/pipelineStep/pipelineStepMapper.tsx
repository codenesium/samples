import * as Api from '../../api/models';
import PipelineStepViewModel from  './pipelineStepViewModel';
	import PipelineStepStatuViewModel from '../pipelineStepStatu/pipelineStepStatuViewModel'
		import EmployeeViewModel from '../employee/employeeViewModel'
	export default class PipelineStepMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineStepClientResponseModel) : PipelineStepViewModel 
	{
		let response = new PipelineStepViewModel();
		response.setProperties(dto.id,dto.name,dto.pipelineStepStatusId,dto.shipperId);
		
						if(dto.pipelineStepStatusIdNavigation != null)
				{
				  response.pipelineStepStatusIdNavigation = new PipelineStepStatuViewModel();
				  response.pipelineStepStatusIdNavigation.setProperties(
				  dto.pipelineStepStatusIdNavigation.id,dto.pipelineStepStatusIdNavigation.name
				  );
				}
							if(dto.shipperIdNavigation != null)
				{
				  response.shipperIdNavigation = new EmployeeViewModel();
				  response.shipperIdNavigation.setProperties(
				  dto.shipperIdNavigation.firstName,dto.shipperIdNavigation.id,dto.shipperIdNavigation.isSalesPerson,dto.shipperIdNavigation.isShipper,dto.shipperIdNavigation.lastName
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineStepViewModel) : Api.PipelineStepClientRequestModel
	{
		let response = new Api.PipelineStepClientRequestModel();
		response.setProperties(model.id,model.name,model.pipelineStepStatusId,model.shipperId);
		return response;
	}
};

/*<Codenesium>
    <Hash>084f93eb3c50050a1845983a7cb9dccc</Hash>
</Codenesium>*/