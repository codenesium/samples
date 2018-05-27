using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLSalesTaxRateMapper
	{
		public virtual DTOSalesTaxRate MapModelToDTO(
			int salesTaxRateID,
			ApiSalesTaxRateRequestModel model
			)
		{
			DTOSalesTaxRate dtoSalesTaxRate = new DTOSalesTaxRate();

			dtoSalesTaxRate.SetProperties(
				salesTaxRateID,
				model.ModifiedDate,
				model.Name,
				model.Rowguid,
				model.StateProvinceID,
				model.TaxRate,
				model.TaxType);
			return dtoSalesTaxRate;
		}

		public virtual ApiSalesTaxRateResponseModel MapDTOToModel(
			DTOSalesTaxRate dtoSalesTaxRate)
		{
			if (dtoSalesTaxRate == null)
			{
				return null;
			}

			var model = new ApiSalesTaxRateResponseModel();

			model.SetProperties(dtoSalesTaxRate.ModifiedDate, dtoSalesTaxRate.Name, dtoSalesTaxRate.Rowguid, dtoSalesTaxRate.SalesTaxRateID, dtoSalesTaxRate.StateProvinceID, dtoSalesTaxRate.TaxRate, dtoSalesTaxRate.TaxType);

			return model;
		}

		public virtual List<ApiSalesTaxRateResponseModel> MapDTOToModel(
			List<DTOSalesTaxRate> dtos)
		{
			List<ApiSalesTaxRateResponseModel> response = new List<ApiSalesTaxRateResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a91ea5181e1595ebf1d4213104a9a205</Hash>
</Codenesium>*/