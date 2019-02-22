import * as Api from '../../api/models';
import CallStatuViewModel from './callStatuViewModel';
export default class CallStatuMapper {
  mapApiResponseToViewModel(
    dto: Api.CallStatuClientResponseModel
  ): CallStatuViewModel {
    let response = new CallStatuViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: CallStatuViewModel
  ): Api.CallStatuClientRequestModel {
    let response = new Api.CallStatuClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>d527f623cd07946faf181adec7002e00</Hash>
</Codenesium>*/