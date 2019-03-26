import * as Api from '../../api/models';
import SpaceSpaceFeatureViewModel from './spaceSpaceFeatureViewModel';
import SpaceFeatureViewModel from '../spaceFeature/spaceFeatureViewModel';
export default class SpaceSpaceFeatureMapper {
  mapApiResponseToViewModel(
    dto: Api.SpaceSpaceFeatureClientResponseModel
  ): SpaceSpaceFeatureViewModel {
    let response = new SpaceSpaceFeatureViewModel();
    response.setProperties(dto.id, dto.spaceFeatureId, dto.spaceId);

    if (dto.spaceFeatureIdNavigation != null) {
      response.spaceFeatureIdNavigation = new SpaceFeatureViewModel();
      response.spaceFeatureIdNavigation.setProperties(
        dto.spaceFeatureIdNavigation.id,
        dto.spaceFeatureIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: SpaceSpaceFeatureViewModel
  ): Api.SpaceSpaceFeatureClientRequestModel {
    let response = new Api.SpaceSpaceFeatureClientRequestModel();
    response.setProperties(model.id, model.spaceFeatureId, model.spaceId);
    return response;
  }
}


/*<Codenesium>
    <Hash>cf83da43da8861db98784e23e8a0b20e</Hash>
</Codenesium>*/