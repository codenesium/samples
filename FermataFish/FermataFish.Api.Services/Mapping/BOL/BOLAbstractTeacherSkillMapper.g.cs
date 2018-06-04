using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractTeacherSkillMapper
	{
		public virtual BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillRequestModel model
			)
		{
			BOTeacherSkill BOTeacherSkill = new BOTeacherSkill();

			BOTeacherSkill.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return BOTeacherSkill;
		}

		public virtual ApiTeacherSkillResponseModel MapBOToModel(
			BOTeacherSkill BOTeacherSkill)
		{
			if (BOTeacherSkill == null)
			{
				return null;
			}

			var model = new ApiTeacherSkillResponseModel();

			model.SetProperties(BOTeacherSkill.Id, BOTeacherSkill.Name, BOTeacherSkill.StudioId);

			return model;
		}

		public virtual List<ApiTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherSkill> BOs)
		{
			List<ApiTeacherSkillResponseModel> response = new List<ApiTeacherSkillResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>423a8a11184129b6bc4c9bb558c7e12e</Hash>
</Codenesium>*/