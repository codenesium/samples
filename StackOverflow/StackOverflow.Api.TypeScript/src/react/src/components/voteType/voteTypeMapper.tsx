import * as Api from '../../api/models';
import VoteTypeViewModel from './voteTypeViewModel';
export default class VoteTypeMapper {
  mapApiResponseToViewModel(
    dto: Api.VoteTypeClientResponseModel
  ): VoteTypeViewModel {
    let response = new VoteTypeViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: VoteTypeViewModel
  ): Api.VoteTypeClientRequestModel {
    let response = new Api.VoteTypeClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>0986e3d527db7fe1dfd50e0e866a9030</Hash>
</Codenesium>*/