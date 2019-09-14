using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PointOfSaleNS.Api.Services
{
	public class DALSaleMapper : IDALSaleMapper
	{
		public virtual Sale MapModelToEntity(
			int id,
			ApiSaleServerRequestModel model
			)
		{
			Sale item = new Sale();
			item.SetProperties(
				id,
				model.CustomerId,
				model.Date);
			return item;
		}

		public virtual ApiSaleServerResponseModel MapEntityToModel(
			Sale item)
		{
			var model = new ApiSaleServerResponseModel();

			model.SetProperties(item.Id,
			                    item.CustomerId,
			                    item.Date);

			return model;
		}

		public virtual List<ApiSaleServerResponseModel> MapEntityToModel(
			List<Sale> items)
		{
			List<ApiSaleServerResponseModel> response = new List<ApiSaleServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4c253e5d7b8c07c07e47a1eb2e047e82</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/