import * as Api from '../../api/models';
import ChainStatusViewModel from './chainStatusViewModel';
export default class ChainStatusMapper {
  mapApiResponseToViewModel(
    dto: Api.ChainStatusClientResponseModel
  ): ChainStatusViewModel {
    let response = new ChainStatusViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: ChainStatusViewModel
  ): Api.ChainStatusClientRequestModel {
    let response = new Api.ChainStatusClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>dbde6914a4a581a0f4ba6eae610e55f2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/