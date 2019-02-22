using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALCallStatuMapper
	{
		public virtual CallStatu MapModelToEntity(
			int id,
			ApiCallStatuServerRequestModel model
			)
		{
			CallStatu item = new CallStatu();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCallStatuServerResponseModel MapEntityToModel(
			CallStatu item)
		{
			var model = new ApiCallStatuServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCallStatuServerResponseModel> MapEntityToModel(
			List<CallStatu> items)
		{
			List<ApiCallStatuServerResponseModel> response = new List<ApiCallStatuServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e26f94c7e4fa59846d20dd166a4be0d4</Hash>
</Codenesium>*/