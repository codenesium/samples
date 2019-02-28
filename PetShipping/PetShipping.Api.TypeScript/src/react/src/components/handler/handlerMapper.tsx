import * as Api from '../../api/models';
import HandlerViewModel from  './handlerViewModel';
export default class HandlerMapper {
    
	mapApiResponseToViewModel(dto: Api.HandlerClientResponseModel) : HandlerViewModel 
	{
		let response = new HandlerViewModel();
		response.setProperties(dto.countryId,dto.email,dto.firstName,dto.id,dto.lastName,dto.phone);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: HandlerViewModel) : Api.HandlerClientRequestModel
	{
		let response = new Api.HandlerClientRequestModel();
		response.setProperties(model.countryId,model.email,model.firstName,model.id,model.lastName,model.phone);
		return response;
	}
};

/*<Codenesium>
    <Hash>7e9caaa8fb5622b472ce549250bef1f6</Hash>
</Codenesium>*/