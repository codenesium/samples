import * as Api from '../../api/models';
import PasswordViewModel from './passwordViewModel';
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
    <Hash>cd027ba5067bde7af19b3f3930222a00</Hash>
</Codenesium>*/