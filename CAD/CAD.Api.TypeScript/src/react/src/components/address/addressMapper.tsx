import * as Api from '../../api/models';
import AddressViewModel from './addressViewModel';
export default class AddressMapper {
  mapApiResponseToViewModel(
    dto: Api.AddressClientResponseModel
  ): AddressViewModel {
    let response = new AddressViewModel();
    response.setProperties(
      dto.address1,
      dto.address2,
      dto.city,
      dto.id,
      dto.state,
      dto.zip
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: AddressViewModel
  ): Api.AddressClientRequestModel {
    let response = new Api.AddressClientRequestModel();
    response.setProperties(
      model.address1,
      model.address2,
      model.city,
      model.id,
      model.state,
      model.zip
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>5d0b531748d9c40c2c15e0ccc6495836</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/