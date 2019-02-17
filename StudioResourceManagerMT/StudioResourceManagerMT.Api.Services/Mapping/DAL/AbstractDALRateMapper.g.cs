using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALRateMapper
	{
		public virtual Rate MapModelToEntity(
			int id,
			ApiRateServerRequestModel model
			)
		{
			Rate item = new Rate();
			item.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId);
			return item;
		}

		public virtual ApiRateServerResponseModel MapEntityToModel(
			Rate item)
		{
			var model = new ApiRateServerResponseModel();

			model.SetProperties(item.Id,
			                    item.AmountPerMinute,
			                    item.TeacherId,
			                    item.TeacherSkillId);

			return model;
		}

		public virtual List<ApiRateServerResponseModel> MapEntityToModel(
			List<Rate> items)
		{
			List<ApiRateServerResponseModel> response = new List<ApiRateServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>92142134ea78d1a160a105e225a3ff13</Hash>
</Codenesium>*/