import * as Api from '../../api/models';
import AddressTypeViewModel from './addressTypeViewModel';

export default class AddressTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.AddressTypeClientResponseModel
  ): AddressTypeViewModel {
    let response = new AddressTypeViewModel();
    response.setProperties(
      dto.addressTypeID,
      dto.modifiedDate,
      dto.name,
      dto.rowguid
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: AddressTypeViewModel
  ): Api.AddressTypeClientRequestModel {
    let response = new Api.AddressTypeClientRequestModel();
    response.setProperties(
      model.addressTypeID,
      model.modifiedDate,
      model.name,
      model.rowguid
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>aca649e56ab064c680569d1148c09382</Hash>
</Codenesium>*/