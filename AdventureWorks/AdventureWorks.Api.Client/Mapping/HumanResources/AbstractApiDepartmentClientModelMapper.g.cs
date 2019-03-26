using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public abstract class AbstractApiDepartmentModelMapper
	{
		public virtual ApiDepartmentClientResponseModel MapClientRequestToResponse(
			short departmentID,
			ApiDepartmentClientRequestModel request)
		{
			var response = new ApiDepartmentClientResponseModel();
			response.SetProperties(departmentID,
			                       request.GroupName,
			                       request.ModifiedDate,
			                       request.Name);
			return response;
		}

		public virtual ApiDepartmentClientRequestModel MapClientResponseToRequest(
			ApiDepartmentClientResponseModel response)
		{
			var request = new ApiDepartmentClientRequestModel();
			request.SetProperties(
				response.GroupName,
				response.ModifiedDate,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>1e9690558863b97eaee65a18c5bdceb9</Hash>
</Codenesium>*/