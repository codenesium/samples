using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOfficerCapabilityMapper
	{
		public virtual OfficerCapability MapModelToEntity(
			int capabilityId,
			ApiOfficerCapabilityServerRequestModel model
			)
		{
			OfficerCapability item = new OfficerCapability();
			item.SetProperties(
				capabilityId,
				model.OfficerId);
			return item;
		}

		public virtual ApiOfficerCapabilityServerResponseModel MapEntityToModel(
			OfficerCapability item)
		{
			var model = new ApiOfficerCapabilityServerResponseModel();

			model.SetProperties(item.CapabilityId,
			                    item.OfficerId);
			if (item.CapabilityIdNavigation != null)
			{
				var capabilityIdModel = new ApiOfficerCapabilityServerResponseModel();
				capabilityIdModel.SetProperties(
					item.CapabilityIdNavigation.CapabilityId,
					item.CapabilityIdNavigation.OfficerId);

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
    <Hash>9476694fcf42878afa005bb5d60f78f5</Hash>
</Codenesium>*/