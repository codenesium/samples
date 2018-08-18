using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public abstract class AbstractApiEmployeeModelMapper
	{
		public virtual ApiEmployeeResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiEmployeeRequestModel request)
		{
			var response = new ApiEmployeeResponseModel();
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

		public virtual ApiEmployeeRequestModel MapResponseToRequest(
			ApiEmployeeResponseModel response)
		{
			var request = new ApiEmployeeRequestModel();
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

		public JsonPatchDocument<ApiEmployeeRequestModel> CreatePatch(ApiEmployeeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiEmployeeRequestModel>();
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
    <Hash>44767d3126ec88dac204668360ffd048</Hash>
</Codenesium>*/