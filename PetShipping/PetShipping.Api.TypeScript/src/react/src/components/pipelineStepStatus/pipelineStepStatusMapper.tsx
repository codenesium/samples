import * as Api from '../../api/models';
import PipelineStepStatusViewModel from  './pipelineStepStatusViewModel';
export default class PipelineStepStatusMapper {
    
	mapApiResponseToViewModel(dto: Api.PipelineStepStatusClientResponseModel) : PipelineStepStatusViewModel 
	{
		let response = new PipelineStepStatusViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PipelineStepStatusViewModel) : Api.PipelineStepStatusClientRequestModel
	{
		let response = new Api.PipelineStepStatusClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>80163adb51b70ac74ccb9fc7fb4c8ca8</Hash>
</Codenesium>*/