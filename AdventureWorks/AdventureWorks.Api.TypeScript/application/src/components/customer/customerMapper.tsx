import * as Api from '../../api/models';
import CustomerViewModel from './customerViewModel';

export default class CustomerMapper {
  mapApiResponseToViewModel(
    dto: Api.CustomerClientResponseModel
  ): CustomerViewModel {
    let response = new CustomerViewModel();
    response.setProperties(
      dto.accountNumber,
      dto.customerID,
      dto.modifiedDate,
      dto.personID,
      dto.rowguid,
      dto.storeID,
      dto.territoryID
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: CustomerViewModel
  ): Api.CustomerClientRequestModel {
    let response = new Api.CustomerClientRequestModel();
    response.setProperties(
      model.accountNumber,
      model.customerID,
      model.modifiedDate,
      model.personID,
      model.rowguid,
      model.storeID,
      model.territoryID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>fe9e09b44ad70e59048bc0ded8da78b3</Hash>
</Codenesium>*/