import * as Api from '../../api/models';
import AddressViewModel from './addressViewModel';

export default class AddressMapper {
  mapApiResponseToViewModel(
    dto: Api.AddressClientResponseModel
  ): AddressViewModel {
    let response = new AddressViewModel();
    response.setProperties(
      dto.addressID,
      dto.addressLine1,
      dto.addressLine2,
      dto.city,
      dto.modifiedDate,
      dto.postalCode,
      dto.rowguid,
      dto.stateProvinceID
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: AddressViewModel
  ): Api.AddressClientRequestModel {
    let response = new Api.AddressClientRequestModel();
    response.setProperties(
      model.addressID,
      model.addressLine1,
      model.addressLine2,
      model.city,
      model.modifiedDate,
      model.postalCode,
      model.rowguid,
      model.stateProvinceID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>717663bac0309f1f0ec53821076a1086</Hash>
</Codenesium>*/