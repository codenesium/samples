using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLStoreMapper
	{
		public virtual DTOStore MapModelToDTO(
			int businessEntityID,
			ApiStoreRequestModel model
			)
		{
			DTOStore dtoStore = new DTOStore();

			dtoStore.SetProperties(
				businessEntityID,
				model.Demographics,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.SalesPersonID);
			return dtoStore;
		}

		public virtual ApiStoreResponseModel MapDTOToModel(
			DTOStore dtoStore)
		{
			if (dtoStore == null)
			{
				return null;
			}

			var model = new ApiStoreResponseModel();

			model.SetProperties(dtoStore.BusinessEntityID, dtoStore.Demographics, dtoStore.ModifiedDate, dtoStore.Name, dtoStore.Rowguid, dtoStore.SalesPersonID);

			return model;
		}

		public virtual List<ApiStoreResponseModel> MapDTOToModel(
			List<DTOStore> dtos)
		{
			List<ApiStoreResponseModel> response = new List<ApiStoreResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>45bf26f647e37b0e65821c654a1e7ca1</Hash>
</Codenesium>*/