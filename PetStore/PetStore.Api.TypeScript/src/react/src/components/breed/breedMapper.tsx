import * as Api from '../../api/models';
import BreedViewModel from  './breedViewModel';
	import SpeciesViewModel from '../species/speciesViewModel'
	export default class BreedMapper {
    
	mapApiResponseToViewModel(dto: Api.BreedClientResponseModel) : BreedViewModel 
	{
		let response = new BreedViewModel();
		response.setProperties(dto.id,dto.name,dto.speciesId);
		
						if(dto.speciesIdNavigation != null)
				{
				  response.speciesIdNavigation = new SpeciesViewModel();
				  response.speciesIdNavigation.setProperties(
				  dto.speciesIdNavigation.id,dto.speciesIdNavigation.name
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: BreedViewModel) : Api.BreedClientRequestModel
	{
		let response = new Api.BreedClientRequestModel();
		response.setProperties(model.id,model.name,model.speciesId);
		return response;
	}
};

/*<Codenesium>
    <Hash>a044b66e0a760f9ef720b3e9b47bb599</Hash>
</Codenesium>*/