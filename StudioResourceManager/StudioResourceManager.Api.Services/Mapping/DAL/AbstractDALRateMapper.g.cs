using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractDALRateMapper
	{
		public virtual Rate MapModelToEntity(
			int id,
			ApiRateServerRequestModel model
			)
		{
			Rate item = new Rate();
			item.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId);
			return item;
		}

		public virtual ApiRateServerResponseModel MapEntityToModel(
			Rate item)
		{
			var model = new ApiRateServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AmountPerMinute,
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

		public virtual List<ApiRateServerResponseModel> MapEntityToModel(
			List<Rate> items)
		{
			List<ApiRateServerResponseModel> response = new List<ApiRateServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4b79fc0be6e093af36273f4015f83705</Hash>
</Codenesium>*/