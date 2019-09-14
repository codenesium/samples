import * as Api from '../../api/models';
import VoteViewModel from './voteViewModel';
import PostViewModel from '../post/postViewModel';
import UserViewModel from '../user/userViewModel';
import VoteTypeViewModel from '../voteType/voteTypeViewModel';
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

    if (dto.postIdNavigation != null) {
      response.postIdNavigation = new PostViewModel();
      response.postIdNavigation.setProperties(
        dto.postIdNavigation.acceptedAnswerId,
        dto.postIdNavigation.answerCount,
        dto.postIdNavigation.body,
        dto.postIdNavigation.closedDate,
        dto.postIdNavigation.commentCount,
        dto.postIdNavigation.communityOwnedDate,
        dto.postIdNavigation.creationDate,
        dto.postIdNavigation.favoriteCount,
        dto.postIdNavigation.id,
        dto.postIdNavigation.lastActivityDate,
        dto.postIdNavigation.lastEditDate,
        dto.postIdNavigation.lastEditorDisplayName,
        dto.postIdNavigation.lastEditorUserId,
        dto.postIdNavigation.ownerUserId,
        dto.postIdNavigation.parentId,
        dto.postIdNavigation.postTypeId,
        dto.postIdNavigation.score,
        dto.postIdNavigation.tag,
        dto.postIdNavigation.title,
        dto.postIdNavigation.viewCount
      );
    }
    if (dto.userIdNavigation != null) {
      response.userIdNavigation = new UserViewModel();
      response.userIdNavigation.setProperties(
        dto.userIdNavigation.aboutMe,
        dto.userIdNavigation.accountId,
        dto.userIdNavigation.age,
        dto.userIdNavigation.creationDate,
        dto.userIdNavigation.displayName,
        dto.userIdNavigation.downVote,
        dto.userIdNavigation.emailHash,
        dto.userIdNavigation.id,
        dto.userIdNavigation.lastAccessDate,
        dto.userIdNavigation.location,
        dto.userIdNavigation.reputation,
        dto.userIdNavigation.upVote,
        dto.userIdNavigation.view,
        dto.userIdNavigation.websiteUrl
      );
    }
    if (dto.voteTypeIdNavigation != null) {
      response.voteTypeIdNavigation = new VoteTypeViewModel();
      response.voteTypeIdNavigation.setProperties(
        dto.voteTypeIdNavigation.id,
        dto.voteTypeIdNavigation.name
      );
    }

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
    <Hash>b65d39541e8faefe9868b61acdd874d5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/