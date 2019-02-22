using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOfficerCapabilityMapper
	{
		public virtual OfficerCapability MapModelToEntity(
			int id,
			ApiOfficerCapabilityServerRequestModel model
			)
		{
			OfficerCapability item = new OfficerCapability();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiOfficerCapabilityServerResponseModel MapEntityToModel(
			OfficerCapability item)
		{
			var model = new ApiOfficerCapabilityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiOfficerCapabilityServerResponseModel> MapEntityToModel(
			List<OfficerCapability> items)
		{
			List<ApiOfficerCapabilityServerResponseModel> response = new List<ApiOfficerCapabilityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21ab030a1f2a0519dbeb05b64e1f833d</Hash>
</Codenesium>*/