using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public class DALOffCapabilityMapper : IDALOffCapabilityMapper
	{
		public virtual OffCapability MapModelToEntity(
			int id,
			ApiOffCapabilityServerRequestModel model
			)
		{
			OffCapability item = new OffCapability();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiOffCapabilityServerResponseModel MapEntityToModel(
			OffCapability item)
		{
			var model = new ApiOffCapabilityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiOffCapabilityServerResponseModel> MapEntityToModel(
			List<OffCapability> items)
		{
			List<ApiOffCapabilityServerResponseModel> response = new List<ApiOffCapabilityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f76b50aa7d748e3486149b913aeb7783</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/