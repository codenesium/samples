using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALHandlerMapper : IDALHandlerMapper
	{
		public virtual Handler MapModelToEntity(
			int id,
			ApiHandlerServerRequestModel model
			)
		{
			Handler item = new Handler();
			item.SetProperties(
				id,
				model.CountryId,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone);
			return item;
		}

		public virtual ApiHandlerServerResponseModel MapEntityToModel(
			Handler item)
		{
			var model = new ApiHandlerServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CountryId,
			                    item.Email,
			                    item.FirstName,
			                    item.LastName,
			                    item.Phone);

			return model;
		}

		public virtual List<ApiHandlerServerResponseModel> MapEntityToModel(
			List<Handler> items)
		{
			List<ApiHandlerServerResponseModel> response = new List<ApiHandlerServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0c1cc180909b8288c6623360ffe7960f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/