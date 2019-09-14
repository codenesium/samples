using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALVehCapabilityMapper : IDALVehCapabilityMapper
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
    <Hash>41e45626af39bbc220987feb48398d4a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/