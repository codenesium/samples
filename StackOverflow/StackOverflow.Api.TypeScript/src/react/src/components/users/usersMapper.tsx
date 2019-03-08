import * as Api from '../../api/models';
import UsersViewModel from './usersViewModel';
export default class UsersMapper {
  mapApiResponseToViewModel(dto: Api.UsersClientResponseModel): UsersViewModel {
    let response = new UsersViewModel();
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

  mapViewModelToApiRequest(model: UsersViewModel): Api.UsersClientRequestModel {
    let response = new Api.UsersClientRequestModel();
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
    <Hash>a21e04a918f99221039ade2a16a2c4ed</Hash>
</Codenesium>*/