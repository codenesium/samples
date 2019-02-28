import * as Api from '../../api/models';
import RateViewModel from  './rateViewModel';
	import TeacherViewModel from '../teacher/teacherViewModel'
		import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel'
	export default class RateMapper {
    
	mapApiResponseToViewModel(dto: Api.RateClientResponseModel) : RateViewModel 
	{
		let response = new RateViewModel();
		response.setProperties(dto.amountPerMinute,dto.id,dto.teacherId,dto.teacherSkillId);
		
						if(dto.teacherIdNavigation != null)
				{
				  response.teacherIdNavigation = new TeacherViewModel();
				  response.teacherIdNavigation.setProperties(
				  dto.teacherIdNavigation.birthday,dto.teacherIdNavigation.email,dto.teacherIdNavigation.firstName,dto.teacherIdNavigation.id,dto.teacherIdNavigation.lastName,dto.teacherIdNavigation.phone,dto.teacherIdNavigation.userId
				  );
				}
							if(dto.teacherSkillIdNavigation != null)
				{
				  response.teacherSkillIdNavigation = new TeacherSkillViewModel();
				  response.teacherSkillIdNavigation.setProperties(
				  dto.teacherSkillIdNavigation.id,dto.teacherSkillIdNavigation.name
				  );
				}
					

		
		
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
    <Hash>5b147379881fff0db7beb15f3c19b0a6</Hash>
</Codenesium>*/