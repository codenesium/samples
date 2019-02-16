import * as Api from '../../api/models';
import DatabaseLogViewModel from './databaseLogViewModel';

export default class DatabaseLogMapper {
  mapApiResponseToViewModel(
    dto: Api.DatabaseLogClientResponseModel
  ): DatabaseLogViewModel {
    let response = new DatabaseLogViewModel();
    response.setProperties(
      dto.databaseLogID,
      dto.databaseUser,
      dto.postTime,
      dto.schema,
      dto.tsql,
      dto.xmlEvent
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: DatabaseLogViewModel
  ): Api.DatabaseLogClientRequestModel {
    let response = new Api.DatabaseLogClientRequestModel();
    response.setProperties(
      model.databaseLogID,
      model.databaseUser,
      model.postTime,
      model.schema,
      model.tsql,
      model.xmlEvent
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>33fcb2889a9c378bbb0891d2d2e45cfb</Hash>
</Codenesium>*/