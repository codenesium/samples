using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractDALTimestampCheckMapper
	{
		public virtual TimestampCheck MapModelToEntity(
			int id,
			ApiTimestampCheckServerRequestModel model
			)
		{
			TimestampCheck item = new TimestampCheck();
			item.SetProperties(
				id,
				model.Name,
				model.Timestamp);
			return item;
		}

		public virtual ApiTimestampCheckServerResponseModel MapEntityToModel(
			TimestampCheck item)
		{
			var model = new ApiTimestampCheckServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name,
			                    item.Timestamp);

			return model;
		}

		public virtual List<ApiTimestampCheckServerResponseModel> MapEntityToModel(
			List<TimestampCheck> items)
		{
			List<ApiTimestampCheckServerResponseModel> response = new List<ApiTimestampCheckServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>105c8a8da53a297d1bcc372104c83409</Hash>
</Codenesium>*/