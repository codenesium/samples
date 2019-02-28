import * as Api from '../../api/models';
import FamilyViewModel from  './familyViewModel';
export default class FamilyMapper {
    
	mapApiResponseToViewModel(dto: Api.FamilyClientResponseModel) : FamilyViewModel 
	{
		let response = new FamilyViewModel();
		response.setProperties(dto.id,dto.note,dto.primaryContactEmail,dto.primaryContactFirstName,dto.primaryContactLastName,dto.primaryContactPhone);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: FamilyViewModel) : Api.FamilyClientRequestModel
	{
		let response = new Api.FamilyClientRequestModel();
		response.setProperties(model.id,model.note,model.primaryContactEmail,model.primaryContactFirstName,model.primaryContactLastName,model.primaryContactPhone);
		return response;
	}
};

/*<Codenesium>
    <Hash>61545be551a771722899ec621a35856c</Hash>
</Codenesium>*/