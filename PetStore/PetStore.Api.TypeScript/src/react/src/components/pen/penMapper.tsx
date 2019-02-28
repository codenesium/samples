import * as Api from '../../api/models';
import PenViewModel from './penViewModel';
export default class PenMapper {
  mapApiResponseToViewModel(dto: Api.PenClientResponseModel): PenViewModel {
    let response = new PenViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(model: PenViewModel): Api.PenClientRequestModel {
    let response = new Api.PenClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>fc10bee8d2577922bf788109c8258552</Hash>
</Codenesium>*/