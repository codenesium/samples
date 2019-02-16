import * as Api from '../../api/models';
import PipelineStatuViewModel from './pipelineStatuViewModel';
export default class PipelineStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStatuClientResponseModel
  ): PipelineStatuViewModel {
    let response = new PipelineStatuViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStatuViewModel
  ): Api.PipelineStatuClientRequestModel {
    let response = new Api.PipelineStatuClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>5f5b33aa822db88ee793b6baa6056217</Hash>
</Codenesium>*/