using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractStoreMapper
	{
		public virtual BOStore MapModelToBO(
			int businessEntityID,
			ApiStoreServerRequestModel model
			)
		{
			BOStore boStore = new BOStore();
			boStore.SetProperties(
				businessEntityID,
				model.Demographic,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
			return boStore;
		}

		public virtual ApiStoreServerResponseModel MapBOToModel(
			BOStore boStore)
		{
			var model = new ApiStoreServerResponseModel();

			model.SetProperties(boStore.BusinessEntityID, boStore.Demographic, boStore.ModifiedDate, boStore.Name, boStore.Rowguid, boStore.SalesPersonID);

			return model;
		}

		public virtual List<ApiStoreServerResponseModel> MapBOToModel(
			List<BOStore> items)
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
    <Hash>297bf1cd8d2930ae84bb86befe39bd18</Hash>
</Codenesium>*/