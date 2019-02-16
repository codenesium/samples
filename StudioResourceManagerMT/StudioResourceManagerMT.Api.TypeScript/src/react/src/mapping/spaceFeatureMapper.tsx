import * as Api from '../api/models';
import SpaceFeatureViewModel from '../viewmodels/spaceFeatureViewModel';

export default class SpaceFeatureMapper {
  mapApiResponseToViewModel(
    dto: Api.SpaceFeatureClientResponseModel
  ): SpaceFeatureViewModel {
    let response = new SpaceFeatureViewModel();
    response.setProperties(dto.id, dto.isDeleted, dto.name, dto.tenantId);
    return response;
  }

  mapViewModelToApiRequest(
    model: SpaceFeatureViewModel
  ): Api.SpaceFeatureClientRequestModel {
    let response = new Api.SpaceFeatureClientRequestModel();
    response.setProperties(
      model.id,
      model.isDeleted,
      model.name,
      model.tenantId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>df0b69f130a7ff0808b2f75185ae0ad7</Hash>
</Codenesium>*/