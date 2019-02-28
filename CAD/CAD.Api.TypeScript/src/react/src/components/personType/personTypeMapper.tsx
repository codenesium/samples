import * as Api from '../../api/models';
import PersonTypeViewModel from  './personTypeViewModel';
export default class PersonTypeMapper {
    
	mapApiResponseToViewModel(dto: Api.PersonTypeClientResponseModel) : PersonTypeViewModel 
	{
		let response = new PersonTypeViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: PersonTypeViewModel) : Api.PersonTypeClientRequestModel
	{
		let response = new Api.PersonTypeClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>652057262f0a8dc5c35cae4e9022810c</Hash>
</Codenesium>*/