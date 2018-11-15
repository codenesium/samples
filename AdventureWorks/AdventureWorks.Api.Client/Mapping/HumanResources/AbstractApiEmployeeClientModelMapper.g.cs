using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiEmployeeModelMapper
	{
		public virtual ApiEmployeeClientResponseModel MapClientRequestToResponse(
			int businessEntityID,
			ApiEmployeeClientRequestModel request)
		{
			var response = new ApiEmployeeClientResponseModel();
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

		public virtual ApiEmployeeClientRequestModel MapClientResponseToRequest(
			ApiEmployeeClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>df1474ca33ac2bb23a88ffb375664c8a</Hash>
</Codenesium>*/