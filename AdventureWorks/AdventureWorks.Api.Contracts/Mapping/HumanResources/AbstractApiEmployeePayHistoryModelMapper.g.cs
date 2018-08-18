using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiEmployeePayHistoryModelMapper
	{
		public virtual ApiEmployeePayHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmployeePayHistoryRequestModel request)
		{
			var response = new ApiEmployeePayHistoryResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.PayFrequency,
			                       request.Rate,
			                       request.RateChangeDate);
			return response;
		}

		public virtual ApiEmployeePayHistoryRequestModel MapResponseToRequest(
			ApiEmployeePayHistoryResponseModel response)
		{
			var request = new ApiEmployeePayHistoryRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.PayFrequency,
				response.Rate,
				response.RateChangeDate);
			return request;
		}

		public JsonPatchDocument<ApiEmployeePayHistoryRequestModel> CreatePatch(ApiEmployeePayHistoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmployeePayHistoryRequestModel>();
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.PayFrequency, model.PayFrequency);
			patch.Replace(x => x.Rate, model.Rate);
			patch.Replace(x => x.RateChangeDate, model.RateChangeDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>e2c84570b5cbd439307a666bda32656f</Hash>
</Codenesium>*/