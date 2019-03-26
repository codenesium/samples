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
			                       request.ReservedEvent,
			                       request.ReservedObject,
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
				response.ReservedEvent,
				response.ReservedObject,
				response.Schema,
				response.Tsql,
				response.XmlEvent);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>1b5d0ced650a45b39b0a4275a7f843a9</Hash>
</Codenesium>*/