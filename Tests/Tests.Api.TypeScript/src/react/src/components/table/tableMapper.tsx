import * as Api from '../../api/models';
import TableViewModel from './tableViewModel';
export default class TableMapper {
  mapApiResponseToViewModel(dto: Api.TableClientResponseModel): TableViewModel {
    let response = new TableViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(model: TableViewModel): Api.TableClientRequestModel {
    let response = new Api.TableClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>cba499b0a0e71d38864d306cd103e840</Hash>
</Codenesium>*/