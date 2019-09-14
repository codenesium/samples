import * as Api from '../../api/models';
import OffCapabilityViewModel from './offCapabilityViewModel';
export default class OffCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.OffCapabilityClientResponseModel
  ): OffCapabilityViewModel {
    let response = new OffCapabilityViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: OffCapabilityViewModel
  ): Api.OffCapabilityClientRequestModel {
    let response = new Api.OffCapabilityClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>3df06d8395855a46ea69b7605eeb22ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/