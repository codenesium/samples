using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiSalesTaxRateModelMapper
	{
		public virtual ApiSalesTaxRateClientResponseModel MapClientRequestToResponse(
			int salesTaxRateID,
			ApiSalesTaxRateClientRequestModel request)
		{
			var response = new ApiSalesTaxRateClientResponseModel();
			response.SetProperties(salesTaxRateID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.StateProvinceID,
			                       request.TaxRate,
			                       request.TaxType);
			return response;
		}

		public virtual ApiSalesTaxRateClientRequestModel MapClientResponseToRequest(
			ApiSalesTaxRateClientResponseModel response)
		{
			var request = new ApiSalesTaxRateClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.StateProvinceID,
				response.TaxRate,
				response.TaxType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>be73a7c295ed4c2964836dcb6bd9d405</Hash>
</Codenesium>*/