using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALHandlerMapper
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
    <Hash>d80c914a6cf8307660f26b463efec12e</Hash>
</Codenesium>*/