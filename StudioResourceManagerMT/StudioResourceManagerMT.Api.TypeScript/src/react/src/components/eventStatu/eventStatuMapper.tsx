import * as Api from '../../api/models';
import EventStatuViewModel from './eventStatuViewModel';
export default class EventStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.EventStatuClientResponseModel
  ): EventStatuViewModel {
    let response = new EventStatuViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: EventStatuViewModel
  ): Api.EventStatuClientRequestModel {
    let response = new Api.EventStatuClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>d55467c671a7fb221d2c1fb910154f7c</Hash>
</Codenesium>*/