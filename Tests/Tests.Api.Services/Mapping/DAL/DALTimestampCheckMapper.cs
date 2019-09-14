using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALTimestampCheckMapper : IDALTimestampCheckMapper
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
    <Hash>70fcfc0157b606c037f15cd3ce59b9bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/