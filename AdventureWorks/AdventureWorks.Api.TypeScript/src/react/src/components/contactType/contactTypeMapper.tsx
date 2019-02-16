import * as Api from '../../api/models';
import ContactTypeViewModel from './contactTypeViewModel';

export default class ContactTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.ContactTypeClientResponseModel
  ): ContactTypeViewModel {
    let response = new ContactTypeViewModel();
    response.setProperties(dto.contactTypeID, dto.modifiedDate, dto.name);
    return response;
  }

  mapViewModelToApiRequest(
    model: ContactTypeViewModel
  ): Api.ContactTypeClientRequestModel {
    let response = new Api.ContactTypeClientRequestModel();
    response.setProperties(model.contactTypeID, model.modifiedDate, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>736bd7241ad6d1a39235da7685f7d543</Hash>
</Codenesium>*/