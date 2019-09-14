import * as Api from '../../api/models';
import TeacherTeacherSkillViewModel from './teacherTeacherSkillViewModel';
import TeacherViewModel from '../teacher/teacherViewModel';
import TeacherSkillViewModel from '../teacherSkill/teacherSkillViewModel';
export default class TeacherTeacherSkillMapper {
  mapApiResponseToViewModel(
    dto: Api.TeacherTeacherSkillClientResponseModel
  ): TeacherTeacherSkillViewModel {
    let response = new TeacherTeacherSkillViewModel();
    response.setProperties(dto.id, dto.teacherId, dto.teacherSkillId);

    if (dto.teacherIdNavigation != null) {
      response.teacherIdNavigation = new TeacherViewModel();
      response.teacherIdNavigation.setProperties(
        dto.teacherIdNavigation.birthday,
        dto.teacherIdNavigation.email,
        dto.teacherIdNavigation.firstName,
        dto.teacherIdNavigation.id,
        dto.teacherIdNavigation.lastName,
        dto.teacherIdNavigation.phone,
        dto.teacherIdNavigation.userId
      );
    }
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
    <Hash>08ce3b3ad5c9daa861b65cbe5c3bc1f8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/