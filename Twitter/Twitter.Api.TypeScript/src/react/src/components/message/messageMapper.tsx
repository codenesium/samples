import * as Api from '../../api/models';
import MessageViewModel from './messageViewModel';
import UserViewModel from '../user/userViewModel';
export default class MessageMapper {
  mapApiResponseToViewModel(
    dto: Api.MessageClientResponseModel
  ): MessageViewModel {
    let response = new MessageViewModel();
    response.setProperties(dto.content, dto.messageId, dto.senderUserId);

    if (dto.senderUserIdNavigation != null) {
      response.senderUserIdNavigation = new UserViewModel();
      response.senderUserIdNavigation.setProperties(
        dto.senderUserIdNavigation.bioImgUrl,
        dto.senderUserIdNavigation.birthday,
        dto.senderUserIdNavigation.contentDescription,
        dto.senderUserIdNavigation.email,
        dto.senderUserIdNavigation.fullName,
        dto.senderUserIdNavigation.headerImgUrl,
        dto.senderUserIdNavigation.interest,
        dto.senderUserIdNavigation.locationLocationId,
        dto.senderUserIdNavigation.password,
        dto.senderUserIdNavigation.phoneNumber,
        dto.senderUserIdNavigation.privacy,
        dto.senderUserIdNavigation.userId,
        dto.senderUserIdNavigation.username,
        dto.senderUserIdNavigation.website
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: MessageViewModel
  ): Api.MessageClientRequestModel {
    let response = new Api.MessageClientRequestModel();
    response.setProperties(model.content, model.messageId, model.senderUserId);
    return response;
  }
}


/*<Codenesium>
    <Hash>f3233ad8ca3096331a513a5daafc7610</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/