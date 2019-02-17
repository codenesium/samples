import * as Api from '../../api/models';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
import CreditCardViewModel from '../creditCard/creditCardViewModel';
import CurrencyRateViewModel from '../currencyRate/currencyRateViewModel';
import CustomerViewModel from '../customer/customerViewModel';
import SalesPersonViewModel from '../salesPerson/salesPersonViewModel';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';
export default class SalesOrderHeaderMapper {
  mapApiResponseToViewModel(
    dto: Api.SalesOrderHeaderClientResponseModel
  ): SalesOrderHeaderViewModel {
    let response = new SalesOrderHeaderViewModel();
    response.setProperties(
      dto.accountNumber,
      dto.billToAddressID,
      dto.comment,
      dto.creditCardApprovalCode,
      dto.creditCardID,
      dto.currencyRateID,
      dto.customerID,
      dto.dueDate,
      dto.freight,
      dto.modifiedDate,
      dto.onlineOrderFlag,
      dto.orderDate,
      dto.purchaseOrderNumber,
      dto.revisionNumber,
      dto.rowguid,
      dto.salesOrderID,
      dto.salesOrderNumber,
      dto.salesPersonID,
      dto.shipDate,
      dto.shipMethodID,
      dto.shipToAddressID,
      dto.status,
      dto.subTotal,
      dto.taxAmt,
      dto.territoryID,
      dto.totalDue
    );

    if (dto.creditCardIDNavigation != null) {
      response.creditCardIDNavigation = new CreditCardViewModel();
      response.creditCardIDNavigation.setProperties(
        dto.creditCardIDNavigation.cardNumber,
        dto.creditCardIDNavigation.cardType,
        dto.creditCardIDNavigation.creditCardID,
        dto.creditCardIDNavigation.expMonth,
        dto.creditCardIDNavigation.expYear,
        dto.creditCardIDNavigation.modifiedDate
      );
    }
    if (dto.currencyRateIDNavigation != null) {
      response.currencyRateIDNavigation = new CurrencyRateViewModel();
      response.currencyRateIDNavigation.setProperties(
        dto.currencyRateIDNavigation.averageRate,
        dto.currencyRateIDNavigation.currencyRateDate,
        dto.currencyRateIDNavigation.currencyRateID,
        dto.currencyRateIDNavigation.endOfDayRate,
        dto.currencyRateIDNavigation.fromCurrencyCode,
        dto.currencyRateIDNavigation.modifiedDate,
        dto.currencyRateIDNavigation.toCurrencyCode
      );
    }
    if (dto.customerIDNavigation != null) {
      response.customerIDNavigation = new CustomerViewModel();
      response.customerIDNavigation.setProperties(
        dto.customerIDNavigation.accountNumber,
        dto.customerIDNavigation.customerID,
        dto.customerIDNavigation.modifiedDate,
        dto.customerIDNavigation.personID,
        dto.customerIDNavigation.rowguid,
        dto.customerIDNavigation.storeID,
        dto.customerIDNavigation.territoryID
      );
    }
    if (dto.salesPersonIDNavigation != null) {
      response.salesPersonIDNavigation = new SalesPersonViewModel();
      response.salesPersonIDNavigation.setProperties(
        dto.salesPersonIDNavigation.bonus,
        dto.salesPersonIDNavigation.businessEntityID,
        dto.salesPersonIDNavigation.commissionPct,
        dto.salesPersonIDNavigation.modifiedDate,
        dto.salesPersonIDNavigation.rowguid,
        dto.salesPersonIDNavigation.salesLastYear,
        dto.salesPersonIDNavigation.salesQuota,
        dto.salesPersonIDNavigation.salesYTD,
        dto.salesPersonIDNavigation.territoryID
      );
    }
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
    model: SalesOrderHeaderViewModel
  ): Api.SalesOrderHeaderClientRequestModel {
    let response = new Api.SalesOrderHeaderClientRequestModel();
    response.setProperties(
      model.accountNumber,
      model.billToAddressID,
      model.comment,
      model.creditCardApprovalCode,
      model.creditCardID,
      model.currencyRateID,
      model.customerID,
      model.dueDate,
      model.freight,
      model.modifiedDate,
      model.onlineOrderFlag,
      model.orderDate,
      model.purchaseOrderNumber,
      model.revisionNumber,
      model.rowguid,
      model.salesOrderID,
      model.salesOrderNumber,
      model.salesPersonID,
      model.shipDate,
      model.shipMethodID,
      model.shipToAddressID,
      model.status,
      model.subTotal,
      model.taxAmt,
      model.territoryID,
      model.totalDue
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>c7103ea370b5528f0a7cab4be159e69f</Hash>
</Codenesium>*/