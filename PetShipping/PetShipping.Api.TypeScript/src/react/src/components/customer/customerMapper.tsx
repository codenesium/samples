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
      dto.note,
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
      model.note,
      model.phone
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>dd0c276780a33b16a634dadf02ab31f4</Hash>
</Codenesium>*/