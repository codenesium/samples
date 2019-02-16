import * as Api from '../../api/models';
import CultureViewModel from './cultureViewModel';

export default class CultureMapper {
  mapApiResponseToViewModel(
    dto: Api.CultureClientResponseModel
  ): CultureViewModel {
    let response = new CultureViewModel();
    response.setProperties(dto.cultureID, dto.modifiedDate, dto.name);
    return response;
  }

  mapViewModelToApiRequest(
    model: CultureViewModel
  ): Api.CultureClientRequestModel {
    let response = new Api.CultureClientRequestModel();
    response.setProperties(model.cultureID, model.modifiedDate, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>322cdfc814a0dc6330a096891a836482</Hash>
</Codenesium>*/