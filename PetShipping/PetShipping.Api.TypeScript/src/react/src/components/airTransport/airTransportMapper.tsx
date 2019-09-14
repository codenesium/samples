import * as Api from '../../api/models';
import AirTransportViewModel from './airTransportViewModel';
import HandlerViewModel from '../handler/handlerViewModel';
export default class AirTransportMapper {
  mapApiResponseToViewModel(
    dto: Api.AirTransportClientResponseModel
  ): AirTransportViewModel {
    let response = new AirTransportViewModel();
    response.setProperties(
      dto.airlineId,
      dto.flightNumber,
      dto.handlerId,
      dto.id,
      dto.landDate,
      dto.pipelineStepId,
      dto.takeoffDate
    );

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

    return response;
  }

  mapViewModelToApiRequest(
    model: AirTransportViewModel
  ): Api.AirTransportClientRequestModel {
    let response = new Api.AirTransportClientRequestModel();
    response.setProperties(
      model.airlineId,
      model.flightNumber,
      model.handlerId,
      model.id,
      model.landDate,
      model.pipelineStepId,
      model.takeoffDate
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>81cae6a0bb4b50f0e6dd71d125801992</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/