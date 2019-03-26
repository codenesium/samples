using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiUnitMeasureModelMapper
	{
		public virtual ApiUnitMeasureClientResponseModel MapClientRequestToResponse(
			string unitMeasureCode,
			ApiUnitMeasureClientRequestModel request)
		{
			var response = new ApiUnitMeasureClientResponseModel();
			response.SetProperties(unitMeasureCode,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiUnitMeasureClientRequestModel MapClientResponseToRequest(
			ApiUnitMeasureClientResponseModel response)
		{
			var request = new ApiUnitMeasureClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>95313b836870436bea8cca7ee7220da5</Hash>
</Codenesium>*/