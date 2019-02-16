import * as Api from '../../api/models';
import SalesTerritoryViewModel from './salesTerritoryViewModel';

export default class SalesTerritoryMapper {
  mapApiResponseToViewModel(
    dto: Api.SalesTerritoryClientResponseModel
  ): SalesTerritoryViewModel {
    let response = new SalesTerritoryViewModel();
    response.setProperties(
      dto.costLastYear,
      dto.costYTD,
      dto.countryRegionCode,
      dto.modifiedDate,
      dto.name,
      dto.rowguid,
      dto.salesLastYear,
      dto.salesYTD,
      dto.territoryID
    );
    return response;
  }

  mapViewModelToApiRequest(
    model: SalesTerritoryViewModel
  ): Api.SalesTerritoryClientRequestModel {
    let response = new Api.SalesTerritoryClientRequestModel();
    response.setProperties(
      model.costLastYear,
      model.costYTD,
      model.countryRegionCode,
      model.modifiedDate,
      model.name,
      model.rowguid,
      model.salesLastYear,
      model.salesYTD,
      model.territoryID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>7c8fd7a1274025b2eba735f5d0bf9081</Hash>
</Codenesium>*/