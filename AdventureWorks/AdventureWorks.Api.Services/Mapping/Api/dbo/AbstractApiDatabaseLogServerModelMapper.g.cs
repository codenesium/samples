using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiDatabaseLogServerModelMapper
	{
		public virtual ApiDatabaseLogServerResponseModel MapServerRequestToResponse(
			int databaseLogID,
			ApiDatabaseLogServerRequestModel request)
		{
			var response = new ApiDatabaseLogServerResponseModel();
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

		public virtual ApiDatabaseLogServerRequestModel MapServerResponseToRequest(
			ApiDatabaseLogServerResponseModel response)
		{
			var request = new ApiDatabaseLogServerRequestModel();
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

		public virtual ApiDatabaseLogClientRequestModel MapServerResponseToClientRequest(
			ApiDatabaseLogServerResponseModel response)
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

		public JsonPatchDocument<ApiDatabaseLogServerRequestModel> CreatePatch(ApiDatabaseLogServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDatabaseLogServerRequestModel>();
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
    <Hash>27af4cfc91f3b7bf26e16907629d1ce9</Hash>
</Codenesium>*/