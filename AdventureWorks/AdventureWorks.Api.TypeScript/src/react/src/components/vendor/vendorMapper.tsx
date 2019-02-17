import * as Api from '../../api/models';
import VendorViewModel from  './vendorViewModel';
export default class VendorMapper {
    
	mapApiResponseToViewModel(dto: Api.VendorClientResponseModel) : VendorViewModel 
	{
		let response = new VendorViewModel();
		response.setProperties(dto.accountNumber,dto.activeFlag,dto.businessEntityID,dto.creditRating,dto.modifiedDate,dto.name,dto.preferredVendorStatu,dto.purchasingWebServiceURL);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: VendorViewModel) : Api.VendorClientRequestModel
	{
		let response = new Api.VendorClientRequestModel();
		response.setProperties(model.accountNumber,model.activeFlag,model.businessEntityID,model.creditRating,model.modifiedDate,model.name,model.preferredVendorStatu,model.purchasingWebServiceURL);
		return response;
	}
};

/*<Codenesium>
    <Hash>3fec1274b8b1ffa04b7013bcc68bc38f</Hash>
</Codenesium>*/