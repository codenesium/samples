import * as Api from '../../api/models';
import SpeciesViewModel from  './speciesViewModel';
export default class SpeciesMapper {
    
	mapApiResponseToViewModel(dto: Api.SpeciesClientResponseModel) : SpeciesViewModel 
	{
		let response = new SpeciesViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: SpeciesViewModel) : Api.SpeciesClientRequestModel
	{
		let response = new Api.SpeciesClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>a17c7fd2ec2a0091f068790b1032a1c8</Hash>
</Codenesium>*/