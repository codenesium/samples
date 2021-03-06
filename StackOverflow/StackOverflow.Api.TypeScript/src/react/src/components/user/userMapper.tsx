import * as Api from '../../api/models';
import UserViewModel from './userViewModel';
export default class UserMapper {
  mapApiResponseToViewModel(dto: Api.UserClientResponseModel): UserViewModel {
    let response = new UserViewModel();
    response.setProperties(
      dto.aboutMe,
      dto.accountId,
      dto.age,
      dto.creationDate,
      dto.displayName,
      dto.downVote,
      dto.emailHash,
      dto.id,
      dto.lastAccessDate,
      dto.location,
      dto.reputation,
      dto.upVote,
      dto.view,
      dto.websiteUrl
    );

    return response;
  }

  mapViewModelToApiRequest(model: UserViewModel): Api.UserClientRequestModel {
    let response = new Api.UserClientRequestModel();
    response.setProperties(
      model.aboutMe,
      model.accountId,
      model.age,
      model.creationDate,
      model.displayName,
      model.downVote,
      model.emailHash,
      model.id,
      model.lastAccessDate,
      model.location,
      model.reputation,
      model.upVote,
      model.view,
      model.websiteUrl
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>381456e33bb3d8e7ca63cd296cdc4efa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/