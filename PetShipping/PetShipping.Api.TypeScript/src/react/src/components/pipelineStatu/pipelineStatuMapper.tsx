import * as Api from '../../api/models';
import PipelineStatuViewModel from  './pipelineStatuViewModel';
export default class PipelineStatuMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineStatuClientResponseModel) : PipelineStatuViewModel 
	{
		let response = new PipelineStatuViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineStatuViewModel) : Api.PipelineStatuClientRequestModel
	{
		let response = new Api.PipelineStatuClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>f356b872b1f5194a2e95275028aa6b7d</Hash>
</Codenesium>*/