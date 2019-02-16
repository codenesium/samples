import * as Api from '../api/models';
import TeacherSkillViewModel from  '../viewmodels/teacherSkillViewModel';

export default class TeacherSkillMapper {
    
	mapApiResponseToViewModel(dto: Api.TeacherSkillClientResponseModel) : TeacherSkillViewModel 
	{
		let response = new TeacherSkillViewModel();
		response.setProperties(dto.id,dto.isDeleted,dto.name,dto.tenantId);
		return response;
	}

	mapViewModelToApiRequest(model: TeacherSkillViewModel) : Api.TeacherSkillClientRequestModel
	{
		let response = new Api.TeacherSkillClientRequestModel();
		response.setProperties(model.id,model.isDeleted,model.name,model.tenantId);
		return response;
	}
};

/*<Codenesium>
    <Hash>984dd20db52e34ff2bd3cec026e3babc</Hash>
</Codenesium>*/