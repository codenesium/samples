import * as Api from '../../api/models';
import SpaceFeatureViewModel from './spaceFeatureViewModel';
export default class SpaceFeatureMapper {
  mapApiResponseToViewModel(
    dto: Api.SpaceFeatureClientResponseModel
  ): SpaceFeatureViewModel {
    let response = new SpaceFeatureViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: SpaceFeatureViewModel
  ): Api.SpaceFeatureClientRequestModel {
    let response = new Api.SpaceFeatureClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>0f945be29f95ea66bc5d878347e3ea6f</Hash>
</Codenesium>*/