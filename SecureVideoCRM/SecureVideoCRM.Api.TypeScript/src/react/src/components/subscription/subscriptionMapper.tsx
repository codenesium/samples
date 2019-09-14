import * as Api from '../../api/models';
import SubscriptionViewModel from './subscriptionViewModel';
export default class SubscriptionMapper {
  mapApiResponseToViewModel(
    dto: Api.SubscriptionClientResponseModel
  ): SubscriptionViewModel {
    let response = new SubscriptionViewModel();
    response.setProperties(dto.id, dto.name, dto.stripePlanName);

    return response;
  }

  mapViewModelToApiRequest(
    model: SubscriptionViewModel
  ): Api.SubscriptionClientRequestModel {
    let response = new Api.SubscriptionClientRequestModel();
    response.setProperties(model.id, model.name, model.stripePlanName);
    return response;
  }
}


/*<Codenesium>
    <Hash>3cf9c404571552dc6e14f831efbc32e1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/