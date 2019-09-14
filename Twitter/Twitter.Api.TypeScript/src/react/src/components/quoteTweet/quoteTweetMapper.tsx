import * as Api from '../../api/models';
import QuoteTweetViewModel from './quoteTweetViewModel';
import UserViewModel from '../user/userViewModel';
import TweetViewModel from '../tweet/tweetViewModel';
export default class QuoteTweetMapper {
  mapApiResponseToViewModel(
    dto: Api.QuoteTweetClientResponseModel
  ): QuoteTweetViewModel {
    let response = new QuoteTweetViewModel();
    response.setProperties(
      dto.content,
      dto.date,
      dto.quoteTweetId,
      dto.retweeterUserId,
      dto.sourceTweetId,
      dto.time
    );

    if (dto.retweeterUserIdNavigation != null) {
      response.retweeterUserIdNavigation = new UserViewModel();
      response.retweeterUserIdNavigation.setProperties(
        dto.retweeterUserIdNavigation.bioImgUrl,
        dto.retweeterUserIdNavigation.birthday,
        dto.retweeterUserIdNavigation.contentDescription,
        dto.retweeterUserIdNavigation.email,
        dto.retweeterUserIdNavigation.fullName,
        dto.retweeterUserIdNavigation.headerImgUrl,
        dto.retweeterUserIdNavigation.interest,
        dto.retweeterUserIdNavigation.locationLocationId,
        dto.retweeterUserIdNavigation.password,
        dto.retweeterUserIdNavigation.phoneNumber,
        dto.retweeterUserIdNavigation.privacy,
        dto.retweeterUserIdNavigation.userId,
        dto.retweeterUserIdNavigation.username,
        dto.retweeterUserIdNavigation.website
      );
    }
    if (dto.sourceTweetIdNavigation != null) {
      response.sourceTweetIdNavigation = new TweetViewModel();
      response.sourceTweetIdNavigation.setProperties(
        dto.sourceTweetIdNavigation.content,
        dto.sourceTweetIdNavigation.date,
        dto.sourceTweetIdNavigation.locationId,
        dto.sourceTweetIdNavigation.time,
        dto.sourceTweetIdNavigation.tweetId,
        dto.sourceTweetIdNavigation.userUserId
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: QuoteTweetViewModel
  ): Api.QuoteTweetClientRequestModel {
    let response = new Api.QuoteTweetClientRequestModel();
    response.setProperties(
      model.content,
      model.date,
      model.quoteTweetId,
      model.retweeterUserId,
      model.sourceTweetId,
      model.time
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>7f973d8da620b11f3e500c8fe2ebce6b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/