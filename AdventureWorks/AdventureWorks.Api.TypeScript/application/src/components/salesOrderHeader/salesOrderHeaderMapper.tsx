import * as Api from '../../api/models';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';

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
    <Hash>3c82a0055d2c7fce68e57ebe827c4798</Hash>
</Codenesium>*/