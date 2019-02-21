import * as Api from '../../api/models';
import TeacherSkillViewModel from  './teacherSkillViewModel';
export default class TeacherSkillMapper {
    
	mapApiResponseToViewModel(dto: Api.TeacherSkillClientResponseModel) : TeacherSkillViewModel 
	{
		let response = new TeacherSkillViewModel();
		response.setProperties(dto.id,dto.name);
		
				

		
		
		return response;
	}

	mapViewModelToApiRequest(model: TeacherSkillViewModel) : Api.TeacherSkillClientRequestModel
	{
		let response = new Api.TeacherSkillClientRequestModel();
		response.setProperties(model.id,model.name);
		return response;
	}
};

/*<Codenesium>
    <Hash>0c0553fda35337217138dbd4754acbb4</Hash>
</Codenesium>*/