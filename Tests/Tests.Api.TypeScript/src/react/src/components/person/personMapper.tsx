import * as Api from '../../api/models';
import PersonViewModel from  './personViewModel';
export default class PersonMapper {
    
	mapApiResponseToViewModel(dto: Api.PersonClientResponseModel) : PersonViewModel 
	{
		let response = new PersonViewModel();
		response.setProperties(dto.personId,dto.personName);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PersonViewModel) : Api.PersonClientRequestModel
	{
		let response = new Api.PersonClientRequestModel();
		response.setProperties(model.personId,model.personName);
		return response;
	}
};

/*<Codenesium>
    <Hash>eb8f4839fd9e94398273c8ece231d331</Hash>
</Codenesium>*/