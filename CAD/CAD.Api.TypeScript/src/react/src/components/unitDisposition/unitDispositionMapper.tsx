import * as Api from '../../api/models';
import UnitDispositionViewModel from './unitDispositionViewModel';
export default class UnitDispositionMapper {
  mapApiResponseToViewModel(
    dto: Api.UnitDispositionClientResponseModel
  ): UnitDispositionViewModel {
    let response = new UnitDispositionViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: UnitDispositionViewModel
  ): Api.UnitDispositionClientRequestModel {
    let response = new Api.UnitDispositionClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>485dd48ae763a8212c09bc500e1a264a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/