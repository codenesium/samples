using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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

			if (item.TenantIdNavigation != null)
			{
				var tenantIdModel = new ApiTeacherServerResponseModel();
				tenantIdModel.SetProperties(
					item.TenantIdNavigation.Id,
					item.TenantIdNavigation.Birthday,
					item.TenantIdNavigation.Email,
					item.TenantIdNavigation.FirstName,
					item.TenantIdNavigation.LastName,
					item.TenantIdNavigation.Phone,
					item.TenantIdNavigation.UserId);

				model.SetTenantIdNavigation(tenantIdModel);
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
    <Hash>78649e3c47690dbf78dbab1534203c57</Hash>
</Codenesium>*/