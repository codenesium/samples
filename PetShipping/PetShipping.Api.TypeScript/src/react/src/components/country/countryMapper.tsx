import * as Api from '../../api/models';
import CountryViewModel from  './countryViewModel';
export default class CountryMapper {
    
	mapApiResponseToViewModel(dto: Api.CountryClientResponseModel) : CountryViewModel 
	{
		let response = new CountryViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: CountryViewModel) : Api.CountryClientRequestModel
	{
		let response = new Api.CountryClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>5a20d6ff611da54b5faf6956baf3faa7</Hash>
</Codenesium>*/