import * as Api from '../../api/models';
import BadgeViewModel from './badgeViewModel';
import UserViewModel from '../user/userViewModel';
export default class BadgeMapper {
  mapApiResponseToViewModel(dto: Api.BadgeClientResponseModel): BadgeViewModel {
    let response = new BadgeViewModel();
    response.setProperties(dto.date, dto.id, dto.name, dto.userId);

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

    return response;
  }

  mapViewModelToApiRequest(model: BadgeViewModel): Api.BadgeClientRequestModel {
    let response = new Api.BadgeClientRequestModel();
    response.setProperties(model.date, model.id, model.name, model.userId);
    return response;
  }
}


/*<Codenesium>
    <Hash>6b804aeda952d57e244f4bcea79be467</Hash>
</Codenesium>*/