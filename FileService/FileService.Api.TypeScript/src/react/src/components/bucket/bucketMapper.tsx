import * as Api from '../../api/models';
import BucketViewModel from './bucketViewModel';
export default class BucketMapper {
  mapApiResponseToViewModel(
    dto: Api.BucketClientResponseModel
  ): BucketViewModel {
    let response = new BucketViewModel();
    response.setProperties(dto.externalId, dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: BucketViewModel
  ): Api.BucketClientRequestModel {
    let response = new Api.BucketClientRequestModel();
    response.setProperties(model.externalId, model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>6842363ab3e0d372e0efb50af224a1e9</Hash>
</Codenesium>*/