import * as Api from '../../api/models';
import IllustrationViewModel from './illustrationViewModel';
export default class IllustrationMapper {
  mapApiResponseToViewModel(
    dto: Api.IllustrationClientResponseModel
  ): IllustrationViewModel {
    let response = new IllustrationViewModel();
    response.setProperties(dto.diagram, dto.illustrationID, dto.modifiedDate);

    return response;
  }

  mapViewModelToApiRequest(
    model: IllustrationViewModel
  ): Api.IllustrationClientRequestModel {
    let response = new Api.IllustrationClientRequestModel();
    response.setProperties(
      model.diagram,
      model.illustrationID,
      model.modifiedDate
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>9e7937a30ff3d1d35048db5775a2aa3a</Hash>
</Codenesium>*/