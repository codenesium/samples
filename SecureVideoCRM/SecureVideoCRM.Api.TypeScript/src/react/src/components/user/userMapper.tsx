import * as Api from '../../api/models';
import UserViewModel from './userViewModel';
import SubscriptionViewModel from '../subscription/subscriptionViewModel';
export default class UserMapper {
  mapApiResponseToViewModel(dto: Api.UserClientResponseModel): UserViewModel {
    let response = new UserViewModel();
    response.setProperties(dto.email, dto.id, dto.password, dto.subscriptionId);

    if (dto.subscriptionIdNavigation != null) {
      response.subscriptionIdNavigation = new SubscriptionViewModel();
      response.subscriptionIdNavigation.setProperties(
        dto.subscriptionIdNavigation.id,
        dto.subscriptionIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(model: UserViewModel): Api.UserClientRequestModel {
    let response = new Api.UserClientRequestModel();
    response.setProperties(
      model.email,
      model.id,
      model.password,
      model.subscriptionId
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>17ff59a459fd3f37586aa035142effa2</Hash>
</Codenesium>*/