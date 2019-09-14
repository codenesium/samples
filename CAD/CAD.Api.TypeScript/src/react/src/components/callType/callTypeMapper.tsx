import * as Api from '../../api/models';
import CallTypeViewModel from './callTypeViewModel';
export default class CallTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.CallTypeClientResponseModel
  ): CallTypeViewModel {
    let response = new CallTypeViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: CallTypeViewModel
  ): Api.CallTypeClientRequestModel {
    let response = new Api.CallTypeClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>3a0cff4f50278be3156a18bd17774d52</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/