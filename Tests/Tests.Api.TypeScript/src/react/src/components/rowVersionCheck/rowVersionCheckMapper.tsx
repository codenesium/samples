import * as Api from '../../api/models';
import RowVersionCheckViewModel from './rowVersionCheckViewModel';
export default class RowVersionCheckMapper {
  mapApiResponseToViewModel(
    dto: Api.RowVersionCheckClientResponseModel
  ): RowVersionCheckViewModel {
    let response = new RowVersionCheckViewModel();
    response.setProperties(dto.id, dto.name, dto.rowVersion);

    return response;
  }

  mapViewModelToApiRequest(
    model: RowVersionCheckViewModel
  ): Api.RowVersionCheckClientRequestModel {
    let response = new Api.RowVersionCheckClientRequestModel();
    response.setProperties(model.id, model.name, model.rowVersion);
    return response;
  }
}


/*<Codenesium>
    <Hash>5bdc8f83955675c2db7c47c596644b0c</Hash>
</Codenesium>*/