using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCurrencyMapper
	{
		public virtual Currency MapModelToEntity(
			string currencyCode,
			ApiCurrencyServerRequestModel model
			)
		{
			Currency item = new Currency();
			item.SetProperties(
				currencyCode,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiCurrencyServerResponseModel MapEntityToModel(
			Currency item)
		{
			var model = new ApiCurrencyServerResponseModel();

			model.SetProperties(item.CurrencyCode,
			                    item.ModifiedDate,
			                    item.Name);

			return model;
		}

		public virtual List<ApiCurrencyServerResponseModel> MapEntityToModel(
			List<Currency> items)
		{
			List<ApiCurrencyServerResponseModel> response = new List<ApiCurrencyServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>352e6a8eb98aeee3bd039abf2383a275</Hash>
</Codenesium>*/