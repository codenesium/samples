import * as Api from '../../api/models';
import StoreViewModel from './storeViewModel';

export default class StoreMapper {
  mapApiResponseToViewModel(dto: Api.StoreClientResponseModel): StoreViewModel {
    let response = new StoreViewModel();
    response.setProperties(
      dto.businessEntityID,
      dto.demographic,
      dto.modifiedDate,
      dto.name,
      dto.rowguid,
      dto.salesPersonID
    );
    return response;
  }

  mapViewModelToApiRequest(model: StoreViewModel): Api.StoreClientRequestModel {
    let response = new Api.StoreClientRequestModel();
    response.setProperties(
      model.businessEntityID,
      model.demographic,
      model.modifiedDate,
      model.name,
      model.rowguid,
      model.salesPersonID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>ef3dec104976bd9107f66091594329ed</Hash>
</Codenesium>*/