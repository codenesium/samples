using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiPasswordModelMapper
	{
		public virtual ApiPasswordClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiPasswordClientRequestModel request)
		{
			var response = new ApiPasswordClientResponseModel();
			response.SetProperties(businessEntityID,
			                       request.ModifiedDate,
			                       request.PasswordHash,
			                       request.PasswordSalt,
			                       request.Rowguid);
			return response;
		}

		public virtual ApiPasswordClientRequestModel MapClientResponseToRequest(
			ApiPasswordClientResponseModel response)
		{
			var request = new ApiPasswordClientRequestModel();
			request.SetProperties(
				response.ModifiedDate,
				response.PasswordHash,
				response.PasswordSalt,
				response.Rowguid);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>92fbda6bec7e4b82b5bd634d2decc94b</Hash>
</Codenesium>*/