using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractDALPenMapper
	{
		public virtual Pen MapModelToEntity(
			int id,
			ApiPenServerRequestModel model
			)
		{
			Pen item = new Pen();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPenServerResponseModel MapEntityToModel(
			Pen item)
		{
			var model = new ApiPenServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPenServerResponseModel> MapEntityToModel(
			List<Pen> items)
		{
			List<ApiPenServerResponseModel> response = new List<ApiPenServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e3f83342a8d5f37ac65d72155957e86a</Hash>
</Codenesium>*/