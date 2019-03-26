import * as Api from '../../api/models';
import VoteTypesViewModel from './voteTypesViewModel';
export default class VoteTypesMapper {
  mapApiResponseToViewModel(
    dto: Api.VoteTypesClientResponseModel
  ): VoteTypesViewModel {
    let response = new VoteTypesViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: VoteTypesViewModel
  ): Api.VoteTypesClientRequestModel {
    let response = new Api.VoteTypesClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>9f73b843ac2c93425e01380d20d6b259</Hash>
</Codenesium>*/