using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALTeacherTeacherSkillMapper
	{
		public virtual TeacherTeacherSkill MapModelToEntity(
			int teacherId,
			ApiTeacherTeacherSkillServerRequestModel model
			)
		{
			TeacherTeacherSkill item = new TeacherTeacherSkill();
			item.SetProperties(
				teacherId,
				model.TeacherSkillId);
			return item;
		}

		public virtual ApiTeacherTeacherSkillServerResponseModel MapEntityToModel(
			TeacherTeacherSkill item)
		{
			var model = new ApiTeacherTeacherSkillServerResponseModel();

			model.SetProperties(item.TeacherId,
			                    item.TeacherSkillId);
			if (item.TeacherIdNavigation != null)
			{
				var teacherIdModel = new ApiTeacherServerResponseModel();
				teacherIdModel.SetProperties(
					item.TeacherIdNavigation.Id,
					item.TeacherIdNavigation.Birthday,
					item.TeacherIdNavigation.Email,
					item.TeacherIdNavigation.FirstName,
					item.TeacherIdNavigation.LastName,
					item.TeacherIdNavigation.Phone,
					item.TeacherIdNavigation.UserId);

				model.SetTeacherIdNavigation(teacherIdModel);
			}

			if (item.TeacherSkillIdNavigation != null)
			{
				var teacherSkillIdModel = new ApiTeacherSkillServerResponseModel();
				teacherSkillIdModel.SetProperties(
					item.TeacherSkillIdNavigation.Id,
					item.TeacherSkillIdNavigation.Name);

				model.SetTeacherSkillIdNavigation(teacherSkillIdModel);
			}

			return model;
		}

		public virtual List<ApiTeacherTeacherSkillServerResponseModel> MapEntityToModel(
			List<TeacherTeacherSkill> items)
		{
			List<ApiTeacherTeacherSkillServerResponseModel> response = new List<ApiTeacherTeacherSkillServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21d07dd0cd6501705d5d9626bf45e267</Hash>
</Codenesium>*/