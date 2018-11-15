using AdventureWorksNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiEmployeeServerModelMapper
	{
		public virtual ApiEmployeeServerResponseModel MapServerRequestToResponse(
			int businessEntityID,
			ApiEmployeeServerRequestModel request)
		{
			var response = new ApiEmployeeServerResponseModel();
			response.SetProperties(businessEntityID,
			                       request.BirthDate,
			                       request.CurrentFlag,
			                       request.Gender,
			                       request.HireDate,
			                       request.JobTitle,
			                       request.LoginID,
			                       request.MaritalStatu,
			                       request.ModifiedDate,
			                       request.NationalIDNumber,
			                       request.OrganizationLevel,
			                       request.Rowguid,
			                       request.SalariedFlag,
			                       request.SickLeaveHour,
			                       request.VacationHour);
			return response;
		}

		public virtual ApiEmployeeServerRequestModel MapServerResponseToRequest(
			ApiEmployeeServerResponseModel response)
		{
			var request = new ApiEmployeeServerRequestModel();
			request.SetProperties(
				response.BirthDate,
				response.CurrentFlag,
				response.Gender,
				response.HireDate,
				response.JobTitle,
				response.LoginID,
				response.MaritalStatu,
				response.ModifiedDate,
				response.NationalIDNumber,
				response.OrganizationLevel,
				response.Rowguid,
				response.SalariedFlag,
				response.SickLeaveHour,
				response.VacationHour);
			return request;
		}

		public virtual ApiEmployeeClientRequestModel MapServerResponseToClientRequest(
			ApiEmployeeServerResponseModel response)
		{
			var request = new ApiEmployeeClientRequestModel();
			request.SetProperties(
				response.BirthDate,
				response.CurrentFlag,
				response.Gender,
				response.HireDate,
				response.JobTitle,
				response.LoginID,
				response.MaritalStatu,
				response.ModifiedDate,
				response.NationalIDNumber,
				response.OrganizationLevel,
				response.Rowguid,
				response.SalariedFlag,
				response.SickLeaveHour,
				response.VacationHour);
			return request;
		}

		public JsonPatchDocument<ApiEmployeeServerRequestModel> CreatePatch(ApiEmployeeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmployeeServerRequestModel>();
			patch.Replace(x => x.BirthDate, model.BirthDate);
			patch.Replace(x => x.CurrentFlag, model.CurrentFlag);
			patch.Replace(x => x.Gender, model.Gender);
			patch.Replace(x => x.HireDate, model.HireDate);
			patch.Replace(x => x.JobTitle, model.JobTitle);
			patch.Replace(x => x.LoginID, model.LoginID);
			patch.Replace(x => x.MaritalStatu, model.MaritalStatu);
			patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
			patch.Replace(x => x.NationalIDNumber, model.NationalIDNumber);
			patch.Replace(x => x.OrganizationLevel, model.OrganizationLevel);
			patch.Replace(x => x.Rowguid, model.Rowguid);
			patch.Replace(x => x.SalariedFlag, model.SalariedFlag);
			patch.Replace(x => x.SickLeaveHour, model.SickLeaveHour);
			patch.Replace(x => x.VacationHour, model.VacationHour);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>8901a6589ea4eaecbb569fe353e2be39</Hash>
</Codenesium>*/