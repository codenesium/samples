import * as Api from '../../api/models';
import VotesViewModel from './votesViewModel';
import PostsViewModel from '../posts/postsViewModel';
import UsersViewModel from '../users/usersViewModel';
import VoteTypesViewModel from '../voteTypes/voteTypesViewModel';
export default class VotesMapper {
  mapApiResponseToViewModel(dto: Api.VotesClientResponseModel): VotesViewModel {
    let response = new VotesViewModel();
    response.setProperties(
      dto.bountyAmount,
      dto.creationDate,
      dto.id,
      dto.postId,
      dto.userId,
      dto.voteTypeId
    );

    if (dto.postIdNavigation != null) {
      response.postIdNavigation = new PostsViewModel();
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
      response.userIdNavigation = new UsersViewModel();
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
      response.voteTypeIdNavigation = new VoteTypesViewModel();
      response.voteTypeIdNavigation.setProperties(
        dto.voteTypeIdNavigation.id,
        dto.voteTypeIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: VotesViewModel): Api.VotesClientRequestModel {
    let response = new Api.VotesClientRequestModel();
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
    <Hash>89eb766c5065fccf331d8a742325dfd2</Hash>
</Codenesium>*/