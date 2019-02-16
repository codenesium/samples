import * as Api from '../api/models';
import StudioViewModel from '../viewmodels/studioViewModel';

export default class StudioMapper {
  mapApiResponseToViewModel(
    dto: Api.StudioClientResponseModel
  ): StudioViewModel {
    let response = new StudioViewModel();
    response.setProperties(
      dto.address1,
      dto.address2,
      dto.city,
      dto.id,
      dto.isDeleted,
      dto.name,
      dto.province,
      dto.tenantId,
      dto.website,
      dto.zip
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: StudioViewModel
  ): Api.StudioClientRequestModel {
    let response = new Api.StudioClientRequestModel();
    response.setProperties(
      model.address1,
      model.address2,
      model.city,
      model.id,
      model.isDeleted,
      model.name,
      model.province,
      model.tenantId,
      model.website,
      model.zip
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>7136c9cf5d9f33ed2dd331a29151eaf9</Hash>
</Codenesium>*/