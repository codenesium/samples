import * as Api from '../../api/models';
import ScrapReasonViewModel from './scrapReasonViewModel';
export default class ScrapReasonMapper {
  mapApiResponseToViewModel(
    dto: Api.ScrapReasonClientResponseModel
  ): ScrapReasonViewModel {
    let response = new ScrapReasonViewModel();
    response.setProperties(dto.modifiedDate, dto.name, dto.scrapReasonID);

    return response;
  }

  mapViewModelToApiRequest(
    model: ScrapReasonViewModel
  ): Api.ScrapReasonClientRequestModel {
    let response = new Api.ScrapReasonClientRequestModel();
    response.setProperties(model.modifiedDate, model.name, model.scrapReasonID);
    return response;
  }
}


/*<Codenesium>
    <Hash>b3ddc8c4d2df79c52ee332acd55fc8d1</Hash>
</Codenesium>*/