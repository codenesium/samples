using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractDALSpaceMapper
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
    <Hash>44c130e074b7e1987a603a2dab0444a8</Hash>
</Codenesium>*/