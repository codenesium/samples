import * as Api from '../../api/models';
import TeacherTeacherSkillViewModel from './teacherTeacherSkillViewModel';
import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel';
export default class TeacherTeacherSkillMapper {
  mapApiResponseToViewModel(
    dto: Api.TeacherTeacherSkillClientResponseModel
  ): TeacherTeacherSkillViewModel {
    let response = new TeacherTeacherSkillViewModel();
    response.setProperties(dto.id, dto.teacherId, dto.teacherSkillId);

    if (dto.teacherSkillIdNavigation != null) {
      response.teacherSkillIdNavigation = new TeacherSkillViewModel();
      response.teacherSkillIdNavigation.setProperties(
        dto.teacherSkillIdNavigation.id,
        dto.teacherSkillIdNavigation.name
      );
    }

    return response;
  }

  mapViewModelToApiRequest(
    model: TeacherTeacherSkillViewModel
  ): Api.TeacherTeacherSkillClientRequestModel {
    let response = new Api.TeacherTeacherSkillClientRequestModel();
    response.setProperties(model.id, model.teacherId, model.teacherSkillId);
    return response;
  }
}


/*<Codenesium>
    <Hash>a66028f56ed549dce462349463fd9d70</Hash>
</Codenesium>*/