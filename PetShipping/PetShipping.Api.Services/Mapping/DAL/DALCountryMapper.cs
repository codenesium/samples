using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALCountryMapper : IDALCountryMapper
	{
		public virtual Country MapModelToEntity(
			int id,
			ApiCountryServerRequestModel model
			)
		{
			Country item = new Country();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiCountryServerResponseModel MapEntityToModel(
			Country item)
		{
			var model = new ApiCountryServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCountryServerResponseModel> MapEntityToModel(
			List<Country> items)
		{
			List<ApiCountryServerResponseModel> response = new List<ApiCountryServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e397ccd85af49110dddaf0cbcc54a0bb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/