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
    <Hash>8f3eee147f48d685a8c93eb5b2e52aa2</Hash>
</Codenesium>*/