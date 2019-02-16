using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiDatabaseLogModelMapper
	{
		public virtual ApiDatabaseLogClientResponseModel MapClientRequestToResponse(
			int databaseLogID,
			ApiDatabaseLogClientRequestModel request)
		{
			var response = new ApiDatabaseLogClientResponseModel();
			response.SetProperties(databaseLogID,
			                       request.DatabaseUser,
			                       request.PostTime,
			                       request.Schema,
			                       request.Tsql,
			                       request.XmlEvent);
			return response;
		}

		public virtual ApiDatabaseLogClientRequestModel MapClientResponseToRequest(
			ApiDatabaseLogClientResponseModel response)
		{
			var request = new ApiDatabaseLogClientRequestModel();
			request.SetProperties(
				response.DatabaseUser,
				response.PostTime,
				response.Schema,
				response.Tsql,
				response.XmlEvent);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a3a324ff58d70fe3ff8219e4ddb22329</Hash>
</Codenesium>*/