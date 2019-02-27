import * as Api from '../../api/models';
import RetweetViewModel from  './retweetViewModel';
	import UserViewModel from '../user/userViewModel'
		import TweetViewModel from '../tweet/tweetViewModel'
	export default class RetweetMapper {
    
	mapApiResponseToViewModel(dto: Api.RetweetClientResponseModel) : RetweetViewModel 
	{
		let response = new RetweetViewModel();
		response.setProperties(dto.date,dto.id,dto.retwitterUserId,dto.time,dto.tweetTweetId);
		
						if(dto.retwitterUserIdNavigation != null)
				{
				  response.retwitterUserIdNavigation = new UserViewModel();
				  response.retwitterUserIdNavigation.setProperties(
				  dto.retwitterUserIdNavigation.bioImgUrl,dto.retwitterUserIdNavigation.birthday,dto.retwitterUserIdNavigation.contentDescription,dto.retwitterUserIdNavigation.email,dto.retwitterUserIdNavigation.fullName,dto.retwitterUserIdNavigation.headerImgUrl,dto.retwitterUserIdNavigation.interest,dto.retwitterUserIdNavigation.locationLocationId,dto.retwitterUserIdNavigation.password,dto.retwitterUserIdNavigation.phoneNumber,dto.retwitterUserIdNavigation.privacy,dto.retwitterUserIdNavigation.userId,dto.retwitterUserIdNavigation.username,dto.retwitterUserIdNavigation.website
				  );
				}
							if(dto.tweetTweetIdNavigation != null)
				{
				  response.tweetTweetIdNavigation = new TweetViewModel();
				  response.tweetTweetIdNavigation.setProperties(
				  dto.tweetTweetIdNavigation.content,dto.tweetTweetIdNavigation.date,dto.tweetTweetIdNavigation.locationId,dto.tweetTweetIdNavigation.time,dto.tweetTweetIdNavigation.tweetId,dto.tweetTweetIdNavigation.userUserId
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: RetweetViewModel) : Api.RetweetClientRequestModel
	{
		let response = new Api.RetweetClientRequestModel();
		response.setProperties(model.date,model.id,model.retwitterUserId,model.time,model.tweetTweetId);
		return response;
	}
};

/*<Codenesium>
    <Hash>aecca824b22e527b45b0d973091aab05</Hash>
</Codenesium>*/