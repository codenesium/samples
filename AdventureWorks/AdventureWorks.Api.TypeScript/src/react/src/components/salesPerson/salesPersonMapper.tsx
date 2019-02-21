import * as Api from '../../api/models';
import SalesPersonViewModel from './salesPersonViewModel';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';
export default class SalesPersonMapper {
  mapApiResponseToViewModel(
    dto: Api.SalesPersonClientResponseModel
  ): SalesPersonViewModel {
    let response = new SalesPersonViewModel();
    response.setProperties(
      dto.bonus,
      dto.businessEntityID,
      dto.commissionPct,
      dto.modifiedDate,
      dto.rowguid,
      dto.salesLastYear,
      dto.salesQuota,
      dto.salesYTD,
      dto.territoryID
    );

    if (dto.territoryIDNavigation != null) {
      response.territoryIDNavigation = new SalesTerritoryViewModel();
      response.territoryIDNavigation.setProperties(
        dto.territoryIDNavigation.costLastYear,
        dto.territoryIDNavigation.costYTD,
        dto.territoryIDNavigation.countryRegionCode,
        dto.territoryIDNavigation.modifiedDate,
        dto.territoryIDNavigation.name,
        dto.territoryIDNavigation.rowguid,
        dto.territoryIDNavigation.salesLastYear,
        dto.territoryIDNavigation.salesYTD,
        dto.territoryIDNavigation.territoryID
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: SalesPersonViewModel
  ): Api.SalesPersonClientRequestModel {
    let response = new Api.SalesPersonClientRequestModel();
    response.setProperties(
      model.bonus,
      model.businessEntityID,
      model.commissionPct,
      model.modifiedDate,
      model.rowguid,
      model.salesLastYear,
      model.salesQuota,
      model.salesYTD,
      model.territoryID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>d8c3aaec12cce433e415e2cfda864d37</Hash>
</Codenesium>*/