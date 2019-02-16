using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALStoreMapper
	{
		public virtual Store MapModelToBO(
			int businessEntityID,
			ApiStoreServerRequestModel model
			)
		{
			Store item = new Store();
			item.SetProperties(
				businessEntityID,
				model.Demographic,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
			return item;
		}

		public virtual ApiStoreServerResponseModel MapBOToModel(
			Store item)
		{
			var model = new ApiStoreServerResponseModel();

			model.SetProperties(item.BusinessEntityID, item.Demographic, item.ModifiedDate, item.Name, item.Rowguid, item.SalesPersonID);

			return model;
		}

		public virtual List<ApiStoreServerResponseModel> MapBOToModel(
			List<Store> items)
		{
			List<ApiStoreServerResponseModel> response = new List<ApiStoreServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f98385ab1bff01b90d8aaad838bb20f3</Hash>
</Codenesium>*/