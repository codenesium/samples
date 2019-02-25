import * as Api from '../../api/models';
import PipelineStepDestinationViewModel from './pipelineStepDestinationViewModel';
import DestinationViewModel from '../destination/destinationViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';
export default class PipelineStepDestinationMapper {
  mapApiResponseToViewModel(
    dto: Api.PipelineStepDestinationClientResponseModel
  ): PipelineStepDestinationViewModel {
    let response = new PipelineStepDestinationViewModel();
    response.setProperties(dto.destinationId, dto.id, dto.pipelineStepId);

    if (dto.destinationIdNavigation != null) {
      response.destinationIdNavigation = new DestinationViewModel();
      response.destinationIdNavigation.setProperties(
        dto.destinationIdNavigation.countryId,
        dto.destinationIdNavigation.id,
        dto.destinationIdNavigation.name,
        dto.destinationIdNavigation.order
      );
    }
    if (dto.pipelineStepIdNavigation != null) {
      response.pipelineStepIdNavigation = new PipelineStepViewModel();
      response.pipelineStepIdNavigation.setProperties(
        dto.pipelineStepIdNavigation.id,
        dto.pipelineStepIdNavigation.name,
        dto.pipelineStepIdNavigation.pipelineStepStatusId,
        dto.pipelineStepIdNavigation.shipperId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PipelineStepDestinationViewModel
  ): Api.PipelineStepDestinationClientRequestModel {
    let response = new Api.PipelineStepDestinationClientRequestModel();
    response.setProperties(model.destinationId, model.id, model.pipelineStepId);
    return response;
  }
}


/*<Codenesium>
    <Hash>5b15eb9743cac12a24297b90874c519a</Hash>
</Codenesium>*/