using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALTeacherSkillMapper : IDALTeacherSkillMapper
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
    <Hash>f70d15f1a30c72dbf2de34a40a1ac50a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/