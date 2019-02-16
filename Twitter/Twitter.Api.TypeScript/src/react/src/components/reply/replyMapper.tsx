import * as Api from '../../api/models';
import ReplyViewModel from './replyViewModel';
import UserViewModel from '../user/userViewModel';
export default class ReplyMapper {
  mapApiResponseToViewModel(dto: Api.ReplyClientResponseModel): ReplyViewModel {
    let response = new ReplyViewModel();
    response.setProperties(
      dto.content,
      dto.date,
      dto.replierUserId,
      dto.replyId,
      dto.time
    );

    if (dto.replierUserIdNavigation != null) {
      response.replierUserIdNavigation = new UserViewModel();
      response.replierUserIdNavigation.setProperties(
        dto.replierUserIdNavigation.bioImgUrl,
        dto.replierUserIdNavigation.birthday,
        dto.replierUserIdNavigation.contentDescription,
        dto.replierUserIdNavigation.email,
        dto.replierUserIdNavigation.fullName,
        dto.replierUserIdNavigation.headerImgUrl,
        dto.replierUserIdNavigation.interest,
        dto.replierUserIdNavigation.locationLocationId,
        dto.replierUserIdNavigation.password,
        dto.replierUserIdNavigation.phoneNumber,
        dto.replierUserIdNavigation.privacy,
        dto.replierUserIdNavigation.userId,
        dto.replierUserIdNavigation.username,
        dto.replierUserIdNavigation.website
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: ReplyViewModel): Api.ReplyClientRequestModel {
    let response = new Api.ReplyClientRequestModel();
    response.setProperties(
      model.content,
      model.date,
      model.replierUserId,
      model.replyId,
      model.time
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>a377d6590efa66b10d46d4333a1f811a</Hash>
</Codenesium>*/