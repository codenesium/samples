import * as Api from '../../api/models';
import TeacherSkillViewModel from './teacherSkillViewModel';
export default class TeacherSkillMapper {
  mapApiResponseToViewModel(
    dto: Api.TeacherSkillClientResponseModel
  ): TeacherSkillViewModel {
    let response = new TeacherSkillViewModel();
    response.setProperties(dto.id, dto.name);

    return response;
  }

  mapViewModelToApiRequest(
    model: TeacherSkillViewModel
  ): Api.TeacherSkillClientRequestModel {
    let response = new Api.TeacherSkillClientRequestModel();
    response.setProperties(model.id, model.name);
    return response;
  }
}


/*<Codenesium>
    <Hash>1c3055d3f715cb6e93aa9ac12c5c9f9f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/