using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallPersonModelMapper
	{
		public virtual ApiCallPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallPersonClientRequestModel request)
		{
			var response = new ApiCallPersonClientResponseModel();
			response.SetProperties(id,
			                       request.Note,
			                       request.PersonId,
			                       request.PersonTypeId);
			return response;
		}

		public virtual ApiCallPersonClientRequestModel MapClientResponseToRequest(
			ApiCallPersonClientResponseModel response)
		{
			var request = new ApiCallPersonClientRequestModel();
			request.SetProperties(
				response.Note,
				response.PersonId,
				response.PersonTypeId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>49eac2bf2913a99e1dd51b796a555479</Hash>
</Codenesium>*/