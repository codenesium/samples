import * as Api from '../../api/models';
import PenViewModel from './penViewModel';
export default class PenMapper {
  mapApiResponseToViewModel(dto: Api.PenClientResponseModel): PenViewModel {
    let response = new PenViewModel();
    response.setProperties(dto.name);

    return response;
  }

  mapViewModelToApiRequest(model: PenViewModel): Api.PenClientRequestModel {
    let response = new Api.PenClientRequestModel();
    response.setProperties(model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>da3773a6ac0cf64e6df45f83e1c559fe</Hash>
</Codenesium>*/