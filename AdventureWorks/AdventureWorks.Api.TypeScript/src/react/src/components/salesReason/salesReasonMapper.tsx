import * as Api from '../../api/models';
import SalesReasonViewModel from './salesReasonViewModel';
export default class SalesReasonMapper {
  mapApiResponseToViewModel(
    dto: Api.SalesReasonClientResponseModel
  ): SalesReasonViewModel {
    let response = new SalesReasonViewModel();
    response.setProperties(
      dto.modifiedDate,
      dto.name,
      dto.reasonType,
      dto.salesReasonID
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: SalesReasonViewModel
  ): Api.SalesReasonClientRequestModel {
    let response = new Api.SalesReasonClientRequestModel();
    response.setProperties(
      model.modifiedDate,
      model.name,
      model.reasonType,
      model.salesReasonID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>e83ddca2147a7cd00f32fd3d6b9dcb8c</Hash>
</Codenesium>*/