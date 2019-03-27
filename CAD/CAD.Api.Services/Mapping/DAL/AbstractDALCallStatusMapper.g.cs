using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALCallStatusMapper
	{
		public virtual CallStatus MapModelToEntity(
			int id,
			ApiCallStatusServerRequestModel model
			)
		{
			CallStatus item = new CallStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCallStatusServerResponseModel MapEntityToModel(
			CallStatus item)
		{
			var model = new ApiCallStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCallStatusServerResponseModel> MapEntityToModel(
			List<CallStatus> items)
		{
			List<ApiCallStatusServerResponseModel> response = new List<ApiCallStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8b9d7a5d47ff6f5f9dee9a9ba7b977a9</Hash>
</Codenesium>*/