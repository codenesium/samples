using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public class DALStudioMapper : IDALStudioMapper
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
    <Hash>72c72b94433cf594fa9b85a561ce7f63</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/