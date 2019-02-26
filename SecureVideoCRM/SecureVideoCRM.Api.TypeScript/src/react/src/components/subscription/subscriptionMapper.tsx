import * as Api from '../../api/models';
import SubscriptionViewModel from './subscriptionViewModel';
export default class SubscriptionMapper {
  mapApiResponseToViewModel(
    dto: Api.SubscriptionClientResponseModel
  ): SubscriptionViewModel {
    let response = new SubscriptionViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: SubscriptionViewModel
  ): Api.SubscriptionClientRequestModel {
    let response = new Api.SubscriptionClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>f9a80446a05add2d7e629d10d6e30eb7</Hash>
</Codenesium>*/