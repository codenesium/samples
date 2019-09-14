import * as Api from '../../api/models';
import TimestampCheckViewModel from './timestampCheckViewModel';
export default class TimestampCheckMapper {
  mapApiResponseToViewModel(
    dto: Api.TimestampCheckClientResponseModel
  ): TimestampCheckViewModel {
    let response = new TimestampCheckViewModel();
    response.setProperties(dto.id, dto.name, dto.timestamp);

    return response;
  }

  mapViewModelToApiRequest(
    model: TimestampCheckViewModel
  ): Api.TimestampCheckClientRequestModel {
    let response = new Api.TimestampCheckClientRequestModel();
    response.setProperties(model.id, model.name, model.timestamp);
    return response;
  }
}


/*<Codenesium>
    <Hash>770d4eda3f2fbfffeea2f784d1d9973e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/