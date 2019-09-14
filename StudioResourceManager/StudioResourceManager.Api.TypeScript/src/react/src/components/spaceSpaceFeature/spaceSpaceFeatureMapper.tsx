import * as Api from '../../api/models';
import SpaceSpaceFeatureViewModel from './spaceSpaceFeatureViewModel';
import SpaceFeatureViewModel from '../spaceFeature/spaceFeatureViewModel';
import SpaceViewModel from '../space/spaceViewModel';
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
    if (dto.spaceIdNavigation != null) {
      response.spaceIdNavigation = new SpaceViewModel();
      response.spaceIdNavigation.setProperties(
        dto.spaceIdNavigation.description,
        dto.spaceIdNavigation.id,
        dto.spaceIdNavigation.name
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
    <Hash>a29ea04403c4b05185e81fbc687df360</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/