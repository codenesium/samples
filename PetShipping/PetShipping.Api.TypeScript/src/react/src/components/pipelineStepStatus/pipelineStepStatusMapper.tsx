import * as Api from '../../api/models';
import PipelineStepStatusViewModel from './pipelineStepStatusViewModel';
export default class PipelineStepStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStepStatusClientResponseModel
  ): PipelineStepStatusViewModel {
    let response = new PipelineStepStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStepStatusViewModel
  ): Api.PipelineStepStatusClientRequestModel {
    let response = new Api.PipelineStepStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>62ef5d272e360db13713ab31951eb801</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/