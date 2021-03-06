import * as Api from '../../api/models';
import OtherTransportViewModel from './otherTransportViewModel';
import HandlerViewModel from '../handler/handlerViewModel';
import PipelineStepViewModel from '../pipelineStep/pipelineStepViewModel';
export default class OtherTransportMapper {
  mapApiResponseToViewModel(
    dto: Api.OtherTransportClientResponseModel
  ): OtherTransportViewModel {
    let response = new OtherTransportViewModel();
    response.setProperties(dto.handlerId, dto.id, dto.pipelineStepId);

    if (dto.handlerIdNavigation != null) {
      response.handlerIdNavigation = new HandlerViewModel();
      response.handlerIdNavigation.setProperties(
        dto.handlerIdNavigation.countryId,
        dto.handlerIdNavigation.email,
        dto.handlerIdNavigation.firstName,
        dto.handlerIdNavigation.id,
        dto.handlerIdNavigation.lastName,
        dto.handlerIdNavigation.phone
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
    model: OtherTransportViewModel
  ): Api.OtherTransportClientRequestModel {
    let response = new Api.OtherTransportClientRequestModel();
    response.setProperties(model.handlerId, model.id, model.pipelineStepId);
    return response;
  }
}


/*<Codenesium>
    <Hash>36b669cfc97c5e92f2929d496fad6d3e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/