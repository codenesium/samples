import * as Api from '../../api/models';
import PasswordViewModel from './passwordViewModel';
import PersonViewModel from '../person/personViewModel';
export default class PasswordMapper {
  mapApiResponseToViewModel(
    dto: Api.PasswordClientResponseModel
  ): PasswordViewModel {
    let response = new PasswordViewModel();
    response.setProperties(
      dto.businessEntityID,
      dto.modifiedDate,
      dto.passwordHash,
      dto.passwordSalt,
      dto.rowguid
    );

    if (dto.businessEntityIDNavigation != null) {
      response.businessEntityIDNavigation = new PersonViewModel();
      response.businessEntityIDNavigation.setProperties(
        dto.businessEntityIDNavigation.additionalContactInfo,
        dto.businessEntityIDNavigation.businessEntityID,
        dto.businessEntityIDNavigation.demographic,
        dto.businessEntityIDNavigation.emailPromotion,
        dto.businessEntityIDNavigation.firstName,
        dto.businessEntityIDNavigation.lastName,
        dto.businessEntityIDNavigation.middleName,
        dto.businessEntityIDNavigation.modifiedDate,
        dto.businessEntityIDNavigation.nameStyle,
        dto.businessEntityIDNavigation.personType,
        dto.businessEntityIDNavigation.rowguid,
        dto.businessEntityIDNavigation.suffix,
        dto.businessEntityIDNavigation.title
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PasswordViewModel
  ): Api.PasswordClientRequestModel {
    let response = new Api.PasswordClientRequestModel();
    response.setProperties(
      model.businessEntityID,
      model.modifiedDate,
      model.passwordHash,
      model.passwordSalt,
      model.rowguid
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>8ff6850bb9a9dff8db48562ef177629d</Hash>
</Codenesium>*/