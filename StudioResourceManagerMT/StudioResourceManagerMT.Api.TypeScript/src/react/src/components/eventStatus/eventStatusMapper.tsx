import * as Api from '../../api/models';
import EventStatusViewModel from './eventStatusViewModel';
export default class EventStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.EventStatusClientResponseModel
  ): EventStatusViewModel {
    let response = new EventStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: EventStatusViewModel
  ): Api.EventStatusClientRequestModel {
    let response = new Api.EventStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>ed33e44b56d499adc18d13731e215b9d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/