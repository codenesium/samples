import * as Api from '../../api/models';
import PersonViewModel from  './personViewModel';
export default class PersonMapper {
    
	mapApiResponseToViewModel(dto: Api.PersonClientResponseModel) : PersonViewModel 
	{
		let response = new PersonViewModel();
		response.setProperties(dto.firstName,dto.id,dto.lastName,dto.phone,dto.ssn);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PersonViewModel) : Api.PersonClientRequestModel
	{
		let response = new Api.PersonClientRequestModel();
		response.setProperties(model.firstName,model.id,model.lastName,model.phone,model.ssn);
		return response;
	}
};

/*<Codenesium>
    <Hash>3435b8e6a0ab6c6b5813fede81188747</Hash>
</Codenesium>*/