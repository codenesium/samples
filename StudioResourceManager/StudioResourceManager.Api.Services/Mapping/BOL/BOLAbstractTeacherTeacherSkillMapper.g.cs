using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractTeacherTeacherSkillMapper
	{
		public virtual BOTeacherTeacherSkill MapModelToBO(
			int id,
			ApiTeacherTeacherSkillRequestModel model
			)
		{
			BOTeacherTeacherSkill boTeacherTeacherSkill = new BOTeacherTeacherSkill();
			boTeacherTeacherSkill.SetProperties(
				id,
				model.TeacherId,
				model.TeacherSkillId);
			return boTeacherTeacherSkill;
		}

		public virtual ApiTeacherTeacherSkillResponseModel MapBOToModel(
			BOTeacherTeacherSkill boTeacherTeacherSkill)
		{
			var model = new ApiTeacherTeacherSkillResponseModel();

			model.SetProperties(boTeacherTeacherSkill.Id, boTeacherTeacherSkill.TeacherId, boTeacherTeacherSkill.TeacherSkillId);

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
    <Hash>519ccb83e5cffe0dcd23ef52e418ae65</Hash>
</Codenesium>*/