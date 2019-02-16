import * as Api from '../../api/models';
import BadgeViewModel from  './badgeViewModel';
export default class BadgeMapper {
    
	mapApiResponseToViewModel(dto: Api.BadgeClientResponseModel) : BadgeViewModel 
	{
		let response = new BadgeViewModel();
		response.setProperties(dto.date,dto.id,dto.name,dto.userId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: BadgeViewModel) : Api.BadgeClientRequestModel
	{
		let response = new Api.BadgeClientRequestModel();
		response.setProperties(model.date,model.id,model.name,model.userId);
		return response;
	}
};

/*<Codenesium>
    <Hash>f35e01182167b73a5ac362937ba868a5</Hash>
</Codenesium>*/