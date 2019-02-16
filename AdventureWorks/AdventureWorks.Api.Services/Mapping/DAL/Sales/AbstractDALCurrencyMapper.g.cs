using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCurrencyMapper
	{
		public virtual Currency MapModelToBO(
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

		public virtual ApiCurrencyServerResponseModel MapBOToModel(
			Currency item)
		{
			var model = new ApiCurrencyServerResponseModel();

			model.SetProperties(item.CurrencyCode, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiCurrencyServerResponseModel> MapBOToModel(
			List<Currency> items)
		{
			List<ApiCurrencyServerResponseModel> response = new List<ApiCurrencyServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>31cd04b447eb688e70224426733d9eba</Hash>
</Codenesium>*/