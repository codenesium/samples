import * as Api from '../../api/models';
import VoteViewModel from './voteViewModel';
export default class VoteMapper {
  mapApiResponseToViewModel(dto: Api.VoteClientResponseModel): VoteViewModel {
    let response = new VoteViewModel();
    response.setProperties(
      dto.bountyAmount,
      dto.creationDate,
      dto.id,
      dto.postId,
      dto.userId,
      dto.voteTypeId
    );

    return response;
  }

  mapViewModelToApiRequest(model: VoteViewModel): Api.VoteClientRequestModel {
    let response = new Api.VoteClientRequestModel();
    response.setProperties(
      model.bountyAmount,
      model.creationDate,
      model.id,
      model.postId,
      model.userId,
      model.voteTypeId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>bd0296ac3ddd4a4bf6042f495cc0236b</Hash>
</Codenesium>*/