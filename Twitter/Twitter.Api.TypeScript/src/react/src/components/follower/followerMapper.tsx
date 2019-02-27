import * as Api from '../../api/models';
import FollowerViewModel from  './followerViewModel';
	import UserViewModel from '../user/userViewModel'
	export default class FollowerMapper {
    
	mapApiResponseToViewModel(dto: Api.FollowerClientResponseModel) : FollowerViewModel 
	{
		let response = new FollowerViewModel();
		response.setProperties(dto.blocked,dto.dateFollowed,dto.followRequestStatu,dto.followedUserId,dto.followingUserId,dto.id,dto.muted);
		
						if(dto.followedUserIdNavigation != null)
				{
				  response.followedUserIdNavigation = new UserViewModel();
				  response.followedUserIdNavigation.setProperties(
				  dto.followedUserIdNavigation.bioImgUrl,dto.followedUserIdNavigation.birthday,dto.followedUserIdNavigation.contentDescription,dto.followedUserIdNavigation.email,dto.followedUserIdNavigation.fullName,dto.followedUserIdNavigation.headerImgUrl,dto.followedUserIdNavigation.interest,dto.followedUserIdNavigation.locationLocationId,dto.followedUserIdNavigation.password,dto.followedUserIdNavigation.phoneNumber,dto.followedUserIdNavigation.privacy,dto.followedUserIdNavigation.userId,dto.followedUserIdNavigation.username,dto.followedUserIdNavigation.website
				  );
				}
							if(dto.followingUserIdNavigation != null)
				{
				  response.followingUserIdNavigation = new UserViewModel();
				  response.followingUserIdNavigation.setProperties(
				  dto.followingUserIdNavigation.bioImgUrl,dto.followingUserIdNavigation.birthday,dto.followingUserIdNavigation.contentDescription,dto.followingUserIdNavigation.email,dto.followingUserIdNavigation.fullName,dto.followingUserIdNavigation.headerImgUrl,dto.followingUserIdNavigation.interest,dto.followingUserIdNavigation.locationLocationId,dto.followingUserIdNavigation.password,dto.followingUserIdNavigation.phoneNumber,dto.followingUserIdNavigation.privacy,dto.followingUserIdNavigation.userId,dto.followingUserIdNavigation.username,dto.followingUserIdNavigation.website
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: FollowerViewModel) : Api.FollowerClientRequestModel
	{
		let response = new Api.FollowerClientRequestModel();
		response.setProperties(model.blocked,model.dateFollowed,model.followRequestStatu,model.followedUserId,model.followingUserId,model.id,model.muted);
		return response;
	}
};

/*<Codenesium>
    <Hash>c8b2cc7e8c32e5bda7bf94a18ee14356</Hash>
</Codenesium>*/