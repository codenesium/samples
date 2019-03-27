import * as Api from '../../api/models';
import VersionInfoViewModel from './versionInfoViewModel';
export default class VersionInfoMapper {
  mapApiResponseToViewModel(
    dto: Api.VersionInfoClientResponseModel
  ): VersionInfoViewModel {
    let response = new VersionInfoViewModel();
    response.setProperties(dto.appliedOn, dto.description, dto.version);

    return response;
  }

  mapViewModelToApiRequest(
    model: VersionInfoViewModel
  ): Api.VersionInfoClientRequestModel {
    let response = new Api.VersionInfoClientRequestModel();
    response.setProperties(model.appliedOn, model.description, model.version);
    return response;
  }
}


/*<Codenesium>
    <Hash>2f29daea77a2ce4e74f8bdbc46d380cb</Hash>
</Codenesium>*/