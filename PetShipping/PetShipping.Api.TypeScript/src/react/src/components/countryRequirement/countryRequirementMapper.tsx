import * as Api from '../../api/models';
import CountryRequirementViewModel from  './countryRequirementViewModel';
	import CountryViewModel from '../country/countryViewModel'
	export default class CountryRequirementMapper {
    
	mapApiResponseToViewModel(dto: Api.CountryRequirementClientResponseModel) : CountryRequirementViewModel 
	{
		let response = new CountryRequirementViewModel();
		response.setProperties(dto.countryId,dto.detail,dto.id);
		
						if(dto.countryIdNavigation != null)
				{
				  response.countryIdNavigation = new CountryViewModel();
				  response.countryIdNavigation.setProperties(
				  dto.countryIdNavigation.id,dto.countryIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CountryRequirementViewModel) : Api.CountryRequirementClientRequestModel
	{
		let response = new Api.CountryRequirementClientRequestModel();
		response.setProperties(model.countryId,model.detail,model.id);
		return response;
	}
};

/*<Codenesium>
    <Hash>7c6abf0a6176b196a824041a19140531</Hash>
</Codenesium>*/