import * as Api from '../../api/models';
import PipelineStepStatuViewModel from  './pipelineStepStatuViewModel';
export default class PipelineStepStatuMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineStepStatuClientResponseModel) : PipelineStepStatuViewModel 
	{
		let response = new PipelineStepStatuViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineStepStatuViewModel) : Api.PipelineStepStatuClientRequestModel
	{
		let response = new Api.PipelineStepStatuClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>e5150da9227c491e2cebc9316ec82660</Hash>
</Codenesium>*/