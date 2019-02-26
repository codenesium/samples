using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOfficerCapabilitiesMapper
	{
		public virtual OfficerCapabilities MapModelToEntity(
			int capabilityId,
			ApiOfficerCapabilitiesServerRequestModel model
			)
		{
			OfficerCapabilities item = new OfficerCapabilities();
			item.SetProperties(
				capabilityId,
				model.OfficerId);
			return item;
		}

		public virtual ApiOfficerCapabilitiesServerResponseModel MapEntityToModel(
			OfficerCapabilities item)
		{
			var model = new ApiOfficerCapabilitiesServerResponseModel();

			model.SetProperties(item.CapabilityId,
			                    item.OfficerId);
			if (item.CapabilityIdNavigation != null)
			{
				var capabilityIdModel = new ApiOfficerCapabilityServerResponseModel();
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
    <Hash>42e0387148d055faaf4d502acc46a3fd</Hash>
</Codenesium>*/