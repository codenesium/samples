using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractStoreMapper
	{
		public virtual BOStore MapModelToBO(
			int businessEntityID,
			ApiStoreRequestModel model
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

		public virtual ApiStoreResponseModel MapBOToModel(
			BOStore boStore)
		{
			var model = new ApiStoreResponseModel();

			model.SetProperties(boStore.BusinessEntityID, boStore.Demographic, boStore.ModifiedDate, boStore.Name, boStore.Rowguid, boStore.SalesPersonID);

			return model;
		}

		public virtual List<ApiStoreResponseModel> MapBOToModel(
			List<BOStore> items)
		{
			List<ApiStoreResponseModel> response = new List<ApiStoreResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>be6bacc518ff6ab2f6d3802571352c4a</Hash>
</Codenesium>*/