import * as Api from '../api/models';
import EventStatuViewModel from '../viewmodels/eventStatuViewModel';

export default class EventStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.EventStatuClientResponseModel
  ): EventStatuViewModel {
    let response = new EventStatuViewModel();
    response.setProperties(dto.id, dto.isDeleted, dto.name, dto.tenantId);
    return response;
  }

  mapViewModelToApiRequest(
    model: EventStatuViewModel
  ): Api.EventStatuClientRequestModel {
    let response = new Api.EventStatuClientRequestModel();
    response.setProperties(
      model.id,
      model.isDeleted,
      model.name,
      model.tenantId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>812c416e27e9e53d87be362687f9514a</Hash>
</Codenesium>*/