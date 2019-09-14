using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiUnitOfficerModelMapper
	{
		ApiUnitOfficerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUnitOfficerClientRequestModel request);

		ApiUnitOfficerClientRequestModel MapClientResponseToRequest(
			ApiUnitOfficerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>322d3cd0fcb8c1a16aaa6f5d444dcbf9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/