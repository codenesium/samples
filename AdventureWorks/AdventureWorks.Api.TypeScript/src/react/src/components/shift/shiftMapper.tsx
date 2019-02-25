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
    <Hash>f6028299ab86039c8c24fda72f29b0c0</Hash>
</Codenesium>*/