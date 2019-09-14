using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class DALSpaceMapper : IDALSpaceMapper
	{
		public virtual Space MapModelToEntity(
			int id,
			ApiSpaceServerRequestModel model
			)
		{
			Space item = new Space();
			item.SetProperties(
				id,
				model.Description,
				model.Name);
			return item;
		}

		public virtual ApiSpaceServerResponseModel MapEntityToModel(
			Space item)
		{
			var model = new ApiSpaceServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Description,
			                    item.Name);

			return model;
		}

		public virtual List<ApiSpaceServerResponseModel> MapEntityToModel(
			List<Space> items)
		{
			List<ApiSpaceServerResponseModel> response = new List<ApiSpaceServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e5de1e4eab0b562550b222172fa60ad8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/