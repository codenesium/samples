import * as Api from '../../api/models';
import PhoneNumberTypeViewModel from './phoneNumberTypeViewModel';
export default class PhoneNumberTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.PhoneNumberTypeClientResponseModel
  ): PhoneNumberTypeViewModel {
    let response = new PhoneNumberTypeViewModel();
    response.setProperties(dto.modifiedDate, dto.name, dto.phoneNumberTypeID);

    return response;
  }

  mapViewModelToApiRequest(
    model: PhoneNumberTypeViewModel
  ): Api.PhoneNumberTypeClientRequestModel {
    let response = new Api.PhoneNumberTypeClientRequestModel();
    response.setProperties(
      model.modifiedDate,
      model.name,
      model.phoneNumberTypeID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>3049f1a79f30e0aac968d615fe95a136</Hash>
</Codenesium>*/