import * as Api from '../../api/models';
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';
import ShipMethodViewModel from '../shipMethod/shipMethodViewModel';
import VendorViewModel from '../vendor/vendorViewModel';
export default class PurchaseOrderHeaderMapper {
  mapApiResponseToViewModel(
    dto: Api.PurchaseOrderHeaderClientResponseModel
  ): PurchaseOrderHeaderViewModel {
    let response = new PurchaseOrderHeaderViewModel();
    response.setProperties(
      dto.employeeID,
      dto.freight,
      dto.modifiedDate,
      dto.orderDate,
      dto.purchaseOrderID,
      dto.revisionNumber,
      dto.shipDate,
      dto.shipMethodID,
      dto.status,
      dto.subTotal,
      dto.taxAmt,
      dto.totalDue,
      dto.vendorID
    );

    if (dto.shipMethodIDNavigation != null) {
      response.shipMethodIDNavigation = new ShipMethodViewModel();
      response.shipMethodIDNavigation.setProperties(
        dto.shipMethodIDNavigation.modifiedDate,
        dto.shipMethodIDNavigation.name,
        dto.shipMethodIDNavigation.rowguid,
        dto.shipMethodIDNavigation.shipBase,
        dto.shipMethodIDNavigation.shipMethodID,
        dto.shipMethodIDNavigation.shipRate
      );
    }
    if (dto.vendorIDNavigation != null) {
      response.vendorIDNavigation = new VendorViewModel();
      response.vendorIDNavigation.setProperties(
        dto.vendorIDNavigation.accountNumber,
        dto.vendorIDNavigation.activeFlag,
        dto.vendorIDNavigation.businessEntityID,
        dto.vendorIDNavigation.creditRating,
        dto.vendorIDNavigation.modifiedDate,
        dto.vendorIDNavigation.name,
        dto.vendorIDNavigation.preferredVendorStatu,
        dto.vendorIDNavigation.purchasingWebServiceURL
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: PurchaseOrderHeaderViewModel
  ): Api.PurchaseOrderHeaderClientRequestModel {
    let response = new Api.PurchaseOrderHeaderClientRequestModel();
    response.setProperties(
      model.employeeID,
      model.freight,
      model.modifiedDate,
      model.orderDate,
      model.purchaseOrderID,
      model.revisionNumber,
      model.shipDate,
      model.shipMethodID,
      model.status,
      model.subTotal,
      model.taxAmt,
      model.totalDue,
      model.vendorID
    );
    return response;
  }
}


/*<Codenesium>
    <Hash>118d933462609e69c1e2050d4e23a842</Hash>
</Codenesium>*/