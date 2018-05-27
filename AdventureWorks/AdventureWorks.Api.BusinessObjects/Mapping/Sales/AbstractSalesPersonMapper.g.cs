using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesPersonMapper
	{
		public virtual DTOSalesPerson MapModelToDTO(
			int businessEntityID,
			ApiSalesPersonRequestModel model
			)
		{
			DTOSalesPerson dtoSalesPerson = new DTOSalesPerson();

			dtoSalesPerson.SetProperties(
				businessEntityID,
				model.Bonus,
				model.CommissionPct,
				model.ModifiedDate,
				model.Rowguid,
				model.SalesLastYear,
				model.SalesQuota,
				model.SalesYTD,
				model.TerritoryID);
			return dtoSalesPerson;
		}

		public virtual ApiSalesPersonResponseModel MapDTOToModel(
			DTOSalesPerson dtoSalesPerson)
		{
			if (dtoSalesPerson == null)
			{
				return null;
			}

			var model = new ApiSalesPersonResponseModel();

			model.SetProperties(dtoSalesPerson.Bonus, dtoSalesPerson.BusinessEntityID, dtoSalesPerson.CommissionPct, dtoSalesPerson.ModifiedDate, dtoSalesPerson.Rowguid, dtoSalesPerson.SalesLastYear, dtoSalesPerson.SalesQuota, dtoSalesPerson.SalesYTD, dtoSalesPerson.TerritoryID);

			return model;
		}

		public virtual List<ApiSalesPersonResponseModel> MapDTOToModel(
			List<DTOSalesPerson> dtos)
		{
			List<ApiSalesPersonResponseModel> response = new List<ApiSalesPersonResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>654451c25667fcc2ff498c502d0666d7</Hash>
</Codenesium>*/