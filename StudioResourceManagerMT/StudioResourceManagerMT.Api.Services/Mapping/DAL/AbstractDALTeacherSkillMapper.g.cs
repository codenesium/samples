using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALTeacherSkillMapper
	{
		public virtual TeacherSkill MapModelToEntity(
			int id,
			ApiTeacherSkillServerRequestModel model
			)
		{
			TeacherSkill item = new TeacherSkill();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiTeacherSkillServerResponseModel MapEntityToModel(
			TeacherSkill item)
		{
			var model = new ApiTeacherSkillServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiTeacherSkillServerResponseModel> MapEntityToModel(
			List<TeacherSkill> items)
		{
			List<ApiTeacherSkillServerResponseModel> response = new List<ApiTeacherSkillServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe349bd1f7785648077475c147ea1feb</Hash>
</Codenesium>*/