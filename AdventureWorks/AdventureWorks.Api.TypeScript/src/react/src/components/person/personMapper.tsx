import * as Api from '../../api/models';
import PersonViewModel from './personViewModel';
import BusinessEntityViewModel from '../businessEntity/businessEntityViewModel';
export default class PersonMapper {
  mapApiResponseToViewModel(
    dto: Api.PersonClientResponseModel
  ): PersonViewModel {
    let response = new PersonViewModel();
    response.setProperties(
      dto.additionalContactInfo,
      dto.businessEntityID,
      dto.demographic,
      dto.emailPromotion,
      dto.firstName,
      dto.lastName,
      dto.middleName,
      dto.modifiedDate,
      dto.nameStyle,
      dto.personType,
      dto.rowguid,
      dto.suffix,
      dto.title
    );

    if (dto.businessEntityIDNavigation != null) {
      response.businessEntityIDNavigation = new BusinessEntityViewModel();
      response.businessEntityIDNavigation.setProperties(
        dto.businessEntityIDNavigation.businessEntityID,
        dto.businessEntityIDNavigation.modifiedDate,
        dto.businessEntityIDNavigation.rowguid
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PersonViewModel
  ): Api.PersonClientRequestModel {
    let response = new Api.PersonClientRequestModel();
    response.setProperties(
      model.additionalContactInfo,
      model.businessEntityID,
      model.demographic,
      model.emailPromotion,
      model.firstName,
      model.lastName,
      model.middleName,
      model.modifiedDate,
      model.nameStyle,
      model.personType,
      model.rowguid,
      model.suffix,
      model.title
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>e7c081bb6903d444881cbefcdfaeefea</Hash>
</Codenesium>*/