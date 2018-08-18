using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiDatabaseLogModelMapper
	{
		public virtual ApiDatabaseLogResponseModel MapRequestToResponse(
			int databaseLogID,
			ApiDatabaseLogRequestModel request)
		{
			var response = new ApiDatabaseLogResponseModel();
			response.SetProperties(databaseLogID,
			                       request.DatabaseUser,
			                       request.@Event,
			                       request.@Object,
			                       request.PostTime,
			                       request.Schema,
			                       request.Tsql,
			                       request.XmlEvent);
			return response;
		}

		public virtual ApiDatabaseLogRequestModel MapResponseToRequest(
			ApiDatabaseLogResponseModel response)
		{
			var request = new ApiDatabaseLogRequestModel();
			request.SetProperties(
				response.DatabaseUser,
				response.@Event,
				response.@Object,
				response.PostTime,
				response.Schema,
				response.Tsql,
				response.XmlEvent);
			return request;
		}

		public JsonPatchDocument<ApiDatabaseLogRequestModel> CreatePatch(ApiDatabaseLogRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDatabaseLogRequestModel>();
			patch.Replace(x => x.DatabaseUser, model.DatabaseUser);
			patch.Replace(x => x.@Event, model.@Event);
			patch.Replace(x => x.@Object, model.@Object);
			patch.Replace(x => x.PostTime, model.PostTime);
			patch.Replace(x => x.Schema, model.Schema);
			patch.Replace(x => x.Tsql, model.Tsql);
			patch.Replace(x => x.XmlEvent, model.XmlEvent);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f96768b9dae92a456ebdc303a13d1f94</Hash>
</Codenesium>*/