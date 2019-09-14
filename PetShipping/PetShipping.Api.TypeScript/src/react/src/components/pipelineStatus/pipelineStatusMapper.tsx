import * as Api from '../../api/models';
import PipelineStatusViewModel from './pipelineStatusViewModel';
export default class PipelineStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStatusClientResponseModel
  ): PipelineStatusViewModel {
    let response = new PipelineStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStatusViewModel
  ): Api.PipelineStatusClientRequestModel {
    let response = new Api.PipelineStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>4f7690ab4f6cbd86d9bc3f83a93d31c6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/