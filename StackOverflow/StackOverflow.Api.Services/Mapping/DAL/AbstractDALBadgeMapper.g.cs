using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALBadgeMapper
	{
		public virtual Badge MapModelToEntity(
			int id,
			ApiBadgeServerRequestModel model
			)
		{
			Badge item = new Badge();
			item.SetProperties(
				id,
				model.Date,
				model.Name,
				model.UserId);
			return item;
		}

		public virtual ApiBadgeServerResponseModel MapEntityToModel(
			Badge item)
		{
			var model = new ApiBadgeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Date,
			                    item.Name,
			                    item.UserId);

			return model;
		}

		public virtual List<ApiBadgeServerResponseModel> MapEntityToModel(
			List<Badge> items)
		{
			List<ApiBadgeServerResponseModel> response = new List<ApiBadgeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a515843bb6dac1de58e610550b7a8a5c</Hash>
</Codenesium>*/