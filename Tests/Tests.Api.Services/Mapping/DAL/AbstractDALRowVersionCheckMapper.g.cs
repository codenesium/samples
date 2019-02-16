using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractDALRowVersionCheckMapper
	{
		public virtual RowVersionCheck MapModelToEntity(
			int id,
			ApiRowVersionCheckServerRequestModel model
			)
		{
			RowVersionCheck item = new RowVersionCheck();
			item.SetProperties(
				id,
				model.Name,
				model.RowVersion);
			return item;
		}

		public virtual ApiRowVersionCheckServerResponseModel MapEntityToModel(
			RowVersionCheck item)
		{
			var model = new ApiRowVersionCheckServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.RowVersion);

			return model;
		}

		public virtual List<ApiRowVersionCheckServerResponseModel> MapEntityToModel(
			List<RowVersionCheck> items)
		{
			List<ApiRowVersionCheckServerResponseModel> response = new List<ApiRowVersionCheckServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>43a4a689a4dff005eb23ea1fef0cce15</Hash>
</Codenesium>*/