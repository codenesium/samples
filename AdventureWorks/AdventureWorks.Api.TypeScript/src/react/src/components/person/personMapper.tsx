import * as Api from '../../api/models';
import PersonViewModel from './personViewModel';
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
    <Hash>901944b6ca10a06f40fdf57783f1833d</Hash>
</Codenesium>*/