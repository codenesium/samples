import * as Api from '../../api/models';
import ShipMethodViewModel from './shipMethodViewModel';
export default class ShipMethodMapper {
  mapApiResponseToViewModel(
    dto: Api.ShipMethodClientResponseModel
  ): ShipMethodViewModel {
    let response = new ShipMethodViewModel();
    response.setProperties(
      dto.modifiedDate,
      dto.name,
      dto.rowguid,
      dto.shipBase,
      dto.shipMethodID,
      dto.shipRate
    );

    return response;
  }

  mapViewModelToApiRequest(
    model: ShipMethodViewModel
  ): Api.ShipMethodClientRequestModel {
    let response = new Api.ShipMethodClientRequestModel();
    response.setProperties(
      model.modifiedDate,
      model.name,
      model.rowguid,
      model.shipBase,
      model.shipMethodID,
      model.shipRate
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>24059e605f11f90d5fd8c3849b5f7531</Hash>
</Codenesium>*/