import * as Api from '../../api/models';
import OfficerCapabilityViewModel from './officerCapabilityViewModel';
export default class OfficerCapabilityMapper {
  mapApiResponseToViewModel(
    dto: Api.OfficerCapabilityClientResponseModel
  ): OfficerCapabilityViewModel {
    let response = new OfficerCapabilityViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: OfficerCapabilityViewModel
  ): Api.OfficerCapabilityClientRequestModel {
    let response = new Api.OfficerCapabilityClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>21089c1cf869c22e32f7b17b696fa8ad</Hash>
</Codenesium>*/