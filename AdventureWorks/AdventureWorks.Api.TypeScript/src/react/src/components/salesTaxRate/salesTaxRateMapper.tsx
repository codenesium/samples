import * as Api from '../../api/models';
import SalesTaxRateViewModel from  './salesTaxRateViewModel';
export default class SalesTaxRateMapper {
    
	mapApiResponseToViewModel(dto: Api.SalesTaxRateClientResponseModel) : SalesTaxRateViewModel 
	{
		let response = new SalesTaxRateViewModel();
		response.setProperties(dto.modifiedDate,dto.name,dto.rowguid,dto.salesTaxRateID,dto.stateProvinceID,dto.taxRate,dto.taxType);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: SalesTaxRateViewModel) : Api.SalesTaxRateClientRequestModel
	{
		let response = new Api.SalesTaxRateClientRequestModel();
		response.setProperties(model.modifiedDate,model.name,model.rowguid,model.salesTaxRateID,model.stateProvinceID,model.taxRate,model.taxType);
		return response;
	}
};

/*<Codenesium>
    <Hash>402026455981cda7deb41bc638d105f3</Hash>
</Codenesium>*/