import * as Api from '../../api/models';
import PipelineStatusViewModel from  './pipelineStatusViewModel';
export default class PipelineStatusMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineStatusClientResponseModel) : PipelineStatusViewModel 
	{
		let response = new PipelineStatusViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineStatusViewModel) : Api.PipelineStatusClientRequestModel
	{
		let response = new Api.PipelineStatusClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>938acb8fc99e9960cd3c24064ab4cc12</Hash>
</Codenesium>*/