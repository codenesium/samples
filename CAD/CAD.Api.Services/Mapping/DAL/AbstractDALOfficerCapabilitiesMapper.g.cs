using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOfficerCapabilitiesMapper
	{
		public virtual OfficerCapabilities MapModelToEntity(
			int id,
			ApiOfficerCapabilitiesServerRequestModel model
			)
		{
			OfficerCapabilities item = new OfficerCapabilities();
			item.SetProperties(
				id,
				model.CapabilityId,
				model.OfficerId);
			return item;
		}

		public virtual ApiOfficerCapabilitiesServerResponseModel MapEntityToModel(
			OfficerCapabilities item)
		{
			var model = new ApiOfficerCapabilitiesServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CapabilityId,
			                    item.OfficerId);
			if (item.CapabilityIdNavigation != null)
			{
				var capabilityIdModel = new ApiOffCapabilityServerResponseModel();
				capabilityIdModel.SetProperties(
					item.CapabilityIdNavigation.Id,
					item.CapabilityIdNavigation.Name);

				model.SetCapabilityIdNavigation(capabilityIdModel);
			}

			if (item.OfficerIdNavigation != null)
			{
				var officerIdModel = new ApiOfficerServerResponseModel();
				officerIdModel.SetProperties(
					item.OfficerIdNavigation.Id,
					item.OfficerIdNavigation.Badge,
					item.OfficerIdNavigation.Email,
					item.OfficerIdNavigation.FirstName,
					item.OfficerIdNavigation.LastName,
					item.OfficerIdNavigation.Password);

				model.SetOfficerIdNavigation(officerIdModel);
			}

			return model;
		}

		public virtual List<ApiOfficerCapabilitiesServerResponseModel> MapEntityToModel(
			List<OfficerCapabilities> items)
		{
			List<ApiOfficerCapabilitiesServerResponseModel> response = new List<ApiOfficerCapabilitiesServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f33a1e67c9e9015ca7c2c89764cad8c8</Hash>
</Codenesium>*/