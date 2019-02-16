import * as Api from '../../api/models';
import IncludedColumnTestViewModel from './includedColumnTestViewModel';
export default class IncludedColumnTestMapper {
  mapApiResponseToViewModel(
    dto: Api.IncludedColumnTestClientResponseModel
  ): IncludedColumnTestViewModel {
    let response = new IncludedColumnTestViewModel();
    response.setProperties(dto.id, dto.name, dto.name2);

    return response;
  }

  mapViewModelToApiRequest(
    model: IncludedColumnTestViewModel
  ): Api.IncludedColumnTestClientRequestModel {
    let response = new Api.IncludedColumnTestClientRequestModel();
    response.setProperties(model.id, model.name, model.name2);
    return response;
  }
}


/*<Codenesium>
    <Hash>b18d96f2d429ad3f0240aeefaa8a3a1c</Hash>
</Codenesium>*/