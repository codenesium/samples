using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public abstract class AbstractApiEfmigrationshistoryModelMapper
	{
		public virtual ApiEfmigrationshistoryClientResponseModel MapClientRequestToResponse(
			string migrationId,
			ApiEfmigrationshistoryClientRequestModel request)
		{
			var response = new ApiEfmigrationshistoryClientResponseModel();
			response.SetProperties(migrationId,
			                       request.ProductVersion);
			return response;
		}

		public virtual ApiEfmigrationshistoryClientRequestModel MapClientResponseToRequest(
			ApiEfmigrationshistoryClientResponseModel response)
		{
			var request = new ApiEfmigrationshistoryClientRequestModel();
			request.SetProperties(
				response.ProductVersion);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>3aaf093821eabd06530b38a47f2a65e5</Hash>
</Codenesium>*/