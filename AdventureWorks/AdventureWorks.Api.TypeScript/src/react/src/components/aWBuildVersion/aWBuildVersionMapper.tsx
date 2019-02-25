import * as Api from '../../api/models';
import AWBuildVersionViewModel from './aWBuildVersionViewModel';
export default class AWBuildVersionMapper {
  mapApiResponseToViewModel(
    dto: Api.AWBuildVersionClientResponseModel
  ): AWBuildVersionViewModel {
    let response = new AWBuildVersionViewModel();
    response.setProperties(
      dto.database_Version,
      dto.modifiedDate,
      dto.systemInformationID,
      dto.versionDate
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: AWBuildVersionViewModel
  ): Api.AWBuildVersionClientRequestModel {
    let response = new Api.AWBuildVersionClientRequestModel();
    response.setProperties(
      model.database_Version,
      model.modifiedDate,
      model.systemInformationID,
      model.versionDate
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>b75d9ca9a1fb7d7ec4a3c941bf14d472</Hash>
</Codenesium>*/