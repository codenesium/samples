using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiDepartmentServerModelMapper
	{
		public virtual ApiDepartmentServerResponseModel MapServerRequestToResponse(
			short departmentID,
			ApiDepartmentServerRequestModel request)
		{
			var response = new ApiDepartmentServerResponseModel();
			response.SetProperties(departmentID,
			                       request.GroupName,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiDepartmentServerRequestModel MapServerResponseToRequest(
			ApiDepartmentServerResponseModel response)
		{
			var request = new ApiDepartmentServerRequestModel();
			request.SetProperties(
				response.GroupName,
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public virtual ApiDepartmentClientRequestModel MapServerResponseToClientRequest(
			ApiDepartmentServerResponseModel response)
		{
			var request = new ApiDepartmentClientRequestModel();
			request.SetProperties(
				response.GroupName,
				response.ModifiedDate,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiDepartmentServerRequestModel> CreatePatch(ApiDepartmentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDepartmentServerRequestModel>();
			patch.Replace(x => x.GroupName, model.GroupName);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>cfea3c4d5b0b35314443e92e5abf0036</Hash>
</Codenesium>*/