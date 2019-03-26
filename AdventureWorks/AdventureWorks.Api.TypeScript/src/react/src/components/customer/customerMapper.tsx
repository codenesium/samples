import * as Api from '../../api/models';
import CustomerViewModel from './customerViewModel';
import StoreViewModel from '../store/storeViewModel';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';
export default class CustomerMapper {
  mapApiResponseToViewModel(
    dto: Api.CustomerClientResponseModel
  ): CustomerViewModel {
    let response = new CustomerViewModel();
    response.setProperties(
      dto.accountNumber,
      dto.customerID,
      dto.modifiedDate,
      dto.personID,
      dto.rowguid,
      dto.storeID,
      dto.territoryID
    );

    if (dto.storeIDNavigation != null) {
      response.storeIDNavigation = new StoreViewModel();
      response.storeIDNavigation.setProperties(
        dto.storeIDNavigation.businessEntityID,
        dto.storeIDNavigation.demographic,
        dto.storeIDNavigation.modifiedDate,
        dto.storeIDNavigation.name,
        dto.storeIDNavigation.rowguid,
        dto.storeIDNavigation.salesPersonID
      );
    }
    if (dto.territoryIDNavigation != null) {
      response.territoryIDNavigation = new SalesTerritoryViewModel();
      response.territoryIDNavigation.setProperties(
        dto.territoryIDNavigation.costLastYear,
        dto.territoryIDNavigation.costYTD,
        dto.territoryIDNavigation.countryRegionCode,
        dto.territoryIDNavigation.reservedGroup,
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
    model: CustomerViewModel
  ): Api.CustomerClientRequestModel {
    let response = new Api.CustomerClientRequestModel();
    response.setProperties(
      model.accountNumber,
      model.customerID,
      model.modifiedDate,
      model.personID,
      model.rowguid,
      model.storeID,
      model.territoryID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>51e3ab0852ca5f09fbfa5d2654acb96d</Hash>
</Codenesium>*/