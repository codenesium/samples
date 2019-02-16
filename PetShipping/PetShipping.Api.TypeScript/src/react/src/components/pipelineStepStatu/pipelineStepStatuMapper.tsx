import * as Api from '../../api/models';
import PipelineStepStatuViewModel from './pipelineStepStatuViewModel';
export default class PipelineStepStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStepStatuClientResponseModel
  ): PipelineStepStatuViewModel {
    let response = new PipelineStepStatuViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStepStatuViewModel
  ): Api.PipelineStepStatuClientRequestModel {
    let response = new Api.PipelineStepStatuClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>fabaed6d3268f7662f9a772979611b44</Hash>
</Codenesium>*/