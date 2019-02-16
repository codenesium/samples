import * as Api from '../../api/models';
import FamilyViewModel from './familyViewModel';
export default class FamilyMapper {
  mapApiResponseToViewModel(
    dto: Api.FamilyClientResponseModel
  ): FamilyViewModel {
    let response = new FamilyViewModel();
    response.setProperties(
      dto.id,
      dto.note,
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
      model.note,
      model.primaryContactEmail,
      model.primaryContactFirstName,
      model.primaryContactLastName,
      model.primaryContactPhone
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>c649e9bb8b9c59072ff217680ede2c60</Hash>
</Codenesium>*/