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
      dto.reservedEvent,
      dto.reservedObject,
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
      model.reservedEvent,
      model.reservedObject,
      model.postTime,
      model.schema,
      model.tsql,
      model.xmlEvent
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>211539d648148132a84b8addbe440a3d</Hash>
</Codenesium>*/