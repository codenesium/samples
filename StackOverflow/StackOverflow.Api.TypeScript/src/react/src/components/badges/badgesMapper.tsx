import * as Api from '../../api/models';
import BadgesViewModel from  './badgesViewModel';
	import UsersViewModel from '../users/usersViewModel'
	export default class BadgesMapper {
    
	mapApiResponseToViewModel(dto: Api.BadgesClientResponseModel) : BadgesViewModel 
	{
		let response = new BadgesViewModel();
		response.setProperties(dto.date,dto.id,dto.name,dto.userId);
		
						if(dto.userIdNavigation != null)
				{
				  response.userIdNavigation = new UsersViewModel();
				  response.userIdNavigation.setProperties(
				  dto.userIdNavigation.aboutMe,dto.userIdNavigation.accountId,dto.userIdNavigation.age,dto.userIdNavigation.creationDate,dto.userIdNavigation.displayName,dto.userIdNavigation.downVote,dto.userIdNavigation.emailHash,dto.userIdNavigation.id,dto.userIdNavigation.lastAccessDate,dto.userIdNavigation.location,dto.userIdNavigation.reputation,dto.userIdNavigation.upVote,dto.userIdNavigation.view,dto.userIdNavigation.websiteUrl
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: BadgesViewModel) : Api.BadgesClientRequestModel
	{
		let response = new Api.BadgesClientRequestModel();
		response.setProperties(model.date,model.id,model.name,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>4131a9ced7a8898491745c9e635f2d79</Hash>
</Codenesium>*/