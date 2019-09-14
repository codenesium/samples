using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>7f7058b1e5e6bcdf893d08bbf11b7f7b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/