using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALCultureMapper
	{
		public virtual Culture MapModelToBO(
			string cultureID,
			ApiCultureServerRequestModel model
			)
		{
			Culture item = new Culture();
			item.SetProperties(
				cultureID,
				model.ModifiedDate,
				model.Name);
			return item;
		}

		public virtual ApiCultureServerResponseModel MapBOToModel(
			Culture item)
		{
			var model = new ApiCultureServerResponseModel();

			model.SetProperties(item.CultureID, item.ModifiedDate, item.Name);

			return model;
		}

		public virtual List<ApiCultureServerResponseModel> MapBOToModel(
			List<Culture> items)
		{
			List<ApiCultureServerResponseModel> response = new List<ApiCultureServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dc1e2db5d8792a142c55e6c63cce7c93</Hash>
</Codenesium>*/