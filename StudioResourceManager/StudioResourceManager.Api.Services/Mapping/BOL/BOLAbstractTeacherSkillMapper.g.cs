using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTeacherSkillMapper
	{
		public virtual BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillRequestModel model
			)
		{
			BOTeacherSkill boTeacherSkill = new BOTeacherSkill();
			boTeacherSkill.SetProperties(
				id,
				model.Name,
				model.IsDeleted);
			return boTeacherSkill;
		}

		public virtual ApiTeacherSkillResponseModel MapBOToModel(
			BOTeacherSkill boTeacherSkill)
		{
			var model = new ApiTeacherSkillResponseModel();

			model.SetProperties(boTeacherSkill.Id, boTeacherSkill.Name, boTeacherSkill.IsDeleted);

			return model;
		}

		public virtual List<ApiTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherSkill> items)
		{
			List<ApiTeacherSkillResponseModel> response = new List<ApiTeacherSkillResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d817c581ab6d38f7dc39def7fe88a441</Hash>
</Codenesium>*/