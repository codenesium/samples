import * as Api from '../../api/models';
import MessengerViewModel from  './messengerViewModel';
	import MessageViewModel from '../message/messageViewModel'
		import UserViewModel from '../user/userViewModel'
	export default class MessengerMapper {
    
	mapApiResponseToViewModel(dto: Api.MessengerClientResponseModel) : MessengerViewModel 
	{
		let response = new MessengerViewModel();
		response.setProperties(dto.date,dto.fromUserId,dto.id,dto.messageId,dto.time,dto.toUserId,dto.userId);
		
						if(dto.messageIdNavigation != null)
				{
				  response.messageIdNavigation = new MessageViewModel();
				  response.messageIdNavigation.setProperties(
				  dto.messageIdNavigation.content,dto.messageIdNavigation.messageId,dto.messageIdNavigation.senderUserId
				  );
				}
							if(dto.toUserIdNavigation != null)
				{
				  response.toUserIdNavigation = new UserViewModel();
				  response.toUserIdNavigation.setProperties(
				  dto.toUserIdNavigation.bioImgUrl,dto.toUserIdNavigation.birthday,dto.toUserIdNavigation.contentDescription,dto.toUserIdNavigation.email,dto.toUserIdNavigation.fullName,dto.toUserIdNavigation.headerImgUrl,dto.toUserIdNavigation.interest,dto.toUserIdNavigation.locationLocationId,dto.toUserIdNavigation.password,dto.toUserIdNavigation.phoneNumber,dto.toUserIdNavigation.privacy,dto.toUserIdNavigation.userId,dto.toUserIdNavigation.username,dto.toUserIdNavigation.website
				  );
				}
							if(dto.userIdNavigation != null)
				{
				  response.userIdNavigation = new UserViewModel();
				  response.userIdNavigation.setProperties(
				  dto.userIdNavigation.bioImgUrl,dto.userIdNavigation.birthday,dto.userIdNavigation.contentDescription,dto.userIdNavigation.email,dto.userIdNavigation.fullName,dto.userIdNavigation.headerImgUrl,dto.userIdNavigation.interest,dto.userIdNavigation.locationLocationId,dto.userIdNavigation.password,dto.userIdNavigation.phoneNumber,dto.userIdNavigation.privacy,dto.userIdNavigation.userId,dto.userIdNavigation.username,dto.userIdNavigation.website
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: MessengerViewModel) : Api.MessengerClientRequestModel
	{
		let response = new Api.MessengerClientRequestModel();
		response.setProperties(model.date,model.fromUserId,model.id,model.messageId,model.time,model.toUserId,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>ffb92f75d87d2282a684fc8ba3e6fbc0</Hash>
</Codenesium>*/