import * as Api from '../../api/models';
import UserViewModel from  './userViewModel';
export default class UserMapper {
    
	mapApiResponseToViewModel(dto: Api.UserClientResponseModel) : UserViewModel 
	{
		let response = new UserViewModel();
		response.setProperties(dto.aboutMe,dto.accountId,dto.age,dto.creationDate,dto.displayName,dto.downVote,dto.emailHash,dto.id,dto.lastAccessDate,dto.location,dto.reputation,dto.upVote,dto.view,dto.websiteUrl);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: UserViewModel) : Api.UserClientRequestModel
	{
		let response = new Api.UserClientRequestModel();
		response.setProperties(model.aboutMe,model.accountId,model.age,model.creationDate,model.displayName,model.downVote,model.emailHash,model.id,model.lastAccessDate,model.location,model.reputation,model.upVote,model.view,model.websiteUrl);
		return response;
	}
};

/*<Codenesium>
    <Hash>569c0386369caafee1bdd0c4de2e993c</Hash>
</Codenesium>*/