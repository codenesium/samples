import * as Api from '../api/models';
import FamilyViewModel from '../viewmodels/familyViewModel';

export default class FamilyMapper {
  mapApiResponseToViewModel(
    dto: Api.FamilyClientResponseModel
  ): FamilyViewModel {
    let response = new FamilyViewModel();
    response.setProperties(
      dto.id,
      dto.isDeleted,
      dto.note,
      dto.primaryContactEmail,
      dto.primaryContactFirstName,
      dto.primaryContactLastName,
      dto.primaryContactPhone,
      dto.tenantId
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: FamilyViewModel
  ): Api.FamilyClientRequestModel {
    let response = new Api.FamilyClientRequestModel();
    response.setProperties(
      model.id,
      model.isDeleted,
      model.note,
      model.primaryContactEmail,
      model.primaryContactFirstName,
      model.primaryContactLastName,
      model.primaryContactPhone,
      model.tenantId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>81c9230e05a9f52fa0c31084ea887826</Hash>
</Codenesium>*/