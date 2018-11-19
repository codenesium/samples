using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTeacherSkillMapper
	{
		public virtual BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillServerRequestModel model
			)
		{
			BOTeacherSkill boTeacherSkill = new BOTeacherSkill();
			boTeacherSkill.SetProperties(
				id,
				model.Name);
			return boTeacherSkill;
		}

		public virtual ApiTeacherSkillServerResponseModel MapBOToModel(
			BOTeacherSkill boTeacherSkill)
		{
			var model = new ApiTeacherSkillServerResponseModel();

			model.SetProperties(boTeacherSkill.Id, boTeacherSkill.Name);

			return model;
		}

		public virtual List<ApiTeacherSkillServerResponseModel> MapBOToModel(
			List<BOTeacherSkill> items)
		{
			List<ApiTeacherSkillServerResponseModel> response = new List<ApiTeacherSkillServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>66890b5684bab3ab6490a3def1f1c2e9</Hash>
</Codenesium>*/