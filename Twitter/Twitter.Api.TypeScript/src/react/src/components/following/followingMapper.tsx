import * as Api from '../../api/models';
import FollowingViewModel from  './followingViewModel';
export default class FollowingMapper {
    
	mapApiResponseToViewModel(dto: Api.FollowingClientResponseModel) : FollowingViewModel 
	{
		let response = new FollowingViewModel();
		response.setProperties(dto.dateFollowed,dto.muted,dto.userId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: FollowingViewModel) : Api.FollowingClientRequestModel
	{
		let response = new Api.FollowingClientRequestModel();
		response.setProperties(model.dateFollowed,model.muted,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>63ec802dd70750cba5dbe7d6b2f306d7</Hash>
</Codenesium>*/