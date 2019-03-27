using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALVehCapabilityMapper
	{
		public virtual VehCapability MapModelToEntity(
			int id,
			ApiVehCapabilityServerRequestModel model
			)
		{
			VehCapability item = new VehCapability();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiVehCapabilityServerResponseModel MapEntityToModel(
			VehCapability item)
		{
			var model = new ApiVehCapabilityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiVehCapabilityServerResponseModel> MapEntityToModel(
			List<VehCapability> items)
		{
			List<ApiVehCapabilityServerResponseModel> response = new List<ApiVehCapabilityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4a47e89fe4124bfb4a10bd59cd7e2e11</Hash>
</Codenesium>*/