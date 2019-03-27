using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOffCapabilityMapper
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
    <Hash>e4e9f84e27e6d906d7b8c30cd9ef30b5</Hash>
</Codenesium>*/