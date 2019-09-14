import * as Api from '../../api/models';
import DirectTweetViewModel from './directTweetViewModel';
import UserViewModel from '../user/userViewModel';
export default class DirectTweetMapper {
  mapApiResponseToViewModel(
    dto: Api.DirectTweetClientResponseModel
  ): DirectTweetViewModel {
    let response = new DirectTweetViewModel();
    response.setProperties(
      dto.content,
      dto.date,
      dto.taggedUserId,
      dto.time,
      dto.tweetId
    );

    if (dto.taggedUserIdNavigation != null) {
      response.taggedUserIdNavigation = new UserViewModel();
      response.taggedUserIdNavigation.setProperties(
        dto.taggedUserIdNavigation.bioImgUrl,
        dto.taggedUserIdNavigation.birthday,
        dto.taggedUserIdNavigation.contentDescription,
        dto.taggedUserIdNavigation.email,
        dto.taggedUserIdNavigation.fullName,
        dto.taggedUserIdNavigation.headerImgUrl,
        dto.taggedUserIdNavigation.interest,
        dto.taggedUserIdNavigation.locationLocationId,
        dto.taggedUserIdNavigation.password,
        dto.taggedUserIdNavigation.phoneNumber,
        dto.taggedUserIdNavigation.privacy,
        dto.taggedUserIdNavigation.userId,
        dto.taggedUserIdNavigation.username,
        dto.taggedUserIdNavigation.website
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: DirectTweetViewModel
  ): Api.DirectTweetClientRequestModel {
    let response = new Api.DirectTweetClientRequestModel();
    response.setProperties(
      model.content,
      model.date,
      model.taggedUserId,
      model.time,
      model.tweetId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>4d512b155adc56d82eea86f723a66b2c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/