using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public abstract class AbstractApiColumnSameAsFKTableModelMapper
	{
		public virtual ApiColumnSameAsFKTableClientResponseModel MapClientRequestToResponse(
			int id,
			ApiColumnSameAsFKTableClientRequestModel request)
		{
			var response = new ApiColumnSameAsFKTableClientResponseModel();
			response.SetProperties(id,
			                       request.Person,
			                       request.PersonId);
			return response;
		}

		public virtual ApiColumnSameAsFKTableClientRequestModel MapClientResponseToRequest(
			ApiColumnSameAsFKTableClientResponseModel response)
		{
			var request = new ApiColumnSameAsFKTableClientRequestModel();
			request.SetProperties(
				response.Person,
				response.PersonId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>7a36484c5427610d92d57ee58f3b63af</Hash>
</Codenesium>*/