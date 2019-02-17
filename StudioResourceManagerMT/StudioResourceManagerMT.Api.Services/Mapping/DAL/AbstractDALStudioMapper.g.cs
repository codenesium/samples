using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractDALStudioMapper
	{
		public virtual Studio MapModelToEntity(
			int id,
			ApiStudioServerRequestModel model
			)
		{
			Studio item = new Studio();
			item.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.City,
				model.Name,
				model.Province,
				model.Website,
				model.Zip);
			return item;
		}

		public virtual ApiStudioServerResponseModel MapEntityToModel(
			Studio item)
		{
			var model = new ApiStudioServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Address1,
			                    item.Address2,
			                    item.City,
			                    item.Name,
			                    item.Province,
			                    item.Website,
			                    item.Zip);

			return model;
		}

		public virtual List<ApiStudioServerResponseModel> MapEntityToModel(
			List<Studio> items)
		{
			List<ApiStudioServerResponseModel> response = new List<ApiStudioServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6fb31ff9b1dcce0b24e3febd2ecc2c96</Hash>
</Codenesium>*/