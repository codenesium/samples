import * as Api from '../api/models';
import AdminViewModel from '../viewmodels/adminViewModel';

export default class AdminMapper {
  mapApiResponseToViewModel(dto: Api.AdminClientResponseModel): AdminViewModel {
    let response = new AdminViewModel();
    response.setProperties(
      dto.birthday,
      dto.email,
      dto.firstName,
      dto.id,
      dto.isDeleted,
      dto.lastName,
      dto.phone,
      dto.tenantId,
      dto.userId
    );
    return response;
  }

  mapViewModelToApiRequest(model: AdminViewModel): Api.AdminClientRequestModel {
    let response = new Api.AdminClientRequestModel();
    response.setProperties(
      model.birthday,
      model.email,
      model.firstName,
      model.id,
      model.isDeleted,
      model.lastName,
      model.phone,
      model.tenantId,
      model.userId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>885616e4a7e64530943e1435b714409f</Hash>
</Codenesium>*/