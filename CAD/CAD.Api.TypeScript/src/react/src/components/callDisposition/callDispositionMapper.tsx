import * as Api from '../../api/models';
import CallDispositionViewModel from './callDispositionViewModel';
export default class CallDispositionMapper {
  mapApiResponseToViewModel(
    dto: Api.CallDispositionClientResponseModel
  ): CallDispositionViewModel {
    let response = new CallDispositionViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: CallDispositionViewModel
  ): Api.CallDispositionClientRequestModel {
    let response = new Api.CallDispositionClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>1c0d59d5b2820b5fee28c76966131ba9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/