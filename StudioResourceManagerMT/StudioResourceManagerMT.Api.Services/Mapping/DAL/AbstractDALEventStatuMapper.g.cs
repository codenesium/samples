using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALEventStatuMapper
	{
		public virtual EventStatu MapModelToEntity(
			int id,
			ApiEventStatuServerRequestModel model
			)
		{
			EventStatu item = new EventStatu();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiEventStatuServerResponseModel MapEntityToModel(
			EventStatu item)
		{
			var model = new ApiEventStatuServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiEventStatuServerResponseModel> MapEntityToModel(
			List<EventStatu> items)
		{
			List<ApiEventStatuServerResponseModel> response = new List<ApiEventStatuServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8f77bc869f2c8b708d02fe96e09d2759</Hash>
</Codenesium>*/