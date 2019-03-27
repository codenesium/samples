import * as Api from '../../api/models';
import SpaceSpaceFeatureViewModel from './spaceSpaceFeatureViewModel';
import SpaceFeatureViewModel from '../spaceFeature/spaceFeatureViewModel';
export default class SpaceSpaceFeatureMapper {
  mapApiResponseToViewModel(
    dto: Api.SpaceSpaceFeatureClientResponseModel
  ): SpaceSpaceFeatureViewModel {
    let response = new SpaceSpaceFeatureViewModel();
    response.setProperties(dto.spaceFeatureId, dto.spaceId);

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
    response.setProperties(model.spaceFeatureId, model.spaceId);
    return response;
  }
}


/*<Codenesium>
    <Hash>bee3a0640cfd6ed1e6bf51c6d9de8998</Hash>
</Codenesium>*/