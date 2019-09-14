using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALTeacherTeacherSkillMapper : IDALTeacherTeacherSkillMapper
	{
		public virtual TeacherTeacherSkill MapModelToEntity(
			int id,
			ApiTeacherTeacherSkillServerRequestModel model
			)
		{
			TeacherTeacherSkill item = new TeacherTeacherSkill();
			item.SetProperties(
				id,
				model.TeacherId,
				model.TeacherSkillId);
			return item;
		}

		public virtual ApiTeacherTeacherSkillServerResponseModel MapEntityToModel(
			TeacherTeacherSkill item)
		{
			var model = new ApiTeacherTeacherSkillServerResponseModel();

			model.SetProperties(item.Id,
			                    item.TeacherId,
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
    <Hash>1b473c85e69a61ce5bdd27fcf7747a11</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/