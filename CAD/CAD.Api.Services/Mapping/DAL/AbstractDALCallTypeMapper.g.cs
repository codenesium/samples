using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALCallTypeMapper
	{
		public virtual CallType MapModelToEntity(
			int id,
			ApiCallTypeServerRequestModel model
			)
		{
			CallType item = new CallType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCallTypeServerResponseModel MapEntityToModel(
			CallType item)
		{
			var model = new ApiCallTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCallTypeServerResponseModel> MapEntityToModel(
			List<CallType> items)
		{
			List<ApiCallTypeServerResponseModel> response = new List<ApiCallTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0c3864cb172f6a4c235e138a7eb8985f</Hash>
</Codenesium>*/