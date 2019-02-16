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
    <Hash>904602991faa1d037fd6413fa0dc49da</Hash>
</Codenesium>*/