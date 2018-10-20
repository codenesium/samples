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
				model.TeacherSkillId,
				model.IsDeleted);
			return boTeacherTeacherSkill;
		}

		public virtual ApiTeacherTeacherSkillResponseModel MapBOToModel(
			BOTeacherTeacherSkill boTeacherTeacherSkill)
		{
			var model = new ApiTeacherTeacherSkillResponseModel();

			model.SetProperties(boTeacherTeacherSkill.TeacherId, boTeacherTeacherSkill.TeacherSkillId, boTeacherTeacherSkill.IsDeleted);

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
    <Hash>5ac850a459021ed4c0d1a30aa9e9f7fb</Hash>
</Codenesium>*/