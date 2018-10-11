using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTeacherTeacherSkillMapper
	{
		public virtual BOTeacherTeacherSkill MapModelToBO(
			int teacherId,
			ApiTeacherTeacherSkillRequestModel model
			)
		{
			BOTeacherTeacherSkill boTeacherTeacherSkill = new BOTeacherTeacherSkill();
			boTeacherTeacherSkill.SetProperties(
				teacherId,
				model.TeacherSkillId);
			return boTeacherTeacherSkill;
		}

		public virtual ApiTeacherTeacherSkillResponseModel MapBOToModel(
			BOTeacherTeacherSkill boTeacherTeacherSkill)
		{
			var model = new ApiTeacherTeacherSkillResponseModel();

			model.SetProperties(boTeacherTeacherSkill.TeacherId, boTeacherTeacherSkill.TeacherSkillId);

			return model;
		}

		public virtual List<ApiTeacherTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherTeacherSkill> items)
		{
			List<ApiTeacherTeacherSkillResponseModel> response = new List<ApiTeacherTeacherSkillResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>47682f525dd5c99efd1699258401ad3f</Hash>
</Codenesium>*/