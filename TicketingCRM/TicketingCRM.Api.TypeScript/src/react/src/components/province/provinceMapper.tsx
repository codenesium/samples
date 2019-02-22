import * as Api from '../../api/models';
import ProvinceViewModel from  './provinceViewModel';
	import CountryViewModel from '../country/countryViewModel'
	export default class ProvinceMapper {
    
	mapApiResponseToViewModel(dto: Api.ProvinceClientResponseModel) : ProvinceViewModel 
	{
		let response = new ProvinceViewModel();
		response.setProperties(dto.countryId,dto.id,dto.name);
		
						if(dto.countryIdNavigation != null)
				{
				  response.countryIdNavigation = new CountryViewModel();
				  response.countryIdNavigation.setProperties(
				  dto.countryIdNavigation.id,dto.countryIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: ProvinceViewModel) : Api.ProvinceClientRequestModel
	{
		let response = new Api.ProvinceClientRequestModel();
		response.setProperties(model.countryId,model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>cbbcf64e1da95462be7ba12e81dc1d49</Hash>
</Codenesium>*/