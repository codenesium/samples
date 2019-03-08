import * as Api from '../../api/models';
import AirlineViewModel from './airlineViewModel';
export default class AirlineMapper {
  mapApiResponseToViewModel(
    dto: Api.AirlineClientResponseModel
  ): AirlineViewModel {
    let response = new AirlineViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: AirlineViewModel
  ): Api.AirlineClientRequestModel {
    let response = new Api.AirlineClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>db8a229c1cf8d514c63639b379ae43e1</Hash>
</Codenesium>*/