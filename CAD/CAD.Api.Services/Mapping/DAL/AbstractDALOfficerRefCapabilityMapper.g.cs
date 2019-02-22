using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public abstract class AbstractDALOfficerRefCapabilityMapper
	{
		public virtual OfficerRefCapability MapModelToEntity(
			int id,
			ApiOfficerRefCapabilityServerRequestModel model
			)
		{
			OfficerRefCapability item = new OfficerRefCapability();
			item.SetProperties(
				id,
				model.CapabilityId,
				model.OfficerId);
			return item;
		}

		public virtual ApiOfficerRefCapabilityServerResponseModel MapEntityToModel(
			OfficerRefCapability item)
		{
			var model = new ApiOfficerRefCapabilityServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CapabilityId,
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

		public virtual List<ApiOfficerRefCapabilityServerResponseModel> MapEntityToModel(
			List<OfficerRefCapability> items)
		{
			List<ApiOfficerRefCapabilityServerResponseModel> response = new List<ApiOfficerRefCapabilityServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c38d5dccf65807551c9ee6fc1ab3b7e8</Hash>
</Codenesium>*/