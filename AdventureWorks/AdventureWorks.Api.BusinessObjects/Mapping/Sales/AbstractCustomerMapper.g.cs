using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLCustomerMapper
	{
		public virtual DTOCustomer MapModelToDTO(
			int customerID,
			ApiCustomerRequestModel model
			)
		{
			DTOCustomer dtoCustomer = new DTOCustomer();

			dtoCustomer.SetProperties(
				customerID,
				model.AccountNumber,
				model.ModifiedDate,
				model.PersonID,
				model.Rowguid,
				model.StoreID,
				model.TerritoryID);
			return dtoCustomer;
		}

		public virtual ApiCustomerResponseModel MapDTOToModel(
			DTOCustomer dtoCustomer)
		{
			if (dtoCustomer == null)
			{
				return null;
			}

			var model = new ApiCustomerResponseModel();

			model.SetProperties(dtoCustomer.AccountNumber, dtoCustomer.CustomerID, dtoCustomer.ModifiedDate, dtoCustomer.PersonID, dtoCustomer.Rowguid, dtoCustomer.StoreID, dtoCustomer.TerritoryID);

			return model;
		}

		public virtual List<ApiCustomerResponseModel> MapDTOToModel(
			List<DTOCustomer> dtos)
		{
			List<ApiCustomerResponseModel> response = new List<ApiCustomerResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>85b84f25eb2d3be9778b383270d836b1</Hash>
</Codenesium>*/