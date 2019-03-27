import * as Api from '../../api/models';
import CallStatusViewModel from './callStatusViewModel';
export default class CallStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.CallStatusClientResponseModel
  ): CallStatusViewModel {
    let response = new CallStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: CallStatusViewModel
  ): Api.CallStatusClientRequestModel {
    let response = new Api.CallStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>d0388d81d9e0dc8638ee94cb2190936c</Hash>
</Codenesium>*/