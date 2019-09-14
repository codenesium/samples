using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
	public class DALPenMapper : IDALPenMapper
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
    <Hash>3090c1136cb26a154ad6ef3561229a18</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/