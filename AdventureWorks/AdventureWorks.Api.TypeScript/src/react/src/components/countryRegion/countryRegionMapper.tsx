import * as Api from '../../api/models';
import CountryRegionViewModel from  './countryRegionViewModel';
export default class CountryRegionMapper {
    
	mapApiResponseToViewModel(dto: Api.CountryRegionClientResponseModel) : CountryRegionViewModel 
	{
		let response = new CountryRegionViewModel();
		response.setProperties(dto.countryRegionCode,dto.modifiedDate,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CountryRegionViewModel) : Api.CountryRegionClientRequestModel
	{
		let response = new Api.CountryRegionClientRequestModel();
		response.setProperties(model.countryRegionCode,model.modifiedDate,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>6d4413f27eb5e2c37072648c0db1f3d2</Hash>
</Codenesium>*/