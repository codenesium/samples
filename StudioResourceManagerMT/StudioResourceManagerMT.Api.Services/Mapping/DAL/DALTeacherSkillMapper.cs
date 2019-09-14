using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>4b08c061baf23b122aefe9b3a8a10e2c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/