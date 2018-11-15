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
			                       request.@Event,
			                       request.@Object,
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
				response.@Event,
				response.@Object,
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
    <Hash>15d2e273f90be3e3ffdf441b98533074</Hash>
</Codenesium>*/