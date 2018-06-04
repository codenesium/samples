using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractTeacherXTeacherSkillMapper
	{
		public virtual BOTeacherXTeacherSkill MapModelToBO(
			int id,
			ApiTeacherXTeacherSkillRequestModel model
			)
		{
			BOTeacherXTeacherSkill BOTeacherXTeacherSkill = new BOTeacherXTeacherSkill();

			BOTeacherXTeacherSkill.SetProperties(
				id,
				model.TeacherId,
				model.TeacherSkillId);
			return BOTeacherXTeacherSkill;
		}

		public virtual ApiTeacherXTeacherSkillResponseModel MapBOToModel(
			BOTeacherXTeacherSkill BOTeacherXTeacherSkill)
		{
			if (BOTeacherXTeacherSkill == null)
			{
				return null;
			}

			var model = new ApiTeacherXTeacherSkillResponseModel();

			model.SetProperties(BOTeacherXTeacherSkill.Id, BOTeacherXTeacherSkill.TeacherId, BOTeacherXTeacherSkill.TeacherSkillId);

			return model;
		}

		public virtual List<ApiTeacherXTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherXTeacherSkill> BOs)
		{
			List<ApiTeacherXTeacherSkillResponseModel> response = new List<ApiTeacherXTeacherSkillResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9755fdcdc74fc2c3ccadbebd4806cd07</Hash>
</Codenesium>*/