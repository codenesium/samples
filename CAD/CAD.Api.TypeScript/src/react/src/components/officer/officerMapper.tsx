import * as Api from '../../api/models';
import OfficerViewModel from './officerViewModel';
export default class OfficerMapper {
  mapApiResponseToViewModel(
    dto: Api.OfficerClientResponseModel
  ): OfficerViewModel {
    let response = new OfficerViewModel();
    response.setProperties(
      dto.badge,
      dto.email,
      dto.firstName,
      dto.id,
      dto.lastName,
      dto.password
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: OfficerViewModel
  ): Api.OfficerClientRequestModel {
    let response = new Api.OfficerClientRequestModel();
    response.setProperties(
      model.badge,
      model.email,
      model.firstName,
      model.id,
      model.lastName,
      model.password
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>dba7e5aafcf697ebb3df9a701b46213f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/