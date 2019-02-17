import * as Api from '../../api/models';
import PurchaseOrderHeaderViewModel from  './purchaseOrderHeaderViewModel';
export default class PurchaseOrderHeaderMapper {
    
	mapApiResponseToViewModel(dto: Api.PurchaseOrderHeaderClientResponseModel) : PurchaseOrderHeaderViewModel 
	{
		let response = new PurchaseOrderHeaderViewModel();
		response.setProperties(dto.employeeID,dto.freight,dto.modifiedDate,dto.orderDate,dto.purchaseOrderID,dto.revisionNumber,dto.shipDate,dto.shipMethodID,dto.status,dto.subTotal,dto.taxAmt,dto.totalDue,dto.vendorID);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PurchaseOrderHeaderViewModel) : Api.PurchaseOrderHeaderClientRequestModel
	{
		let response = new Api.PurchaseOrderHeaderClientRequestModel();
		response.setProperties(model.employeeID,model.freight,model.modifiedDate,model.orderDate,model.purchaseOrderID,model.revisionNumber,model.shipDate,model.shipMethodID,model.status,model.subTotal,model.taxAmt,model.totalDue,model.vendorID);
		return response;
	}
};

/*<Codenesium>
    <Hash>a69cdbb8d9aab26b3027dcdc406bfb3e</Hash>
</Codenesium>*/