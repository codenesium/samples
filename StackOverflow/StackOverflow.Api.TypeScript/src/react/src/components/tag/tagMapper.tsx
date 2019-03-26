import * as Api from '../../api/models';
import TagViewModel from './tagViewModel';
import PostViewModel from '../post/postViewModel';
export default class TagMapper {
  mapApiResponseToViewModel(dto: Api.TagClientResponseModel): TagViewModel {
    let response = new TagViewModel();
    response.setProperties(
      dto.count,
      dto.excerptPostId,
      dto.id,
      dto.tagName,
      dto.wikiPostId
    );

    if (dto.excerptPostIdNavigation != null) {
      response.excerptPostIdNavigation = new PostViewModel();
      response.excerptPostIdNavigation.setProperties(
        dto.excerptPostIdNavigation.acceptedAnswerId,
        dto.excerptPostIdNavigation.answerCount,
        dto.excerptPostIdNavigation.body,
        dto.excerptPostIdNavigation.closedDate,
        dto.excerptPostIdNavigation.commentCount,
        dto.excerptPostIdNavigation.communityOwnedDate,
        dto.excerptPostIdNavigation.creationDate,
        dto.excerptPostIdNavigation.favoriteCount,
        dto.excerptPostIdNavigation.id,
        dto.excerptPostIdNavigation.lastActivityDate,
        dto.excerptPostIdNavigation.lastEditDate,
        dto.excerptPostIdNavigation.lastEditorDisplayName,
        dto.excerptPostIdNavigation.lastEditorUserId,
        dto.excerptPostIdNavigation.ownerUserId,
        dto.excerptPostIdNavigation.parentId,
        dto.excerptPostIdNavigation.postTypeId,
        dto.excerptPostIdNavigation.score,
        dto.excerptPostIdNavigation.tag,
        dto.excerptPostIdNavigation.title,
        dto.excerptPostIdNavigation.viewCount
      );
    }
    if (dto.wikiPostIdNavigation != null) {
      response.wikiPostIdNavigation = new PostViewModel();
      response.wikiPostIdNavigation.setProperties(
        dto.wikiPostIdNavigation.acceptedAnswerId,
        dto.wikiPostIdNavigation.answerCount,
        dto.wikiPostIdNavigation.body,
        dto.wikiPostIdNavigation.closedDate,
        dto.wikiPostIdNavigation.commentCount,
        dto.wikiPostIdNavigation.communityOwnedDate,
        dto.wikiPostIdNavigation.creationDate,
        dto.wikiPostIdNavigation.favoriteCount,
        dto.wikiPostIdNavigation.id,
        dto.wikiPostIdNavigation.lastActivityDate,
        dto.wikiPostIdNavigation.lastEditDate,
        dto.wikiPostIdNavigation.lastEditorDisplayName,
        dto.wikiPostIdNavigation.lastEditorUserId,
        dto.wikiPostIdNavigation.ownerUserId,
        dto.wikiPostIdNavigation.parentId,
        dto.wikiPostIdNavigation.postTypeId,
        dto.wikiPostIdNavigation.score,
        dto.wikiPostIdNavigation.tag,
        dto.wikiPostIdNavigation.title,
        dto.wikiPostIdNavigation.viewCount
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: TagViewModel): Api.TagClientRequestModel {
    let response = new Api.TagClientRequestModel();
    response.setProperties(
      model.count,
      model.excerptPostId,
      model.id,
      model.tagName,
      model.wikiPostId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>81f6150d47b12e299995f7ad292e3859</Hash>
</Codenesium>*/