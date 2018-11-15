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
    <Hash>11af8604b88b26fd70b0a28290f94895</Hash>
</Codenesium>*/