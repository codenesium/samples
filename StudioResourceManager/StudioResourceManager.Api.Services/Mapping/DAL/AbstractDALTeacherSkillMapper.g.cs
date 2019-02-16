using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>f1a5100c762b5985c57e791b3a6bfe56</Hash>
</Codenesium>*/