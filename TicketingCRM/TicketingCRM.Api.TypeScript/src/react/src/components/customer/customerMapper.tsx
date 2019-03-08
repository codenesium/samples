import * as Api from '../../api/models';
import CustomerViewModel from './customerViewModel';
export default class CustomerMapper {
  mapApiResponseToViewModel(
    dto: Api.CustomerClientResponseModel
  ): CustomerViewModel {
    let response = new CustomerViewModel();
    response.setProperties(
      dto.email,
      dto.firstName,
      dto.id,
      dto.lastName,
      dto.phone
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: CustomerViewModel
  ): Api.CustomerClientRequestModel {
    let response = new Api.CustomerClientRequestModel();
    response.setProperties(
      model.email,
      model.firstName,
      model.id,
      model.lastName,
      model.phone
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>c7c789f62b5bf70086e037ef1824777b</Hash>
</Codenesium>*/