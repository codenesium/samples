import * as Api from '../../api/models';
import PetViewModel from  './petViewModel';
	import BreedViewModel from '../breed/breedViewModel'
	export default class PetMapper {
    
	mapApiResponseToViewModel(dto: Api.PetClientResponseModel) : PetViewModel 
	{
		let response = new PetViewModel();
		response.setProperties(dto.breedId,dto.clientId,dto.id,dto.name,dto.weight);
		
						if(dto.breedIdNavigation != null)
				{
				  response.breedIdNavigation = new BreedViewModel();
				  response.breedIdNavigation.setProperties(
				  dto.breedIdNavigation.id,dto.breedIdNavigation.name,dto.breedIdNavigation.speciesId
				  );
				}
					

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PetViewModel) : Api.PetClientRequestModel
	{
		let response = new Api.PetClientRequestModel();
		response.setProperties(model.breedId,model.clientId,model.id,model.name,model.weight);
		return response;
	}
};

/*<Codenesium>
    <Hash>9314657e6de80a9e3f3994c845c838d2</Hash>
</Codenesium>*/