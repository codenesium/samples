using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiDepartmentModelMapper
	{
		ApiDepartmentClientResponseModel MapClientRequestToResponse(
			short departmentID,
			ApiDepartmentClientRequestModel request);

		ApiDepartmentClientRequestModel MapClientResponseToRequest(
			ApiDepartmentClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>6c03c5a022d2bfef8d570f4d169f5836</Hash>
</Codenesium>*/