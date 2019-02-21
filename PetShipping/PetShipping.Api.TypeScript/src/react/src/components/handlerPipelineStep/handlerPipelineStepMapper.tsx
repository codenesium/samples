import * as Api from '../../api/models';
import HandlerPipelineStepViewModel from  './handlerPipelineStepViewModel';
	import HandlerViewModel from '../handler/handlerViewModel'
		import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel'
	export default class HandlerPipelineStepMapper {
    
	mapApiResponseToViewModel(dto: Api.HandlerPipelineStepClientResponseModel) : HandlerPipelineStepViewModel 
	{
		let response = new HandlerPipelineStepViewModel();
		response.setProperties(dto.handlerId,dto.id,dto.pipelineStepId);
		
						if(dto.handlerIdNavigation != null)
				{
				  response.handlerIdNavigation = new HandlerViewModel();
				  response.handlerIdNavigation.setProperties(
				  dto.handlerIdNavigation.countryId,dto.handlerIdNavigation.email,dto.handlerIdNavigation.firstName,dto.handlerIdNavigation.id,dto.handlerIdNavigation.lastName,dto.handlerIdNavigation.phone
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

	mapViewModelToApiRequest(model: HandlerPipelineStepViewModel) : Api.HandlerPipelineStepClientRequestModel
	{
		let response = new Api.HandlerPipelineStepClientRequestModel();
		response.setProperties(model.handlerId,model.id,model.pipelineStepId);
		return response;
	}
};

/*<Codenesium>
    <Hash>f4b3f5a772a34644a110a9cd20f16717</Hash>
</Codenesium>*/