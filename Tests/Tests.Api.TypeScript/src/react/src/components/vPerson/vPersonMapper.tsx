import * as Api from '../../api/models';
import VPersonViewModel from './vPersonViewModel';
export default class VPersonMapper {
  mapApiResponseToViewModel(
    dto: Api.VPersonClientResponseModel
  ): VPersonViewModel {
    let response = new VPersonViewModel();
    response.setProperties(dto.personId, dto.personName);

    return response;
  }

  mapViewModelToApiRequest(
    model: VPersonViewModel
  ): Api.VPersonClientRequestModel {
    let response = new Api.VPersonClientRequestModel();
    response.setProperties(model.personId, model.personName);
    return response;
  }
}


/*<Codenesium>
    <Hash>04e61d4697953c879a4f84b517be0d6f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/