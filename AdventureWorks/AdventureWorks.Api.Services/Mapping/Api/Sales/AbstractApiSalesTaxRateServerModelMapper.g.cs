using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesTaxRateServerModelMapper
	{
		public virtual ApiSalesTaxRateServerResponseModel MapServerRequestToResponse(
			int salesTaxRateID,
			ApiSalesTaxRateServerRequestModel request)
		{
			var response = new ApiSalesTaxRateServerResponseModel();
			response.SetProperties(salesTaxRateID,
			                       request.ModifiedDate,
			                       request.Name,
			                       request.Rowguid,
			                       request.StateProvinceID,
			                       request.TaxRate,
			                       request.TaxType);
			return response;
		}

		public virtual ApiSalesTaxRateServerRequestModel MapServerResponseToRequest(
			ApiSalesTaxRateServerResponseModel response)
		{
			var request = new ApiSalesTaxRateServerRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name,
				response.Rowguid,
				response.StateProvinceID,
				response.TaxRate,
				response.TaxType);
			return request;
		}

		public virtual ApiSalesTaxRateClientRequestModel MapServerResponseToClientRequest(
			ApiSalesTaxRateServerResponseModel response)
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

		public JsonPatchDocument<ApiSalesTaxRateServerRequestModel> CreatePatch(ApiSalesTaxRateServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiSalesTaxRateServerRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.StateProvinceID, model.StateProvinceID);
			patch.Replace(x => x.TaxRate, model.TaxRate);
			patch.Replace(x => x.TaxType, model.TaxType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d0a6e0991408eb54d4bcffc0f9ba8c8d</Hash>
</Codenesium>*/