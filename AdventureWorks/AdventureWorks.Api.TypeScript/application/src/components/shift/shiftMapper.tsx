import * as Api from '../../api/models';
import ShiftViewModel from './shiftViewModel';

export default class ShiftMapper {
  mapApiResponseToViewModel(dto: Api.ShiftClientResponseModel): ShiftViewModel {
    let response = new ShiftViewModel();
    response.setProperties(
      dto.endTime,
      dto.modifiedDate,
      dto.name,
      dto.shiftID,
      dto.startTime
    );
    return response;
  }

  mapViewModelToApiRequest(model: ShiftViewModel): Api.ShiftClientRequestModel {
    let response = new Api.ShiftClientRequestModel();
    response.setProperties(
      model.endTime,
      model.modifiedDate,
      model.name,
      model.shiftID,
      model.startTime
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>77a956ecc1797d92ad93a9e84c9b29a4</Hash>
</Codenesium>*/