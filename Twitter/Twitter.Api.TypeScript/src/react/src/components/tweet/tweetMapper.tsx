import * as Api from '../../api/models';
import TweetViewModel from './tweetViewModel';
import LocationViewModel from '../location/locationViewModel';
import UserViewModel from '../user/userViewModel';
export default class TweetMapper {
  mapApiResponseToViewModel(dto: Api.TweetClientResponseModel): TweetViewModel {
    let response = new TweetViewModel();
    response.setProperties(
      dto.content,
      dto.date,
      dto.locationId,
      dto.time,
      dto.tweetId,
      dto.userUserId
    );

    if (dto.locationIdNavigation != null) {
      response.locationIdNavigation = new LocationViewModel();
      response.locationIdNavigation.setProperties(
        dto.locationIdNavigation.gpsLat,
        dto.locationIdNavigation.gpsLong,
        dto.locationIdNavigation.locationId,
        dto.locationIdNavigation.locationName
      );
    }
    if (dto.userUserIdNavigation != null) {
      response.userUserIdNavigation = new UserViewModel();
      response.userUserIdNavigation.setProperties(
        dto.userUserIdNavigation.bioImgUrl,
        dto.userUserIdNavigation.birthday,
        dto.userUserIdNavigation.contentDescription,
        dto.userUserIdNavigation.email,
        dto.userUserIdNavigation.fullName,
        dto.userUserIdNavigation.headerImgUrl,
        dto.userUserIdNavigation.interest,
        dto.userUserIdNavigation.locationLocationId,
        dto.userUserIdNavigation.password,
        dto.userUserIdNavigation.phoneNumber,
        dto.userUserIdNavigation.privacy,
        dto.userUserIdNavigation.userId,
        dto.userUserIdNavigation.username,
        dto.userUserIdNavigation.website
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: TweetViewModel): Api.TweetClientRequestModel {
    let response = new Api.TweetClientRequestModel();
    response.setProperties(
      model.content,
      model.date,
      model.locationId,
      model.time,
      model.tweetId,
      model.userUserId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>2cb52520727da459c3738eeaebdc7317</Hash>
</Codenesium>*/