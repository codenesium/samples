import * as Api from '../../api/models';
import UserViewModel from './userViewModel';
export default class UserMapper {
  mapApiResponseToViewModel(dto: Api.UserClientResponseModel): UserViewModel {
    let response = new UserViewModel();
    response.setProperties(
      dto.email,
      dto.id,
      dto.password,
      dto.stripeCustomerId,
      dto.subscriptionTypeId
    );

    return response;
  }

  mapViewModelToApiRequest(model: UserViewModel): Api.UserClientRequestModel {
    let response = new Api.UserClientRequestModel();
    response.setProperties(
      model.email,
      model.id,
      model.password,
      model.stripeCustomerId,
      model.subscriptionTypeId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>0ade3951cb08d7ec6ebcfc5ecf997a16</Hash>
</Codenesium>*/