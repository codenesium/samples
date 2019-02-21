import * as Api from '../../api/models';
import RateViewModel from  './rateViewModel';
export default class RateMapper {
    
	mapApiResponseToViewModel(dto: Api.RateClientResponseModel) : RateViewModel 
	{
		let response = new RateViewModel();
		response.setProperties(dto.amountPerMinute,dto.id,dto.teacherId,dto.teacherSkillId);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: RateViewModel) : Api.RateClientRequestModel
	{
		let response = new Api.RateClientRequestModel();
		response.setProperties(model.amountPerMinute,model.id,model.teacherId,model.teacherSkillId);
		return response;
	}
};

/*<Codenesium>
    <Hash>4a3a104eeb1a1bb00093f8f2ff3e1015</Hash>
</Codenesium>*/