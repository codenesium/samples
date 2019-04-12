import * as Api from '../../api/models';
import TenantViewModel from './tenantViewModel';
export default class TenantMapper {
  mapApiResponseToViewModel(
    dto: Api.TenantClientResponseModel
  ): TenantViewModel {
    let response = new TenantViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: TenantViewModel
  ): Api.TenantClientRequestModel {
    let response = new Api.TenantClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>cbbfee84737c32e88674466562a19bc0</Hash>
</Codenesium>*/