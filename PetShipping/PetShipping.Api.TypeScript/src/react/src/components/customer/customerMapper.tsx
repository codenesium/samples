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
      dto.notes,
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
      model.notes,
      model.phone
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>e4b6f760901d04c93eae741790534d39</Hash>
</Codenesium>*/