import * as Api from '../../api/models';
import FamilyViewModel from './familyViewModel';
export default class FamilyMapper {
  mapApiResponseToViewModel(
    dto: Api.FamilyClientResponseModel
  ): FamilyViewModel {
    let response = new FamilyViewModel();
    response.setProperties(
      dto.id,
      dto.notes,
      dto.primaryContactEmail,
      dto.primaryContactFirstName,
      dto.primaryContactLastName,
      dto.primaryContactPhone
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: FamilyViewModel
  ): Api.FamilyClientRequestModel {
    let response = new Api.FamilyClientRequestModel();
    response.setProperties(
      model.id,
      model.notes,
      model.primaryContactEmail,
      model.primaryContactFirstName,
      model.primaryContactLastName,
      model.primaryContactPhone
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>617ffefbb24158469e9e0ff565df8277</Hash>
</Codenesium>*/