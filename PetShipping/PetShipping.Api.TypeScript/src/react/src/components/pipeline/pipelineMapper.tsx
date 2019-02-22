import * as Api from '../../api/models';
import PipelineViewModel from './pipelineViewModel';
import PipelineStatuViewModel from '../pipelineStatu/pipelineStatuViewModel';
export default class PipelineMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineClientResponseModel
  ): PipelineViewModel {
    let response = new PipelineViewModel();
    response.setProperties(dto.id, dto.pipelineStatusId, dto.saleId);

    if (dto.pipelineStatusIdNavigation != null) {
      response.pipelineStatusIdNavigation = new PipelineStatuViewModel();
      response.pipelineStatusIdNavigation.setProperties(
        dto.pipelineStatusIdNavigation.id,
        dto.pipelineStatusIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineViewModel
  ): Api.PipelineClientRequestModel {
    let response = new Api.PipelineClientRequestModel();
    response.setProperties(model.id, model.pipelineStatusId, model.saleId);
    return response;
  }
}


/*<Codenesium>
    <Hash>826e643844ac1d007ce0260b761ad5dd</Hash>
</Codenesium>*/