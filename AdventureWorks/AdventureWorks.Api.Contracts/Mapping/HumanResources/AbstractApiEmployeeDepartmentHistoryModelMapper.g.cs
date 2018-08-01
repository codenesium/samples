using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiEmployeeDepartmentHistoryModelMapper
	{
		public virtual ApiEmployeeDepartmentHistoryResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryRequestModel request)
		{
			var response = new ApiEmployeeDepartmentHistoryResponseModel();
			response.SetProperties(businessEntityID,
			                       request.DepartmentID,
			                       request.EndDate,
			                       request.ModifiedDate,
			                       request.ShiftID,
			                       request.StartDate);
			return response;
		}

		public virtual ApiEmployeeDepartmentHistoryRequestModel MapResponseToRequest(
			ApiEmployeeDepartmentHistoryResponseModel response)
		{
			var request = new ApiEmployeeDepartmentHistoryRequestModel();
			request.SetProperties(
				response.DepartmentID,
				response.EndDate,
				response.ModifiedDate,
				response.ShiftID,
				response.StartDate);
			return request;
		}

		public JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel> CreatePatch(ApiEmployeeDepartmentHistoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmployeeDepartmentHistoryRequestModel>();
			patch.Replace(x => x.DepartmentID, model.DepartmentID);
			patch.Replace(x => x.EndDate, model.EndDate);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.ShiftID, model.ShiftID);
			patch.Replace(x => x.StartDate, model.StartDate);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d1581af8b82b491810f55743c09b264d</Hash>
</Codenesium>*/