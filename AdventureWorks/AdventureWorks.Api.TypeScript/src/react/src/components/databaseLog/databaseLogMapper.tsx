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
    <Hash>ef8e7b54e9743520ac2668a48da86afb</Hash>
</Codenesium>*/