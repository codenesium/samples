import * as Api from '../../api/models';
import PostLinkViewModel from './postLinkViewModel';
import LinkTypeViewModel from '../linkType/linkTypeViewModel';
import PostViewModel from '../post/postViewModel';
export default class PostLinkMapper {
  mapApiResponseToViewModel(
    dto: Api.PostLinkClientResponseModel
  ): PostLinkViewModel {
    let response = new PostLinkViewModel();
    response.setProperties(
      dto.creationDate,
      dto.id,
      dto.linkTypeId,
      dto.postId,
      dto.relatedPostId
    );

    if (dto.linkTypeIdNavigation != null) {
      response.linkTypeIdNavigation = new LinkTypeViewModel();
      response.linkTypeIdNavigation.setProperties(
        dto.linkTypeIdNavigation.id,
        dto.linkTypeIdNavigation.rwType
      );
    }
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
    if (dto.relatedPostIdNavigation != null) {
      response.relatedPostIdNavigation = new PostViewModel();
      response.relatedPostIdNavigation.setProperties(
        dto.relatedPostIdNavigation.acceptedAnswerId,
        dto.relatedPostIdNavigation.answerCount,
        dto.relatedPostIdNavigation.body,
        dto.relatedPostIdNavigation.closedDate,
        dto.relatedPostIdNavigation.commentCount,
        dto.relatedPostIdNavigation.communityOwnedDate,
        dto.relatedPostIdNavigation.creationDate,
        dto.relatedPostIdNavigation.favoriteCount,
        dto.relatedPostIdNavigation.id,
        dto.relatedPostIdNavigation.lastActivityDate,
        dto.relatedPostIdNavigation.lastEditDate,
        dto.relatedPostIdNavigation.lastEditorDisplayName,
        dto.relatedPostIdNavigation.lastEditorUserId,
        dto.relatedPostIdNavigation.ownerUserId,
        dto.relatedPostIdNavigation.parentId,
        dto.relatedPostIdNavigation.postTypeId,
        dto.relatedPostIdNavigation.score,
        dto.relatedPostIdNavigation.tag,
        dto.relatedPostIdNavigation.title,
        dto.relatedPostIdNavigation.viewCount
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PostLinkViewModel
  ): Api.PostLinkClientRequestModel {
    let response = new Api.PostLinkClientRequestModel();
    response.setProperties(
      model.creationDate,
      model.id,
      model.linkTypeId,
      model.postId,
      model.relatedPostId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>34f9f2761480fc95debeb180e66f04fe</Hash>
</Codenesium>*/