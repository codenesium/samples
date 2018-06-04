using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractStoreMapper
	{
		public virtual BOStore MapModelToBO(
			int businessEntityID,
			ApiStoreRequestModel model
			)
		{
			BOStore BOStore = new BOStore();

			BOStore.SetProperties(
				businessEntityID,
				model.Demographics,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
			return BOStore;
		}

		public virtual ApiStoreResponseModel MapBOToModel(
			BOStore BOStore)
		{
			if (BOStore == null)
			{
				return null;
			}

			var model = new ApiStoreResponseModel();

			model.SetProperties(BOStore.BusinessEntityID, BOStore.Demographics, BOStore.ModifiedDate, BOStore.Name, BOStore.Rowguid, BOStore.SalesPersonID);

			return model;
		}

		public virtual List<ApiStoreResponseModel> MapBOToModel(
			List<BOStore> BOs)
		{
			List<ApiStoreResponseModel> response = new List<ApiStoreResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7421cf859c375d01994409b259e9d6ac</Hash>
</Codenesium>*/