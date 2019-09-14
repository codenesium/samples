import * as Api from '../../api/models';
import OrganizationViewModel from './organizationViewModel';
export default class OrganizationMapper {
  mapApiResponseToViewModel(
    dto: Api.OrganizationClientResponseModel
  ): OrganizationViewModel {
    let response = new OrganizationViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: OrganizationViewModel
  ): Api.OrganizationClientRequestModel {
    let response = new Api.OrganizationClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>636a1674c9868b3d374e32b466b771ee</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/