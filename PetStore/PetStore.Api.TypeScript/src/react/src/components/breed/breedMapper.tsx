import * as Api from '../../api/models';
import BreedViewModel from  './breedViewModel';
	import SpeciesViewModel from '../species/speciesViewModel'
	export default class BreedMapper {
    
	mapApiResponseToViewModel(dto: Api.BreedClientResponseModel) : BreedViewModel 
	{
		let response = new BreedViewModel();
		response.setProperties(dto.name,dto.speciesId);
		
						if(dto.speciesIdNavigation != null)
				{
				  response.speciesIdNavigation = new SpeciesViewModel();
				  response.speciesIdNavigation.setProperties(
				  dto.speciesIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: BreedViewModel) : Api.BreedClientRequestModel
	{
		let response = new Api.BreedClientRequestModel();
		response.setProperties(model.name,model.speciesId);
		return response;
	}
};

/*<Codenesium>
    <Hash>d6f7cfaa0c687f0264546635b5214e2a</Hash>
</Codenesium>*/