import * as Api from '../../api/models';
import PipelineViewModel from  './pipelineViewModel';
	import PipelineStatusViewModel from '../pipelineStatus/pipelineStatusViewModel'
	export default class PipelineMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineClientResponseModel) : PipelineViewModel 
	{
		let response = new PipelineViewModel();
		response.setProperties(dto.id,dto.pipelineStatusId,dto.saleId);
		
						if(dto.pipelineStatusIdNavigation != null)
				{
				  response.pipelineStatusIdNavigation = new PipelineStatusViewModel();
				  response.pipelineStatusIdNavigation.setProperties(
				  dto.pipelineStatusIdNavigation.id,dto.pipelineStatusIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineViewModel) : Api.PipelineClientRequestModel
	{
		let response = new Api.PipelineClientRequestModel();
		response.setProperties(model.id,model.pipelineStatusId,model.saleId);
		return response;
	}
};

/*<Codenesium>
    <Hash>b467180c037cba0f4ed59a899c90e180</Hash>
</Codenesium>*/