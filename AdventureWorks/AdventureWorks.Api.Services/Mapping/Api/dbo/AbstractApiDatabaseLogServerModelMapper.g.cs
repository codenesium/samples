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
			                       request.DatabaseUser,
			                       request.PostTime,
			                       request.ReservedEvent,
			                       request.ReservedObject,
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
				response.DatabaseUser,
				response.PostTime,
				response.ReservedEvent,
				response.ReservedObject,
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
				response.DatabaseUser,
				response.PostTime,
				response.ReservedEvent,
				response.ReservedObject,
				response.Schema,
				response.Tsql,
				response.XmlEvent);
			return request;
		}

		public JsonPatchDocument<ApiDatabaseLogServerRequestModel> CreatePatch(ApiDatabaseLogServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDatabaseLogServerRequestModel>();
			patch.Replace(x => x.DatabaseUser, model.DatabaseUser);
			patch.Replace(x => x.ReservedEvent, model.ReservedEvent);
			patch.Replace(x => x.ReservedObject, model.ReservedObject);
			patch.Replace(x => x.PostTime, model.PostTime);
			patch.Replace(x => x.Schema, model.Schema);
			patch.Replace(x => x.Tsql, model.Tsql);
			patch.Replace(x => x.XmlEvent, model.XmlEvent);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>df5b49db6f0af589df300bc67028a359</Hash>
</Codenesium>*/